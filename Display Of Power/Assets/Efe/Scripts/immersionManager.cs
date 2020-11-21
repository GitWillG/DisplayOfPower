using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe; // Access to namespace library
using Knife.HDRPOutline.Core;

// Immersion manager governs everything that doesn't affect the game design/gameplay directly, but used mostly for visualization.
// Features such as overhead names are written here.
// Efe Karacar

public class immersionManager : MonoBehaviour
{


    actorData data;
    gameManager gm;
    GameObject curPlayer;
    [Header("NPC labels")]
    // 3D text that spawns on top of actors' heads
    public GameObject NPCObject;
    // Minimum distance between players and all legit actors required for labels to appear
    public float distance_NPC_labels;
    // Static metric gathered from basemesh to spawn the 3D text on top of actor's head
    public float Y_base_label_pos;
    // List to store all active labels in the scene
    public List<GameObject> labelsActive;
    // Material for edge outline
    [Header("Mesh Outlining")]
    // outline material
    public Material selectedMaterialVFX;
    [SerializeField]
    // old material of selected object stored here
    //Material oldMaterial;
    // replace skinned mesh materials of object selected with this list to array
    // which is dynamically adjusted on highlightObject script
    public List<Material> resultMaterials;
    [SerializeField]
    // check if there is any highlight 
    // bool highlighted = false;
    // bool highlighted2 = false;
    // Point light reference to make the outline pop up more
    public GameObject highlightLight;
    // Check if there is a light already, dont spawn new ones if there is one
    GameObject storedLight;
    [Header("Test Subjects")]
    public GameObject testmateira;
    public GameObject propTest;


    // 3D exclamation model used to show if an actor has any quest to give to player
    public GameObject questAvailableMark;
    OutlineObject outlineData;

    void Start()
    {
        // Initialize declarations
        distance_NPC_labels = 5;
        Y_base_label_pos = 18;

        // Reference to gamemanager
        gm = GetComponent<gameManager>();

        curPlayer = gm.curAvatar;

    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.M))
        // {
        //     if(!highlighted)
        //     {
        //         highlighObject(testmateira, "Character");
        //         highlighted = true;
        //     }
        //     else
        //     {
        //         restoreHighlight(testmateira);
        //         highlighted = false;
        //     }
        // }
        // if(Input.GetKeyDown(KeyCode.N))
        // {
        //     if(!highlighted2)
        //     {
        //         highlighObject(propTest, "Prop");
        //         highlighted2 = true;
        //     }
        //     else
        //     {
        //         restoreHighlight(propTest);
        //         highlighted2 = false;
        //     }
        // }

        if(Input.GetKey(KeyCode.H))
        {
            // Find all the actors in the scene
            GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
            // Access each actor
            foreach(GameObject NPC in NPCs)
            {
                data = NPC.GetComponent<actorData>();
                // If any actor in this scene is peaceful
                if(data.peaceful == true)
                {
                    // Store its distance to player
                    float distance = Vector3.Distance(curPlayer.transform.position, NPC.transform.position);
                    // If it is below the declared value
                    if(distance < distance_NPC_labels)
                    {   
                        // If it already doesnt have a label
                        if(data.responsibleLabelText == null)
                        {
                            // Determine where to spawn
                            Vector3 spawnPosition = new Vector3(NPC.transform.position.x, Y_base_label_pos, NPC.transform.position.z);
                            // Spawn the exclamation
                            GameObject newLabel = Instantiate(NPCObject, spawnPosition, Quaternion.identity);
                            // Save it on the declared list
                            labelsActive.Add(newLabel);
                            // Change the text of 3d mesh to actorName which is stored in actorData
                            newLabel.GetComponent<TextMesh>().text = data.actorName;
                            // Store the 3d object in each instanced actor
                            data.responsibleLabelText = newLabel;
                            // Make sure exclamation follows the actor
                            newLabel.transform.parent = NPC.transform;
                        }
                    }
                }
            }
        }

        // Remove all labels in the scene when you let the same key go
        if(Input.GetKeyUp(KeyCode.H))
        {
            // Access to the list where all labels are stored once pressed H
            foreach(GameObject temp in labelsActive)
            {
                // Destroy
                Destroy(temp.gameObject);
                // Refresh the list
                labelsActive.Remove(temp);
                // Debug.Log("Labels closed. " + temp.name);

            }
        }
    }

    /// <summary>
    ///  Script responsible switching between an object's original materials and an edge outline material once hovered. Used for highlihting meshes dynamically.
    ///  Called from mouseControls.
    ///  It uses skinnedmeshrenderers for rigged objects, renderer material for static objects.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="objectType"></param>
    public void highlighObject(GameObject target, string objectType)
    {
        if(target.tag != "NPC") return;

        if(target == null) return;
        // Objects with rigs have skinned mesh renderer
        if(objectType == "Character")
        {
            // Target reference is a prefab
            // So find the body in its childs
            GameObject body = target.transform.Find("Body").gameObject;
            if(body == null) return;
            // Save the old material
            target.GetComponent<actorData>().oldMaterial = body.GetComponent<Renderer>().material;
            // Access to skinned mesh component
            SkinnedMeshRenderer renderer = body.GetComponent<SkinnedMeshRenderer>();
            resultMaterials.Clear();
            // Add the original material of the body to list of materials mesh will have in the end
            resultMaterials.Add(target.GetComponent<actorData>().oldMaterial);
            // Add outline material as 2nd
            resultMaterials.Add(selectedMaterialVFX);
            // Replace materials array with new one
            // Before replacement, there is only oldMaterial
            // After replacement, there is oldmaterial + outlinematerial
            renderer.materials = resultMaterials.ToArray();
            // Debug.Log(body.name + target.name);


        }
        // No skinned mesh renderer, just change material
        else if(objectType == "Prop")
        {
            // store prop material
            target.GetComponent<actorData>().oldMaterial = target.GetComponent<Renderer>().material;
            // change prop material to outline material
            target.GetComponent<Renderer>().material = selectedMaterialVFX;
            // Add outlnieobject script for more control
            if(target.GetComponent<OutlineObject>() == null)
            {
                outlineData = target.AddComponent<OutlineObject>();
            }
            // Properties
            // Auto-fill the material property with outline material reference in this manager
            outlineData.Material = selectedMaterialVFX;
            outlineData.FresnelPower = 3;
            outlineData.FresnelScale = 4;
        }
        // Does it get the right reference for each type of object?
        // Debug.Log(target.name);

        // Instantiate the light in approximately in the center of body - its not dynamic yet
        //if(storedLight == null)
        //{
        //    storedLight = Instantiate(highlightLight, 
        //    new Vector3
        //    (target.transform.position.x, 
        //    target.transform.position.y + 5, 
        //    target.transform.position.z), 
        //    Quaternion.identity);
        //}
        //// if there is already a light in scene, just move it
        //else
        //{
        //    storedLight.transform.position = target.transform.position;
        //}

        // TODO - multiple selections support
        
    }


    /// <summary>
    /// Removes the highlights from the meshes in affect.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="ObjectType"></param>
    public void restoreHighlight(GameObject target, string ObjectType)
    {
        if(target.tag != "NPC") return;

        if(target == null || ObjectType == null) return;
        if(ObjectType == "Character")
        {
            GameObject body = target.transform.Find("Body").gameObject;
            if(body == null) return;
            SkinnedMeshRenderer renderer = body.GetComponent<SkinnedMeshRenderer>();
            // Save the old material
            resultMaterials.Clear();
            // Add the original material of the body to list of materials mesh will have in the end
            resultMaterials.Add(target.GetComponent<actorData>().oldMaterial);
            // Replace materials array with new one
            // Before replacement, there is only oldMaterial
            // After replacement, there is oldmaterial + outlinematerial
            renderer.materials = resultMaterials.ToArray();
            // resultMaterials.Clear();
            // resultMaterials.Add(oldMaterial);
            //Debug.Log(target.name + " restored.");
        }
    }
}

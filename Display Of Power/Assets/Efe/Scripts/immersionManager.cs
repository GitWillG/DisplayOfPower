using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe; // Access to namespace library


// Immersion manager governs everything that doesn't affect the game design/gameplay directly, but used mostly for visualization.
// Features such as overhead names are written here.
// Efe Karacar

public class immersionManager : MonoBehaviour
{

    // 3D text that spawns on top of actors' heads
    public GameObject NPCObject;
    actorData data;
    gameManager gm;
    GameObject curPlayer;
    // Minimum distance between players and all legit actors required for labels to appear
    public float distance_NPC_labels;
    // Static metric gathered from basemesh to spawn the 3D text on top of actor's head
    public float Y_base_label_pos;
    // List to store all active labels in the scene
    public List<GameObject> labelsActive;
    // Material for edge outline
    public Material selectedMaterialVFX;
    // Before using edge outline, materials of hovered objects need to be stored
    // TODO - might have to store it on instances instead if more than 2 objects can be hovered
    Material[] selected_object_materials;
    // 3D exclamation model used to show if an actor has any quest to give to player
    public GameObject questAvailableMark;

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

    // Script responsible switching between an object's original materials and an edge outline material once hovered
    // Called from mouseControls
    public void highlighObject(GameObject target)
    {
        // selected_object_materials = target.GetComponent<Renderer>().materials;
        
        
    }
}

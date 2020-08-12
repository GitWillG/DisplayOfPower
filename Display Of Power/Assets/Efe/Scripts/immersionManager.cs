using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class immersionManager : MonoBehaviour
{

    public GameObject NPCObject;
    actorData data;
    gameManager gm;
    GameObject curPlayer;

    public float distance_NPC_labels;

    public float Y_base_label_pos;

    public List<GameObject> labelsActive;

    public Material selectedMaterialVFX;

    Material[] selected_object_materials;
    public GameObject questAvailableMark;

    void Start()
    {
        distance_NPC_labels = 5;
        Y_base_label_pos = 18;

        gm = GetComponent<gameManager>();

        curPlayer = gm.curAvatar;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
            foreach(GameObject NPC in NPCs)
            {
                data = NPC.GetComponent<actorData>();
                if(data.peaceful == true)
                {
                    float distance = Vector3.Distance(curPlayer.transform.position, NPC.transform.position);
                    if(distance < distance_NPC_labels)
                    {
                        if(data.responsibleLabelText == null)
                        {
                            Vector3 spawnPosition = new Vector3(NPC.transform.position.x, Y_base_label_pos, NPC.transform.position.z);
                            GameObject newLabel = Instantiate(NPCObject, spawnPosition, Quaternion.identity);
                            labelsActive.Add(newLabel);
                            
                            Debug.Log("Labels open. " + newLabel.name);

                            newLabel.GetComponent<TextMesh>().text = data.actorName;
                            data.responsibleLabelText = newLabel;
                            newLabel.transform.parent = NPC.transform;
                        }
                    }
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.H))
        {
            foreach(GameObject temp in labelsActive)
            {
                Destroy(temp.gameObject);
                labelsActive.Remove(temp);
                Debug.Log("Labels closed. " + temp.name);

            }
        }
    }

    public void highlighObject(GameObject target)
    {
        selected_object_materials = target.GetComponent<Renderer>().materials;
        
        
    }
}

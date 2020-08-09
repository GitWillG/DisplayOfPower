using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
// needs to be called "using efe;"
namespace efe
{
    public class mouseControls : MonoBehaviour
    {
        gameManager gm;
        GameObject playerToControl;
        Animator curAnimator;
        NavMeshAgent curAgent;
        GUIManager guim;
        actorData actorData;
        locationData locData;
        public questItem curQuest;

        bool isMoving = false;
        float curSpeed;
        Vector3 targetMovePosition;
        // Start is called before the first frame update
        void Start()
        {
            gm = GetComponent<gameManager>();
            guim = GetComponent<GUIManager>();

            playerToControl = gm.curAvatar;

            curAgent = playerToControl.GetComponent<NavMeshAgent>();
            curAnimator = playerToControl.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(playerToControl != gm.curAvatar)
            {
                playerToControl = gm.curAvatar;
                curAgent = playerToControl.GetComponent<NavMeshAgent>();
                curAnimator = playerToControl.GetComponent<Animator>();
            }

            if(Physics.Raycast(ray, out hit, 1000))
            {
                if (Input.GetMouseButtonDown(0)) // left click
                {
                    movePlayer(curAgent, hit.point);
                }
                if(Input.GetMouseButtonDown(1)) // right click
                {
                    interactObject(hit.transform.gameObject);
                }
            }

            processPlayerMovement();
        }

        public void movePlayer(NavMeshAgent objectSource, Vector3 targetPoint)
        {
            objectSource.SetDestination(targetPoint);
            targetMovePosition = targetPoint;
            isMoving = true;
            Debug.Log("Character moving.");
        }

        void processPlayerMovement()
        {
            if(isMoving == true)
            {
                float distance = Vector3.Distance(playerToControl.transform.position, targetMovePosition);
                if(distance >= 0)
                {
                    curSpeed = 1;
                    curSpeed = Mathf.Clamp(curSpeed, 0, 1);
                    curAnimator.SetFloat("Speed", curSpeed);
                    Debug.Log("Processing");
                    if(distance == 0)
                    {
                        curSpeed = 0;
                        isMoving = false;
                        curAnimator.ResetTrigger("Speed");
                        Debug.Log("Reached.");
                    }
                }

            }
        }

        public void interactObject(GameObject targetObject)
        {
            gm.lastSelectedTarget = targetObject;
            if(targetObject.tag == "NPC")
            {
                actorData = targetObject.GetComponent<actorData>();
                if(actorData.peaceful == true)
                {
                    Debug.Log("Clicked on a peaceful NPC.");
                    GameObject newScreen = Instantiate(guim.dialogScreen, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                    curQuest = actorData.actorQuests[0];
                    newScreen.GetComponent<menuScripts>().questName_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questName;
                    newScreen.GetComponent<menuScripts>().questDesc_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questDesc;
                    newScreen.GetComponent<menuScripts>().questGold_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questGold.ToString();
                    newScreen.GetComponent<menuScripts>().questXP_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questXp.ToString();
                }
            }
            else if(targetObject.tag == "Location")
            {
                locData = targetObject.GetComponent<locationData>();
                if(locData.peaceful == true)
                {
                    gm.curLocation = targetObject;
                    GameObject newScreen = Instantiate(guim.locationMap_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                    Debug.Log("Clicked on a peaceful location.");
                }
            }
            
            Debug.Log("Interacted with " + targetObject.name);
        }
    }

}
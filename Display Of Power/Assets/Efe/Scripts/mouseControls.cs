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
        immersionManager im;
        public questItem curQuest;

        float curSpeed;
        Vector3 targetMovePosition;

        bool moving = false;
        float initialRunSpeed = 1;
        bool controllerSent = false;
        public GameObject moveParticle;
        // Start is called before the first frame update
        void Start()
        {
            gm = GetComponent<gameManager>();
            guim = GetComponent<GUIManager>();
            im = GetComponent<immersionManager>();
            

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
            detectHover();
        }

        void detectHover()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.transform.gameObject.name);
                if(hit.transform.gameObject.tag == "NPC")
                {
                    gm.curHoveredObject = hit.transform.gameObject;
                    im.highlighObject(gm.curHoveredObject);
                }
            }
        }



        public void movePlayer(NavMeshAgent objectSource, Vector3 targetPoint)
        {
            objectSource.SetDestination(targetPoint);
            targetMovePosition = targetPoint;

            float speed = Vector3.Distance(playerToControl.transform.position, targetMovePosition);
            initialRunSpeed = speed;
            controllerSent = false;

            GameObject vfx = Instantiate(moveParticle, targetMovePosition, Quaternion.identity);
            Destroy(vfx, 1);
            // Debug.Log("Ordered to move.");
        }

        void processPlayerMovement()
        {
            float distance = Vector3.Distance(playerToControl.transform.position, targetMovePosition);
            // Debug.Log(distance);
            if(distance > 2)
            {   
                if(!controllerSent)
                {
                    curAnimator.SetFloat("Speed", initialRunSpeed);
                    controllerSent = true;
                }
                else if(controllerSent == true)
                {
                    initialRunSpeed--;
                    curAnimator.SetFloat("Speed", initialRunSpeed);
                }

                // Debug.Log("Moving");
                    if(distance < 2)
                    {   
                        curAnimator.ResetTrigger("Speed");
                        // Debug.Log("Reached");
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
                    GameObject newScreen = Instantiate(guim.partyEntrance_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                    Debug.Log("Clicked on a peaceful location.");
                }
            }
            
            Debug.Log("Interacted with " + targetObject.name);
        }
    }

}
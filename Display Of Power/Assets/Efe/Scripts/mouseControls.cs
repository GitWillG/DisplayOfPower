using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using efe; // Access to library, namespaces need to be referenced like this

// This script governs every mechanic related to mouse and its links to the game. 
// all clicking behaviours are also governed here.
// Efe Karacar

// needs to be called "using efe;"
namespace efe // efe library
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
        public GameObject moveParticle; // Particle that will spawn on mouse click if player agent is suppposed to move somewhere
        // Start is called before the first frame update
        void Start()
        {
            // Most of the managers are stored in same object as GM is stored in
            gm = GetComponent<gameManager>();
            guim = GetComponent<GUIManager>();
            im = GetComponent<immersionManager>();
            
            // Avatar player uses in level or world?
            playerToControl = gm.curAvatar;

            // Access to components to be used later
            curAgent = playerToControl.GetComponent<NavMeshAgent>();
            curAnimator = playerToControl.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            // Stored ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // Result of the ray
            RaycastHit hit;

            // Always make sure you are using the right avatar and restore if it is the wrong one
            // Aka - referencing the avatar used in levels for world map behaviours
            if(playerToControl != gm.curAvatar)
            {
                playerToControl = gm.curAvatar;
                curAgent = playerToControl.GetComponent<NavMeshAgent>();
                curAnimator = playerToControl.GetComponent<Animator>();
            }

            // if(guim.HUD.Contains(Event.current.mousePosition))
            // {
                // Cast
                if(Physics.Raycast(ray, out hit, 1000))
                {
                    // Instead of casting it twice, conditions can be put inside a single ray
                    if (Input.GetMouseButtonDown(0)) // left click
                    {
                        // Script responsible of sending agent to vector3
                        movePlayer(curAgent, hit.point);
                    }
                    
                    if(Input.GetMouseButtonDown(1)) // right click
                    {
                        float distance = Vector3.Distance(playerToControl.transform.position, hit.transform.position);
                        if(distance < 3)
                        {
                        // Script responsible for interacting with any object in game - actors, items, props, locations...etc
                            interactObject(hit.transform.gameObject);
                        }
                        else
                        {
                            movePlayer(curAgent, hit.point);
                        }
                    }
                    
                    // hover below
                    Debug.Log(hit.transform.gameObject.name);
                    // Ray is still casted, but no condition is needed as it is cast all the time
                    // TODO - Optimization, use coroutine or invoke to cast it less
                    // Now it is casted 24 times every second
                    // Hover over NPCs
                    if(hit.transform.gameObject.tag == "NPC")
                    {
                        // Store
                        gm.curHoveredObject = hit.transform.gameObject;
                        // Enable edge outline
                        im.highlighObject(gm.curHoveredObject);
                    }
                }

                // Script responsible of syncing blend trees and navmesh agents
                processPlayerMovement();
            // }
        }

        // called from update above with raycast on mouse position
        public void movePlayer(NavMeshAgent objectSource, Vector3 targetPoint)
        {
            // target vector3, move player agent
            objectSource.SetDestination(targetPoint);
            // instantiate selection particle on agent's current destination he is travelling to
            GameObject vfx = Instantiate(moveParticle, targetPoint, Quaternion.identity);
            // destroy it after a second
            Destroy(vfx, 1);
            
        }

        void processPlayerMovement()
        {       

            // uses the navmesh system to grab the velocity of the player - aka his current speed
            // agent.speed returns maximum possible agent can reach
            // compare it with stoppind distance
            if(curAgent.remainingDistance > curAgent.stoppingDistance)
            {
                // blend trees sync with navmesh
                // Animation controller has a float called "Speed", which blend tree inside also uses
                // Blend tree uses it to determine thresholds to determine which animation should play
                // Aka - 0.5 speed = walk, 1 = run, 0 = idle
                curAnimator.SetFloat("Speed", curAgent.velocity.magnitude);
            }     
            else
            {
                // still blend as it will send 0 for magnitude anyhow
                // else represents that agent reached its target vector
                curAnimator.SetFloat("Speed", curAgent.velocity.magnitude);
            }
        }

        // Script to govern mouse clicks (right or wrong) on gameobjects
        // It is called from update above
        public void interactObject(GameObject targetObject)
        {
            // Save the last target always
            gm.lastSelectedTarget = targetObject;
            // Actors of all kind
            if(targetObject.tag == "NPC")
            {
                // Reference to actordata
                actorData = targetObject.GetComponent<actorData>();
                // Actors that wont fight aka random villagers walking around, quest givers, important figures to talk to
                if(actorData.peaceful == true)
                {
                    Debug.Log("Clicked on a peaceful NPC.");
                    // Open the dialog popup
                    GameObject newScreen = Instantiate(guim.dialogScreen, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                    // Get the actor's quest
                    curQuest = actorData.actorQuests[0];
                    // Transfer actor's quest to the popup
                    newScreen.GetComponent<menuScripts>().questName_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questName;
                    newScreen.GetComponent<menuScripts>().questDesc_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questDesc;
                    newScreen.GetComponent<menuScripts>().questGold_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questGold.ToString();
                    newScreen.GetComponent<menuScripts>().questXP_gui.GetComponent<TextMeshProUGUI>().text = curQuest.questXP.ToString();
                }
            }
            // World map locations
            else if(targetObject.tag == "Location")
            {
                // The script reference in which all data regarding locations are stored
                locData = targetObject.GetComponent<locationData>();
                // If location is a city, village - some place where there wont be encounters
                if(locData.peaceful == true)
                {
                    // Store player's current location in world
                    gm.curLocation = targetObject;
                    // Open interactive page with options like siege, enter the location...etc
                    GameObject newScreen = Instantiate(guim.partyEntrance_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
                    // Debug.Log("Clicked on a peaceful location.");
                }
            }
            
            // Debug.Log("Interacted with " + targetObject.name);
        }
    }

}
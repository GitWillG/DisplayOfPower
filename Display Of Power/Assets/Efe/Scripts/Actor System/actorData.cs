using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;

// needs to be called "using efe;"
namespace efe{
    public class actorData : MonoBehaviour
    {
        [Header("Base stats")]
        public string actorName;
        public float actorGold;
        public float actorXP;
        public float actorXPRequired;
        public float actionPoint;
        public float maxActionPoint;
        public float baseDamage;
        public itemSO[] relic;
        public bool randomizeName;
        public bool isPlayer;
        public factionSO ownerFaction;
        public dialogSO defaultDialog;

        [Header("Quests")]
        public List<questItem> actorQuests;
        public bool hasQuest;
        public bool walkAround;
        public bool peaceful; // false = unit
        [Header("Location")]
        public GameObject[] locationArray;
        public enum locationList {waterCity, Pahro}
        public locationList actorLocation;
        public int curIndex;
        public int actorEntryPoint;
        public GameObject responsibleLabelText;
        public enum types {hero, commander, civilian, unit}
        public types actorType;
        NavMeshAgent agent;
        Animator animator;
        immersionManager im;
        GameObject gm;
        rigHumanoid rig;
        public spellSO[] spells;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            gm = GameObject.FindGameObjectWithTag("GM");
            // im = gm.GetComponent<immersionManager>();
            rig = GetComponent<rigHumanoid>();
            animator = GetComponent<Animator>();

            if(actorQuests.Count > 0)
            {
                GameObject mark = Instantiate(im.questAvailableMark, rig.overhead_reference.transform.position, Quaternion.identity);
                mark.transform.parent = rig.overhead_reference.transform;
                hasQuest = true;
            }

            locationArray = GameObject.FindGameObjectsWithTag("Location");
            if(actorLocation == locationList.waterCity)
            {
                
            }
            else if(actorLocation == locationList.Pahro)
            {

            }
            // Debug.Log(this.name + " will spawn in " + actorEntryPoint + " " + actorLocation.locationName);

            if(peaceful)
            {
                agent.speed = 1;
            }
        }

        public void Update()
        {
            processAiMovement();
        }

        [ContextMenu("Sync Editor")]
        public void syncEditor()
        {
            this.gameObject.name = actorName;
            // Object reference = Resources.FindObjectsOfTypeAll
        }


        public void processAiMovement()
        {
            if(agent != null)
            {
                if(!isPlayer)
                {
                    if(agent.remainingDistance > agent.stoppingDistance)
                    {
                        // blend trees sync with navmesh
                        // Animation controller has a float called "Speed", which blend tree inside also uses
                        // Blend tree uses it to determine thresholds to determine which animation should play
                        // Aka - 0.5 speed = walk, 1 = run, 0 = idle
                        animator.SetFloat("Speed", agent.velocity.magnitude);
                    }     
                    else
                    {
                        // still blend as it will send 0 for magnitude anyhow
                        // else represents that agent reached its target vector
                        animator.SetFloat("Speed", agent.velocity.magnitude);
                    }
                }
            }
        }
    }
}
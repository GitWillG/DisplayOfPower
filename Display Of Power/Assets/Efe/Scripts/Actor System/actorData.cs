using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;
using efe;

// needs to be called "using efe;"
namespace efe{
    public class actorData : MonoBehaviour
    {
        [Header("Base stats")]
        public string actorName;
        public int Life;
        int maxLife;
        public int actorGold;
        public int actorXP;
        public int actorXPRequired;
        public int actionPoint;
        public string ownerFaction_string;
        public int actionsRemaining;
        public int maxActionPoint;
        public int baseDamage;
        public itemSO[] relic;
        public bool randomizeName;
        public bool isPlayer;
        public factionSO ownerFaction;
        public dialogSO defaultDialog;
        public bool belongsToPlayer;
        public bool isTurn;
        public int MovementRange;
        public int AttackRange;
        public int TotalActions;
        public Sprite initiativeAvatar;

        [Header("Audio")]
        public AudioSource click_voice;
        public AudioSource move_voice;
        public AudioSource takehit_voice;
        public AudioSource death_voice;
        public AudioSource order_attack_voice;
        public AudioSource attack_voice;

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
        public Sprite cinematicAvatar;

        public GameObject overheadReference;
        public Slider healthBar;
        public GameObject initiativeReference;
        public GameObject AP_reference;
        public GameObject curHPtext_reference;
        public GameObject maxHPtext_reference;
        public GameObject damageGUI_reference;
        MouseControl mc;
        
        void Start()
        {

            agent = GetComponent<NavMeshAgent>();
            gm = GameObject.FindGameObjectWithTag("GM");
            // im = gm.GetComponent<immersionManager>();
            rig = GetComponent<rigHumanoid>();
            animator = GetComponent<Animator>();
            mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();

            overheadReference.SetActive(false);

            // Health Bar
            maxLife = Life;

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
            updateHealthBar();
        }

        void updateHealthBar()
        {
            
            // if(isTurn)
            // {
            //     overheadReference.gameObject.SetActive(true);
            // }
            // else
            // {
            //     overheadReference.gameObject.SetActive(false);
            // }

            if (healthBar != null)
            {
                healthBar.maxValue = maxLife;
                healthBar.value = Life;
                AP_reference.GetComponent<TextMeshProUGUI>().text = actionsRemaining.ToString();
                damageGUI_reference.GetComponent<TextMeshProUGUI>().text = baseDamage.ToString();
                curHPtext_reference.GetComponent<TextMeshProUGUI>().text = Life.ToString();
                maxHPtext_reference.GetComponent<TextMeshProUGUI>().text = maxLife.ToString();

            }
            
        }

        [ContextMenu("Sync Editor")]
        public void syncEditor()
        {
            this.gameObject.name = actorName;
            // Object reference = Resources.FindObjectsOfTypeAll
        }


        public void processAiMovement()
        {
            if(agent.isOnNavMesh)
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
            agent.speed = 10;
        }
    }
}
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
        public bool isBoss;
        public enum attackTypes { ranged, melee, magic}
        public attackTypes attackType;

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
        gameManager gm;
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
        GameObject enemySideReference;
        GameObject allySideReference;

        public bool hasStatus = false;
        public spellSO statusSpellReference;
        public int statusDuration;
        public int statusEffect;

        public GameObject baseProjectile;
        public bool useParticles;
        public ParticleSystem projectileParticle;

        public int idealAP;
        [Header("Buff Information")]
        public bool affectedbyBuff;
        public bool affectedbyDebuff;
        public int buffHeld;
        public string buffName;
        public string buffProperty;
        [Header("Cooldown Information")]
        public List<int> cooldownCounters;

        public GameObject lookTarget;

        CameraControl cc;

        public Animation curAnimation;

        public int dodgeRate;
        
        
        void Start()
        {

            // Always store the ideal ap this actor has, also can be used for maxAP this actor can havea.
            idealAP = actionsRemaining;

            // Cooldown counters for skills, matched with spells this actor has
            for(int z = 0; z < spells.Length; z++)
            {
                cooldownCounters.Add(0);
            }

            // Empty object references for where actors should look at by default
            enemySideReference = GameObject.FindGameObjectWithTag("EnemySide");
            allySideReference = GameObject.FindGameObjectWithTag("AllySide");

            #region Reference Grabbing
            agent = GetComponent<NavMeshAgent>();
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
            im = gm.GetComponent<immersionManager>();
            rig = GetComponent<rigHumanoid>();
            animator = GetComponent<Animator>();
            mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
            cc = Camera.main.GetComponent<CameraControl>();
            #endregion

            //// If there is a overheadreference, hide it by default
            //if (overheadReference != null)
            //{
            //    overheadReference.SetActive(false);
            //}

            // Research - scale actors who are tagged as boss to make them look bigger than other actors.
            // if(isBoss)
            // {
            //     // transform.localScale *= 1/2;
            // }

            // Health Bar
            maxLife = Life;

            if(actorQuests.Count > 0)
            {
                GameObject mark = Instantiate(im.questAvailableMark, rig.overhead_reference.transform.position, Quaternion.identity);
                mark.transform.parent = rig.overhead_reference.transform;
                hasQuest = true;
            }


            #region TODO
            //locationArray = GameObject.FindGameObjectsWithTag("Location");
            //if(actorLocation == locationList.waterCity)
            //{

            //}
            //else if(actorLocation == locationList.Pahro)
            //{

            //}
            // Debug.Log(this.name + " will spawn in " + actorEntryPoint + " " + actorLocation.locationName);
            #endregion

            // For Debugging
            if (peaceful)
            {
                agent.speed = 1;
            }

            resetLookTarget();
        
    }

        public void Update()
        {
            processAiMovement();
            updateHealthBar();                                      
            
        }
 
        
        /// <summary>
        /// This script designates a new gameobject for this actor to look to.
        /// </summary>
        /// <param name="_target"></param>        
        public void changeLookTarget(GameObject _target)
        {
            lookTarget = _target;
            this.transform.LookAt(lookTarget.transform);
        }

        /// <summary>
        /// This script resets where actor is looking. Called when actor is done moving.
        /// </summary>
        public void resetLookTarget()
        {
            if (ownerFaction_string == "Enemy")
            {
                changeLookTarget(allySideReference);

            }
            else
            {
                changeLookTarget(enemySideReference);
            }
        }

        /// <summary>
        /// This script syncs HP and AP variables of actordata with overhead bars.
        /// </summary>
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

        /// <summary>
        /// This is an editor script that just updates the inspector with actorData.
        /// </summary>
        [ContextMenu("Sync Editor")]
        public void syncEditor()
        {
            this.gameObject.name = actorName;
            // Object reference = Resources.FindObjectsOfTypeAll
        }


        /// <summary>
        /// This script syncs animations with moveSpeed of the actor, also calls the necessary scripts when actor is done moving.
        /// </summary>
        public void processAiMovement()
        {
            if(agent.isOnNavMesh)
            {
                if(!isPlayer)
                {
                    // Agent is moving
                    if(agent.remainingDistance > agent.stoppingDistance)
                    {
                        // blend trees sync with navmesh
                        // Animation controller has a float called "Speed", which blend tree inside also uses
                        // Blend tree uses it to determine thresholds to determine which animation should play
                        // Aka - 0.5 speed = walk, 1 = run, 0 = idle
                        animator.SetFloat("Speed", agent.velocity.magnitude);
                        mc.isMoving = true;
                    }     
                    else
                    {
                        // still blend as it will send 0 for magnitude anyhow
                        // else represents that agent reached its target vector
                        animator.SetFloat("Speed", agent.velocity.magnitude);
                        mc.isMoving = false;
                        //Debug.Log("Actor finished moving.");
                        cc.finishTracking();
                        return;

                        
                    }
                }
            }
            agent.speed = 10;
        }
    }
}
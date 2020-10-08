using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using efe;

namespace efe{
    public class menuScripts : MonoBehaviour
    {
        [SerializeField]
        questManager qm;
        gameManager gm;
        locationManager lm;
        mouseControls_freeroam mc;
        playerStats ps;
        settingsManager sm;
        // Dialog page
        [Header("Dialog page")]
        public GameObject npcName;
        public GameObject npcDialog;
        public GameObject questName_gui;
        public GameObject questXP_gui;
        public GameObject questGold_gui;
        public GameObject questDesc_gui;
        [Header("Diplomacy Page")]
        // Diplomacy Screen
        public TextMeshProUGUI faction_name_1;
        public TextMeshProUGUI faction_name_2;
        public GameObject curOfferList;
        public GameObject curDemandList;

        [Header("Log")]
        public TextMeshProUGUI[] logTexts;

        [Header("Skillbar")]
        public Image[] _skillslots;
        [Header("Character Web")]
        public GameObject webCharParent;
        public GameObject webCharacterIcon;

        // bool generatedType;

        [Header("Location Map")]
        public GameObject npcIconBase;
        public GameObject iconParent;

        
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
            qm = GameObject.FindGameObjectWithTag("QM").GetComponent<questManager>();
            lm = gm.GetComponent<locationManager>();
            mc = gm.GetComponent<mouseControls_freeroam>();
            ps = gm.GetComponent<playerStats>();
            sm = gm.GetComponent<settingsManager>();

            // if(this.name == "partyEntrance")
            // {
            //     if(gm.curLocation.GetComponent<locationData>() != null)
            //     {
            //         generatedType = false; // its an existing location
            //         generateNPCicons();
            //     }
            //     else 
            //     {
            //         generatedType = true; // generated
                    
            //     }
            // }

            if(this.gameObject.tag == "CharacterWebGUI")
            {
                prepareWeb();
            }

            
        }

        public void enterLocation(bool generationToSend)
        {
            lm.enterLocation(generationToSend);
        }

        public void updateLog(string targetString)
        {
            foreach(TextMeshProUGUI temp in logTexts)
            {
                temp.text = targetString;
            }
        }

        public void leaveLocation()
        {
            lm.leaveLocation();
        }

        public void startQuest()
        {
            qm.startQuest(mc.curQuest, gm.curInteractedNPC);
            
        }

        public void endQuest()
        {
            qm.endQuest(mc.curQuest);
        }

        public void succeedQuest()
        {
            qm.succeedQuest(mc.curQuest);
        }

        public void cancelQuest()
        {
            qm.succeedQuest(mc.curQuest);
        }

        public void failQuest()
        {
            qm.succeedQuest(mc.curQuest);
        }

        public void resetGUIList()
        {
            foreach(GameObject temp in gm.openGUIs)
            {
                if(temp.name == "HUD")
                {
                    gm.openGUIs.Remove(temp);
                }
            }
        }
        public void openGUI(GameObject GUI)
        {
            // Put the GUI
            Instantiate(GUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            // Store it in gamemanager
            gameManager.curGUI = GUI;
            // Store the current state game is in
            gm.changeField("HUD");
            // Prepare the GUI based on context
            prepareGUI(GUI);
            // Store it in a list to check how many guis are open
            gm.openGUIs.Add(GUI);
            // Debug
            Debug.Log(GUI.name + " opened.");
        }

        public void prepareGUI(GameObject GUI)
        {
            if(GUI.name == "dialogScreen")
            {
                if(!gm.curInteractedNPC.GetComponent<actorData>().hasQuest)
                {
                    GUI.transform.Find("QuestPart").gameObject.SetActive(false);
                }
            }
        }

        public void closeGUI(GameObject GUI)
        {
            Destroy(GUI);
            Time.timeScale = 1;
            // Update the list in game manager
            gm.openGUIs.Remove(GUI);
            // gm_ref.changeState("Level");
            // Debug.Log(GUI.name + " closed.");
        }


        public void linkGUItoScript(GameObject btnContainer)
        {
            diplomacy_container diplomacyRef = btnContainer.GetComponent<diplomacy_container>();
            gameManager.curFactionInEffect = diplomacyRef.linkedFaction;
        }

        public void addOffer(GameObject targetOffer)
        {
            targetOffer.transform.parent = curOfferList.transform;
        }


        public void syncPlayer()
        {
            // foreach(Image)
        }

        void generateNPCicons()
        {
            if(gm.curLocation.GetComponent<locationData>().peaceful == true)
            {
                for(int i = 0; i < 10; i++)
                {
                    GameObject icon = Instantiate(npcIconBase, iconParent.transform.position, Quaternion.identity);
                    icon.transform.parent = iconParent.transform;
                }
            }
        }

        [ContextMenu("Prepare Web")]
        public void prepareWeb()
        {
            bool mul_top = false;
            bool mul_left = false;
            float pos_x = Screen.width / 2;
            float pos_y = Screen.height /2;
            float multiply_range = 10;

            Debug.Log("Web is prepared.");

            for(int i = 0; i < 50; i++)
            {
                if(mul_top)
                {
                    if(mul_left)
                    {
                        pos_x += multiply_range;
                        pos_y += multiply_range;
                        mul_left = false;
                    }
                    else
                    {
                        pos_x -= multiply_range;
                        pos_y -= multiply_range;
                        mul_left = true;
                    }

                }
                else
                {
                    if(mul_left)
                    {
                        pos_x -= multiply_range;
                        pos_y += multiply_range;
                        mul_left = false;
                    }
                    else
                    {
                        pos_x += multiply_range;
                        pos_y -= multiply_range;
                        mul_left = true;
                    }
                }
                multiply_range *= 2;

                GameObject icon = Instantiate(
                    webCharacterIcon, 
                    new Vector2(Screen.width / 2, Screen.height /2), 
                    Quaternion.identity);

                icon.transform.position = new Vector2
                (
                   pos_x, pos_y
                ); 
                icon.transform.parent = webCharParent.transform;
            }
        }

        public void quitGame()
        {
            Application.Quit();
        }

        public void muteSound()
        {
            if(sm.gameMuted)
            {
                AudioListener.pause = true;
            }
            else
            {
                AudioListener.pause = false;
            }
        }

    }

  
}
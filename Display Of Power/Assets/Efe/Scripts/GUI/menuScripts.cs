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
        GameObject gm;
        questManager qm;
        gameManager gm_ref;
        locationManager lm;
        public GameObject questName_gui;
        public GameObject questXP_gui;
        public GameObject questGold_gui;
        public GameObject questDesc_gui;

        // Diplomacy Screen
        public TextMeshProUGUI faction_name_1;
        public TextMeshProUGUI faction_name_2;

        public TextMeshProUGUI[] logTexts;

        public GameObject curOfferList;
        public GameObject curDemandList;

        [Header("Skillbar")]
        public Image[] _skillslots;

        
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GM");
            gm_ref = gm.GetComponent<gameManager>();
            qm = gm.GetComponent<questManager>();
            lm = gm.GetComponent<locationManager>();
        }

        public void enterLocation()
        {
            lm.enterLocation();
        }

        public void startQuest()
        {
            qm.startQuest(qm.questInQuestion);
            playerStats.questsInProgress.Add(qm.questInQuestion);
        }

        public void endQuest()
        {
            qm.endQuest(qm.questInQuestion);
        }

        public void succeedQuest()
        {
            qm.succeedQuest(qm.questInQuestion);
        }

        public void cancelQuest()
        {
            qm.succeedQuest(qm.questInQuestion);
        }

        public void failQuest()
        {
            qm.succeedQuest(qm.questInQuestion);
        }

        public void openGUI(GameObject GUI)
        {
            Instantiate(GUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            gameManager.curGUI = GUI;
            gm_ref.changeField("HUD");
            Debug.Log(GUI.name + " opened.");
        }

        public void closeGUI(GameObject GUI)
        {
            Destroy(GUI);
            Time.timeScale = 1;
            // gm_ref.changeState("Level");
            Debug.Log(GUI.name + " closed.");
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

    }
}
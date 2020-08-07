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
        GameObject curGUIopen;
        GameObject gm;
        questManager qm;

        locationManager lm;
        public GameObject questName_gui;
        public GameObject questXP_gui;
        public GameObject questGold_gui;
        public GameObject questDesc_gui;
        
        void Start()
        {
            gm = GameObject.FindGameObjectWithTag("GM");
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

        public void openGUI(GameObject GUI)
        {
            Instantiate(GUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            curGUIopen = GUI;
            Debug.Log(GUI.name + " opened.");
        }

        public void closeGUI(GameObject GUI)
        {
            Destroy(GUI);
            Debug.Log(GUI.name + " closed.");
        }

    }
}
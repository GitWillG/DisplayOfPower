using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using TMPro;

// needs to be called "using efe;"
namespace efe{
    public class questManager : MonoBehaviour
    {

        questItem curQuest_storyline;
        // Script reference to mouse controls
        [SerializeField]
        mouseControls_freeroam mc;
        // Script reference to gameManager
        gameManager gm;
        // Script reference to GUI manager
        GUIManager guim;
        worldMapManager wm;
        playerStats ps;
        public List<questItem> startedQuests;
        public List<questItem> availableQuests;
        public List<questItem> succeededQuests;
        public List<questItem> completedQuests;
        // Start is called before the first frame update
        void Start()
        {   
            // Does a search once to find the GM object
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
            mc = gm.GetComponent<mouseControls_freeroam>();
            guim = gm.GetComponent<GUIManager>();
            ps = gm.GetComponent<playerStats>();

            wm = GameObject.FindGameObjectWithTag("WM").GetComponent<worldMapManager>();


            
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void startQuest(questItem quest, GameObject giver)
        {
            // Debug
            Debug.Log(quest.name + " added.");
            // Add to the started quest list
            startedQuests.Add(quest);
            // Update player quest list general
            ps.questsInProgress.Add(quest);
            // Change the world based on quest parameters
            processQuest(quest);
            // Show to player what happened
            GameObject tempGUI = Instantiate(guim.questTaken_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
            tempGUI.transform.Find("Background").transform.Find("QuestName").GetComponent<TextMeshProUGUI>().text = quest.questName;
            Destroy(tempGUI, 2);

        }
        public void succeedQuest(questItem quest){
            succeededQuests.Add(quest);
            Debug.Log(quest.name + " succeeded.");

            startedQuests.Remove(quest);
        }
        public void endQuest(questItem quest){
            completedQuests.Add(quest);
            Debug.Log(quest.name + " ended.");

            succeededQuests.Remove(quest);
        }

        public void processQuest(questItem quest)
        {
            if(quest.curQuestGoalType == questItem.questGoalType.kill)
            {
                wm.generateLocation(true);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

// needs to be called "using efe;"
namespace efe{
    public class questManager : MonoBehaviour
    {

        questItem curQuest_storyline;
        // Script reference to mouse controls
        mouseControls mc;
        // Script reference to gameManager
        GameObject gm;
        // Script reference to GUI manager
        GUIManager guim;
        public questItem questInQuestion;
        public List<questItem> startedQuests;
        public List<questItem> availableQuests;
        public List<questItem> succeededQuests;
        public List<questItem> completedQuests;
        // Start is called before the first frame update
        void Start()
        {   
            // Does a search once to find the GM object
            gm = GameObject.FindGameObjectWithTag("GM");
            mc = gm.GetComponent<mouseControls>();
            guim = gm.GetComponent<GUIManager>();

            // Current quest that NPC is talking about
            questInQuestion = mc.curQuest;
            
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void startQuest(questItem quest)
        {
            Debug.Log(quest.name + " added.");
            startedQuests.Add(quest);
            GameObject tempGUI = Instantiate(guim.questTaken_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
            Destroy(tempGUI, 3);

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
                
            }
        }
    }
}

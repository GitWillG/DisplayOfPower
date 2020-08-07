using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class questManager : MonoBehaviour
{

    questItem curQuest_storyline;
    mouseControls mc;
    GameObject gm;

    GUIManager guim;

    public questItem questInQuestion;
    public List<questItem> startedQuests;
    public List<questItem> availableQuests;
    public List<questItem> succeededQuests;
    public List<questItem> endedQuests;

    

    // Start is called before the first frame update
    void Start()
    {   
        gm = GameObject.FindGameObjectWithTag("GM");
        mc = gm.GetComponent<mouseControls>();
        guim = gm.GetComponent<GUIManager>();

        questInQuestion = mc.curQuest;
        
    }

    // Update is called once per frame
    void Update()
    {
        // foreach(questItem quest in questsInProgress)
        // {
        //     // check type
        //     // check type
        // }
    }

    public void startQuest(questItem quest)
    {
        Debug.Log(quest.name + " added.");
        startedQuests.Add(quest);
        GameObject tempGUI = Instantiate(guim.questTaken_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        Destroy(tempGUI, 3);

    }
    public void succeedQuest(questItem quest){}
    public void endQuest(questItem quest){}
}

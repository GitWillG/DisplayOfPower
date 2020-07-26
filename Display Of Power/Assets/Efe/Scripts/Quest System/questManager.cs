using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{

    questItem curQuest_storyline;

    public List<questItem> questsInProgress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(questItem quest in questsInProgress)
        {
            // check type
            // check type
        }
    }

    public void startQuest(questItem quest){}
    public void succeedQuest(questItem quest){}
    public void endQuest(questItem quest){}
}

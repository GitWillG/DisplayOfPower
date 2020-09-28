using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using will;

namespace efe{

public class battleManager : MonoBehaviour
{
    public GameObject battleCam;
    public GameObject freeCam;
    

    public GameObject selectManager;
    public GameObject battleHud;
    GameObject[] battleEncounters;
    preSelection preSelect;
    gameManager gm;
    MouseControl msc;
    // public GameObject grid;
    // Start is called before the first frame update
    void Start()
    {   
        battleEncounters = GameObject.FindGameObjectsWithTag("BattleEncounter");
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
        preSelect = gm.selectionManager.GetComponent<preSelection>();
        msc = gm.selectionManager.GetComponent<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gm.curGameState == gameManager.gameStates.freeroam)
        {
            foreach(GameObject temp in battleEncounters)
            {
                // Debug.Log(temp.name);
                float distance = Vector3.Distance(gm.curAvatar.transform.position, temp.transform.position);
                if(distance < 3)
                {
                    // msc.grid.transform.position = temp.transform.position;
                    startBattle();
                    Debug.Log("Battle starts " + temp.name + " " + msc.grid.name);
                    // temp.transform.position = transform.position;
                    Destroy(temp);
                }
            }
        }
    }

    public void startBattle()
    {
        gm.curAvatar.SetActive(false);  
        // battleCam.SetActive(true);
        battleCam.gameObject.SetActive(true);
        battleCam.tag = "MainCamera";
        
        freeCam.tag = "Untagged";
        selectManager.SetActive(true);  
        battleHud.SetActive(true);


        preSelect.makeGrid();

        gm.changeState("Battle");
    }
}
}
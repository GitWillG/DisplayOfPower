using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using efe;
public class GUIManager : MonoBehaviour
{

    public GameObject HUD;
    public GameObject characterWeb;
    public GameObject dialogScreen;
    public GameObject locationMap_GUI;
    public GameObject questTaken_GUI;
    public GameObject questLog_GUI;
    public GameObject factionPage_GUI;
    public GameObject partyEntrance_GUI;
    public GameObject inventory_GUI;
    public bool isHUDopen = true;
    public GameObject battleGUI;
    public GameObject escapeMenu;
    // gameManager gm;
    GameObject HUDReference;

    public Image[] skill_slots;
    MouseControl mc;
    public Texture2D[] cursor_textures;
    
    // Start is called before the first frame update
    void Start()
    {
        // HUDReference = Instantiate(HUD, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
        // isHUDopen = true;
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
        Cursor.SetCursor(cursor_textures[0], Vector2.zero, CursorMode.Auto);

    }

    void Update()
    {
        // if(mc.selectedTarget != null)
        // {
        //     foreach(Image temp in skill_slots)
        //     {
        //         temp_skillSlot tempClass = temp.GetComponent<temp_skillSlot>();
        //         // if(!tempClass.guiChecked)
        //         // {
        //             actorData selectedData = mc.selectedTarget.GetChild(0).GetComponent<actorData>();
        //             temp.sprite = selectedData.spells[0].spellIcon;
        //             Debug.Log(selectedData + " " + temp.sprite.name);
        //             // tempClass.guiChecked = true;
        //         // }
                
        //     }
        // }
        // if(mc.selectedTarget.GetChild(0) != null)
        // {
        //     actorData selectedData = mc.selectedTarget.GetChild(0).GetComponent<actorData>();
        //     for(int i = 0; i < selectedData.spells.Length; i++)
        //     {
        //         skill_slots[i].sprite = selectedData.spells[i].spellIcon;
        //     }
        // }
        // if(Input.GetKeyDown(KeyCode.Q))
        // {
        //     openGUI(questLog_GUI);
        // }
        // if(Input.GetKeyDown(KeyCode.F))
        // {
        //     openGUI(factionPage_GUI);
        // }
        // if(Input.GetKeyDown(KeyCode.I))
        // {
        //     openGUI(inventory_GUI);
        // }
        // if(Input.GetKeyDown(KeyCode.LeftControl))
        // {
        //     if(isHUDopen)
        //     {
        //         HUDReference.SetActive(false);
        //         isHUDopen = false;
        //     }
        //     else
        //     {
        //         HUDReference.SetActive(true);
        //         isHUDopen = true;
        //     }
        // }
        // if(Input.GetKeyDown(KeyCode.L))
        // {
        //     openGUI(characterWeb);
        // }
        // if(Input.GetKeyDown(KeyCode.Escape))
        // {
        //     GameObject[] GUIs = GameObject.FindGameObjectsWithTag("GUI");
        //     if(GUIs == null)
        //     {
        //         // open escape menu
        //         openGUI(escapeMenu);
                
        //     }
        //     else
        //     {
        //         foreach(GameObject temp in GUIs)
        //         {
        //             temp.SetActive(false);
        //         }
        //     }
        // }
    }

    public void openGUI(GameObject GUI)
    {
        Instantiate(GUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
        gameManager.curGUI = GUI;
        // gm.changeField("HUD");
        Debug.Log(GUI.name + " opened.");
    }
    public void closeGUI(GameObject GUI)
    {
        Destroy(GUI);
        Time.timeScale = 1;
        // gm_ref.changeState("Level");
        // Debug.Log(GUI.name + " closed.");
    }

    public void speedTime(float time)
    {
        Time.timeScale = time;
    }

}

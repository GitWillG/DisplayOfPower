using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using efe;
using TMPro;
public class GUIManager : MonoBehaviour
{

    public GameObject HUD;
    public GameObject characterWeb;
    public GameObject dialogScreen;
    public GameObject locationMap_GUI;
    public GameObject questTaken_GUI;
    public GameObject questLog_GUI;
    public GameObject options_GUI;
    public GameObject factionPage_GUI;
    public GameObject partyEntrance_GUI;
    public GameObject inventory_GUI;
    public GameObject tooltip_skill;
    public bool isHUDopen = true;
    public GameObject battleGUI;
    public GameObject escapeMenu;
    // gameManager gm;
    GameObject HUDReference;
    spellManager sm;

    public Image[] skill_slots;
    MouseControl mc;
    public Texture2D[] cursor_textures;

    // [Range(-1000, 1000)]
    public Vector3 offsetTooltip;
    Vector2 tooltipSpawnPosition;

    public GameObject effectNotification3D_text;
    public GameObject healthBar;

    [Header("Battle Log")]
    public GameObject logAligner;
    public GameObject logText;

    [Header("Initiative Bar")]
    public GameObject initiativeSprite;
    public GameObject initiativeAligner;

    
    // Start is called before the first frame update
    void Start()
    {
        // HUDReference = Instantiate(HUD, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
        // isHUDopen = true;
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
        sm = GameObject.FindGameObjectWithTag("GM").GetComponent<spellManager>();
        Cursor.SetCursor(cursor_textures[0], Vector2.zero, CursorMode.Auto);
        // tooltip_skill = Instantiate(tooltip_skill, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        // tooltip_skill.transform.parent = battleGUI.transform;
        tooltip_skill.SetActive(false);

        // battleGUI.SetActive(false);
        offsetTooltip.x = 115;
        offsetTooltip.y = 215;


        

    }   

    // void OnGUI()
    // {
    //     GUI.Box(new Rect(0, 0, Screen.width / 8, Screen.height / 4), "This is a box");
    // }

    void Update()
    {

        // If distance of mouse and latest interacted skill icon is more than 25, hide tooltip
        if(tooltip_skill != null)
        {
            tooltip_skill.transform.position = Input.mousePosition + offsetTooltip;
            float distance = Vector2.Distance(tooltip_skill.transform.position, tooltipSpawnPosition);
            if(distance > 25)
            {
                hideTooltip();
            }
        }

        // Sync skill slots with selected actor's skills
        if(mc.lastSelectedTarget != null)
        {
            // Updates the skillbar depending on current selected actor's spells
            if(mc.lastSelectedTarget.GetChild(0) != null)
            {
                actorData selectedData = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>();
                for(int i = 0; i < selectedData.spells.Length; i++)
                {
                    skill_slots[i].sprite = selectedData.spells[i].spellIcon;
                }
            }
        }

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


        // Escape to remove any open GUI first
        // Then open escape menu if there is no GUI open
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject[] GUIs = GameObject.FindGameObjectsWithTag("GUI");
            if(GUIs.Length == 0)
            {
                // open escape menu
                openGUI(escapeMenu);
                
            }
            else
            {
                foreach(GameObject temp in GUIs)
                {
                    temp.SetActive(false);
                    
                    if(Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                    }
                }
            }
        }
    }

    public void updateLog(string logContent)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[Log]: " + logContent;

        Debug.Log("New log entered :" + textData.text);
    }
    public void updateLog(string logContent, string logType)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[" + logType + "]: " + logContent;

        Debug.Log("New log entered :" + textData.text);

        // make other legs less focused
        
    }
    public void updateLog(string logContent, string logType, Color logColor)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[" + logType + "]: " + logContent;
        textData.color = logColor;

        Debug.Log("New log entered :" + textData.text);
    }

    public void updateLog(string logContent,  Color logColor)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[Log]: " + logContent;
        textData.color = logColor;

        Debug.Log("New log entered :" + textData.text);
    }

    public void initializeHealthBars()
    {
        if(healthBar != null)
        {
            GameObject[] NPCs = GameObject.FindGameObjectsWithTag("NPC");
            foreach(GameObject temp in NPCs)
            {
                GameObject bar = Instantiate(healthBar, temp.transform.position, Quaternion.identity);
                bar.transform.parent = temp.transform;
            }
        }
    }

    

    public void openGUI(GameObject GUI)
    {
        Instantiate(GUI, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
        gameManager.curGUI = GUI;
        // gm.changeField("HUD");
        Time.timeScale = 0;
        Debug.Log(GUI.name + " opened.");
    }
    public void closeGUI(GameObject GUI)
    {
        Destroy(GUI);
        Time.timeScale = 1;
        // gm_ref.changeState("Level");
        // Debug.Log(GUI.name + " closed.");
    }

    // used for fast forwarding buttons
    public void speedTime(float time)
    {
        Time.timeScale = time;
        updateLog("Time moves " + time + " times faster.");
    }

    public void showTooltip(int index)
    {
        spellSO curSpell = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[index];
        if(curSpell != null)
        {
            tooltip_skill.SetActive(true);
            tooltipSpawnPosition = Input.mousePosition + offsetTooltip;
            // Debug.Log("Showing tooltip..." + index);

            tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = curSpell.spellName;
            if(curSpell.SkillTargetHandling == spellSO.targetHandling.area)
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Area";
            }
            else
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Single";
            }
            
            // change the damage type depending on type of effect spell has
            if(curSpell.effectType == spellSO.effectTypes.substractive)
            {
                tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "Damage";
            }
            else
            {
                tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "Heal";
            }

            tooltip_skill.transform.Find("BG").transform.Find("DamageResult").GetComponent<TextMeshProUGUI>().text = curSpell.effectAmount.ToString();
            
            // Sync the GUI with spell manager
            sm.curIndexCallback = index;
        }
        else
        {
            tooltip_skill.SetActive(false);
            return;
        }
        
    
    }

    public void hideTooltip()
    {
        if(tooltip_skill.activeInHierarchy)
        {
            tooltip_skill.SetActive(false);
            Debug.Log("Tooltip hidden...");
        }
    }

}

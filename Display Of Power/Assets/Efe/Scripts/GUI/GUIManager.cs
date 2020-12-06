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
    public GenerateGrid gg;
    public Texture2D[] cursor_textures;

    // [Range(-1000, 1000)]
    public Vector3 offsetTooltip;
    Vector2 tooltipSpawnPosition;

    public GameObject effectNotification3D_text;
    public GameObject healthBar;

    [Header("Battle Log")]
    public GameObject logAligner;
    public GameObject logText;

    public GameObject debugTools;
    public Sprite defaultSlot;
    public GameObject spellCooldownNote;

    public Image[] stanceIcons;

    public GameObject statusAligner;
    public GameObject statusSprite;
    public List<GameObject> tempStatusSprites;

    public List<GameObject> overheadBars;
    public bool hideOverhead = true;

    public Slider bottomHealthBar;
    public TextMeshProUGUI curHP;
    public TextMeshProUGUI maxHP;
    public TextMeshProUGUI slash;

    Color originalColor;



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
        offsetTooltip.y = 615;

        originalColor = bottomHealthBar.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color;




    }   

    // void OnGUI()
    // {
    //     GUI.Box(new Rect(0, 0, Screen.width / 8, Screen.height / 4), "This is a box");
    // }


    public void syncBottomHP()
    {

        if (mc.lastSelectedTarget == null) return;

        if (mc.lastSelectedTarget.childCount > 0)
        {
            actorData data = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>();
            bottomHealthBar.value = data.Life;
            bottomHealthBar.maxValue = data.maxLife;
            curHP.text = data.Life.ToString();
            maxHP.text = data.maxLife.ToString();
            slash.text = "/";
            bottomHealthBar.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = originalColor;

            if(data.ownerFaction_string == "Ally")
            {
                bottomHealthBar.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = Color.blue;
            }
        }
        else
        {
            bottomHealthBar.value = 0;
            bottomHealthBar.maxValue = 0;
            curHP.text = "";
            maxHP.text = "";
            slash.text = "";

            bottomHealthBar.transform.Find("Fill Area").transform.Find("Fill").GetComponent<Image>().color = Color.gray;
        }
    }

    void Update()
    {
        syncSkillBar();
        syncStatusBar();
        syncBottomHP();
                                                                     

        // If distance of mouse and latest interacted skill icon is more than 25, hide tooltip
        if (tooltip_skill != null)
        {
            tooltip_skill.transform.position = Input.mousePosition + offsetTooltip;
            float distance = Vector2.Distance(tooltip_skill.transform.position, tooltipSpawnPosition);
            if(distance > 50)
            {
                hideTooltip();
            }
        }

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D))
        {
            if(debugTools.activeInHierarchy)
            {
                debugTools.SetActive(false);
                updateLog("Debug tools closed.");
            }
            else
            {
                debugTools.SetActive(true);
                updateLog("Debug tools opened.");
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if(hideOverhead)
            {
                hideOverhead = false;
                foreach(GameObject N in overheadBars)
                {
                    N.SetActive(false);
                }
            }
            else
            {
                hideOverhead = true;
                foreach (GameObject N in overheadBars)
                {
                    N.SetActive(true);
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


        //  Escape to remove any open GUI first
        //  Then open escape menu if there is no GUI open
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameObject[] GUIs = GameObject.FindGameObjectsWithTag("GUI");
            if (GUIs.Length == 0)
            {
                // open escape menu
                openGUI(escapeMenu);

            }
            else
            {
                foreach (GameObject temp in GUIs)
                {
                    temp.SetActive(false);

                    if (Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                    }
                }
            }
        }
    }


    void syncStatusBar()
    {
        // Updates the skillbar depending on current selected actor's spells
        if (mc.selectedTarget == null) return;
        if (mc.lastSelectedTarget == null) return;
        if (mc.lastSelectedTarget.childCount == 0) return;
        if (mc.lastSelectedTarget.GetChild(0) == null) return;

        actorData data = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>();


        // Reset
        foreach(GameObject N in tempStatusSprites)
        {
            Destroy(N);
        }

        if (data.statuses.Count == 0) return;
        // Add
        for (int z = 0; z < data.statuses.Count; z++)
        {
            GameObject S = Instantiate(statusSprite, statusAligner.transform.position, Quaternion.identity);
            S.transform.parent = statusAligner.transform;
            S.GetComponent<Image>().sprite = data.statuses[z].spellIcon;
            tempStatusSprites.Add(S);
        }
    }

    void syncSkillBar()
    {   
        // if(mc.isMoving) return;
        // Sync skill slots with selected actor's skills
        // if(mc.lastSelectedTarget == null) return;
        // Clear the skill slot when nothing is selected


        // Reset everytime
        for(int o = 0; o < skill_slots.Length; o++)
        {
            skill_slots[o].sprite = defaultSlot;
         
        }


        // Updates the skillbar depending on current selected actor's spells
        if (mc.selectedTarget == null) return;
        if (mc.lastSelectedTarget == null) return;
        if (mc.lastSelectedTarget.childCount == 0) return;
        if (mc.lastSelectedTarget.GetChild(0) == null) return;
        
        actorData selectedData = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>();

        // Dont update the skill bar if enemy is selected
        if (selectedData.ownerFaction_string == "Enemy") return;

        if (selectedData.spells.Length == 0) return;
        // Put the spell icons on the bar
        for (int i = 0; i < selectedData.spells.Length; i++)
        {
            
            skill_slots[i].sprite = selectedData.spells[i].spellIcon;
            if (!mc.selectedTarget.transform.GetChild(0).GetComponent<actorData>().isTurn)
            {
                skill_slots[i].color = Color.gray;
                
            }
            else if(mc.selectedTarget.transform.GetChild(0).GetComponent<actorData>().isTurn)
            {
                skill_slots[i].color = Color.white;
                
            }

            //if(selectedData.cooldownCounters[i] > 0)
            //{
            //    temp = Instantiate(cooldownGUI, skill_slots[i].transform.position, Quaternion.identity);
            //    cooldownGUIs.Add(temp);
            //}
            //else if (selectedData.cooldownCounters[i] == 0)
            //{
            //    cooldownGUIs.Remove(temp);
            //}

            // Sync the cooldown by putting the cooldown image on top of them lol
            // if(selectedData.cooldownCounters[i] > 0)
            // {
            //     GameObject temp = Instantiate(spellCooldownNote, skill_slots[i].transform);
            //     temp.transform.Find("CooldownNote").transform.Find("CooldownCounter").GetComponent<TextMeshProUGUI>().text = 
            //     selectedData.cooldownCounters[i].ToString();
            // }
        }

    }

    public void resetSkillBar()
    {
        foreach(Image t in skill_slots)
        {
            t.sprite = defaultSlot;
        }
    }
    public void updateLog(string logContent)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[Log]: " + logContent;

        // Debug.Log("New log entered :" + textData.text);
    }
    public void updateLog(string logContent, string logType)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[" + logType + "]: " + logContent;

        // Debug.Log("New log entered :" + textData.text);

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

        // Debug.Log("New log entered :" + textData.text);
    }

    public void updateLog(string logContent,  Color logColor)
    {
        GameObject tempLog = Instantiate(logText, logAligner.transform);
        tempLog.transform.parent = logAligner.transform;
        tempLog.transform.SetAsFirstSibling();

        TextMeshProUGUI textData = tempLog.GetComponent<TextMeshProUGUI>();
        textData.text = "[Log]: " + logContent;
        textData.color = logColor;

        // Debug.Log("New log entered :" + textData.text);
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

    public void closeGUInoTime(GameObject GUI)
    {
        Destroy(GUI);
    }

    // used for fast forwarding buttons
    public void speedTime(float time)
    {
        Time.timeScale = time;
        if(time == 0)
        {
            updateLog("Game is paused.");
        }
        else
        {
            updateLog("Time moves " + time + " times faster.");
        }
        
    }

    public void showTooltip(int index)
    {
        if (mc.lastSelectedTarget.childCount == 0) return;
        if (mc.lastSelectedTarget.GetChild(0) == null) return;
        if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells.Length == 0) return;
        if (index > mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells.Length) return;
        //if (mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[index] == null) return;

        spellSO curSpell = mc.lastSelectedTarget.GetChild(0).GetComponent<actorData>().spells[index];
        if (curSpell != null)
        {
            tooltip_skill.SetActive(true);
            tooltipSpawnPosition = Input.mousePosition + offsetTooltip;
            // Debug.Log("Showing tooltip..." + index);

            tooltip_skill.transform.Find("BG").transform.Find("SpellDesc").GetComponent<TextMeshProUGUI>().text = curSpell.spellDescription;
            tooltip_skill.transform.Find("BG").transform.Find("SpellAP").GetComponent<TextMeshProUGUI>().text = curSpell.actionNeeded.ToString();
            tooltip_skill.transform.Find("BG").transform.Find("Type").GetComponent<TextMeshProUGUI>().text = "Type";
            tooltip_skill.transform.Find("BG").transform.Find("ActionPoints").GetComponent<TextMeshProUGUI>().text = "Action Points";

            tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = curSpell.spellName;
            if(curSpell.SkillTargetHandling == spellSO.targetHandling.area)
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Area";
            }
            else if(curSpell.SkillTargetHandling == spellSO.targetHandling.single)
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Single";
            }
            else if(curSpell.SkillTargetHandling == spellSO.targetHandling.selfaround)
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Self-AOE";
            }
            else if(curSpell.SkillTargetHandling == spellSO.targetHandling.self)
            {
                tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "Self";
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

    public void showTooltipStances(int index)
    {

        tooltip_skill.SetActive(true);
        tooltipSpawnPosition = Input.mousePosition + offsetTooltip;
        if (index == 0)
        {
            
                
            tooltip_skill.transform.Find("BG").transform.Find("ActionPoints").GetComponent<TextMeshProUGUI>().text = "Switch between movement and attacking mode. " +
                "   " +
                "Damage: " + mc.selectedTarget.GetChild(0).GetComponent<actorData>().baseDamage;
            tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = "Attack";
            tooltip_skill.transform.Find("BG").transform.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellAP").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("DamageResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellDesc").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("-").GetComponent<TextMeshProUGUI>().text = "";
        }
        else if(index == 1)
        {
            tooltip_skill.transform.Find("BG").transform.Find("ActionPoints").GetComponent<TextMeshProUGUI>().text = "Consumes 1 action point. " +
                "This stance makes the actor switch to a defensive stance. While in this stance, you take %50 less damage.";
            tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = "Defend";
            tooltip_skill.transform.Find("BG").transform.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellAP").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("DamageResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellDesc").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("-").GetComponent<TextMeshProUGUI>().text = "";
        }
        else if (index == 2)
        {
            tooltip_skill.transform.Find("BG").transform.Find("ActionPoints").GetComponent<TextMeshProUGUI>().text = "Watch over a targetted zone of the battlefield. When enemies enter the targetted zone, they will be attacked by a strengthened auto attack dealing 30 damage";
            tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = "Offense";
            tooltip_skill.transform.Find("BG").transform.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellAP").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("DamageResult").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("SpellDesc").GetComponent<TextMeshProUGUI>().text = "";
            tooltip_skill.transform.Find("BG").transform.Find("-").GetComponent<TextMeshProUGUI>().text = "";
        }


    }



    public void showRelicTooltip()
    {

        tooltip_skill.SetActive(true);
        tooltipSpawnPosition = Input.mousePosition + offsetTooltip;
 
        tooltip_skill.transform.Find("BG").transform.Find("ActionPoints").GetComponent<TextMeshProUGUI>().text = "Use to attack enemies.";
        tooltip_skill.transform.Find("BG").transform.Find("SpellName").GetComponent<TextMeshProUGUI>().text = "Attack";
        tooltip_skill.transform.Find("BG").transform.Find("Type").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("SpellAP").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("TypeResult").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("Damage").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("DamageResult").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("SpellDesc").GetComponent<TextMeshProUGUI>().text = "";
        tooltip_skill.transform.Find("BG").transform.Find("-").GetComponent<TextMeshProUGUI>().text = "";



    }

    public void hideTooltip()
    {
        if(tooltip_skill.activeInHierarchy)
        {
            tooltip_skill.SetActive(false);
            // Debug.Log("Tooltip hidden...");
        }
    }

}

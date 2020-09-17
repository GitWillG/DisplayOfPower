using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using TMPro;

public class logManager : MonoBehaviour
{
    GameObject HUD;
    menuScripts scriptsMenu;
    // Start is called before the first frame update
    void Start()
    {
        HUD = GameObject.FindGameObjectWithTag("HUD");
        scriptsMenu = HUD.GetComponent<menuScripts>();
    }

    // Update is called once per frame
    void Update()
    {
        // foreach(TextMeshProUGUI temp in scriptsMenu.logTexts)
        // {

        // }
    }

    public void updateLog(string Text)
    {

    }
}

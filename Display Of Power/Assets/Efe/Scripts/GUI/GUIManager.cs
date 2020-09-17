﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public GameObject HUD;
    public GameObject dialogScreen;
    public GameObject locationMap_GUI;
    public GameObject questTaken_GUI;
    public GameObject questLog_GUI;
    public GameObject factionPage_GUI;
    public GameObject partyEntrance_GUI;
    public GameObject inventory_GUI;
    public bool isHUDopen = true;
    public GameObject battleGUI;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(HUD, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(questLog_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(factionPage_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(inventory_GUI, new Vector2(Screen.width / 2, Screen.height / 2), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            if(isHUDopen)
            {
                HUD.SetActive(false);
                isHUDopen = false;
            }
            else
            {
                HUD.SetActive(true);
                isHUDopen = true;
            }
        }
    }

}

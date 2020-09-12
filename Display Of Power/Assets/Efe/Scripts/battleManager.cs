using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleManager : MonoBehaviour
{
    GameObject[] battleEncounters;
    // Start is called before the first frame update
    void Start()
    {   
        battleEncounters = GameObject.FindGameObjectsWithTag("BattleEncounter");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

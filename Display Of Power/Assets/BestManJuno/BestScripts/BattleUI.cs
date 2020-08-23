using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour
{
    public int k;
    public TMP_Text stats;
    public GenerateGrid generateGrid;
    public prefabUnits prefUnits;
    public MouseControl mouseControl;

    private void Start()
    {
        generateGrid = GetComponent<GenerateGrid>();        
        mouseControl = GetComponent<MouseControl>();
    }

    public void EndTurn()
    {

        //turnOrder[k].GetComponent<prefabUnits>().actionsRemaining = 0;
    }

    public void DisplayStats(GameObject unitSelected)
    {
        unitSelected = mouseControl.selectedTarget.GetChild(0).gameObject;
        prefUnits = unitSelected.GetComponent<prefabUnits>();
        stats.text = "Faction" + prefUnits.Factions + "\n" + "Health" + prefUnits.Life + "\n" + "Strength" + prefUnits.Damage + "\n" + "Attack Range" + prefUnits.AttackRange + "\n" + "Movement Range" + prefUnits.MovementRange + "\n" + "Moves Remaining" + prefUnits.actionsRemaining;
    }

}

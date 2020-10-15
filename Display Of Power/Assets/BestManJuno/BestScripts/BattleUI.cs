using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using will;
using efe;

namespace will{

public class BattleUI : MonoBehaviour
{
    public int k;
    public TMP_Text stats;
    public GenerateGrid generateGrid;
    public actorData prefUnits;
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
        prefUnits = unitSelected.GetComponent<actorData>();
        stats.text = 
        "Faction" + prefUnits.ownerFaction_string + 
        "\n" + "Health" + prefUnits.Life + 
        "\n" + "Strength" + prefUnits.baseDamage + 
        "\n" + "Attack Range" + prefUnits.AttackRange + 
        "\n" + "Movement Range" + prefUnits.MovementRange + 
        "\n" + "Moves Remaining" + prefUnits.actionsRemaining;
    }

}
}
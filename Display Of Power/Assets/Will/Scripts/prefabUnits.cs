using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabUnits : MonoBehaviour
{
    public SO_Units statObject;
    public int Life;
    public int MovementRange;
    public string POName;
    public int Damage;
    public int AttackRange;
    public int TotalActions;
    public int actionsRemaining;
    public bool isTurn;
    // Start is called before the first frame update
    void Start()
    {
        MovementRange = statObject.movementRange;
        POName = statObject.SOname;
        AttackRange = statObject.attackRange;
        Life = statObject.life;
        Damage = statObject.damage;
        TotalActions = statObject.totalActions;
        actionsRemaining = statObject.actionsRemaining;
    }

}

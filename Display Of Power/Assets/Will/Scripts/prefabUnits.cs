﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabUnits : MonoBehaviour
{
    public SO_Units statObject;
    public int Life;
    public int MovementRange;
    public string Factions;
    public string POName;
    public int Damage;
    public int AttackRange;
    public int TotalActions;
    public int actionsRemaining;
    public bool isTurn;
    public bool belongsToPlayer;
    // public enum teams {playerTeam, enemyTeam}
    // public teams curTeam;
    // Start is called before the first frame update
    void Start()
    {
        Factions = statObject.faction;
        MovementRange = statObject.movementRange;
        POName = statObject.SOname;
        AttackRange = statObject.attackRange;
        Life = statObject.life;
        Damage = statObject.damage;
        TotalActions = statObject.totalActions;
        actionsRemaining = statObject.actionsRemaining;

        statObject.life = 10;
    }

}

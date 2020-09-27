using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Unit", menuName ="Unit")]
public class SO_Units : ScriptableObject
{
    public string SOname;
    public int life;
    public int damage;
    public string faction;
    public int attackRange;
    public int movementRange;
    public int totalActions;
    public int actionsRemaining;
    public GameObject prefabObj;
    public GameObject menuItem;
}

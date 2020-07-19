using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Unit", menuName ="Unit")]
public class SO_Units : ScriptableObject
{
    public string name;
    public string faction;
    public int attackRange;
    public int movementRange;
}

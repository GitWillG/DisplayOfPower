using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a new quest")]
public class questItem : ScriptableObject
{
    public string questName;

    public enum questType { daily, regular, storyline}
    public questType curType;

    public enum status {availale, started, succeeded, ended}

    public float gold;
    public int xp;
}

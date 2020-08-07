using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create a new quest")]
public class questItem : ScriptableObject
{
    public string questName;
    public string questDesc;
    public enum questType { daily, regular, storyline}
    public questType curType;
    public enum status {availale, started, succeeded, ended}
    public float questGold;
    public int questXp;
    public GameObject[] targetObject;
    public GameObject targetAmount;

}

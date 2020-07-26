using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actorData : MonoBehaviour
{
    public string actorName;
    public List<questItem> availableQuests;

    public bool peaceful; // false = unit

    public GameObject targetObjective;
    public int targetAmount;

    // 20 bandits

    public float xp;
    public int gold;
}

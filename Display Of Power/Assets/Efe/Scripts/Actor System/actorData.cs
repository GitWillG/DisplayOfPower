using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class actorData : MonoBehaviour
{
    public string actorName;
    public List<questItem> actorQuests;
    public bool peaceful; // false = unit
    


    [ContextMenu("Sync Editor")]
    public void syncEditor()
    {
        this.gameObject.name = actorName;
        // Object reference = Resources.FindObjectsOfTypeAll
    }
}

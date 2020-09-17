using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

// needs to be called "using efe;"
namespace efe
{
    [CreateAssetMenu(menuName = "Factions/Create a new faction")]
    public class factionSO : ScriptableObject
    {
        public float factionID;
        public string factionName;

    }
}

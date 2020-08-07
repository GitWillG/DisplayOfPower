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
    public List<diplomacy> allies;
    public List<diplomacy> enemies;
    public List<diplomacy> neutral; 
    public class diplomacy : factionSO
    {
        public factionSO targetFaction;
        public int currentStanding;
        public void setDiplomacy(factionSO target, int amount)
        {
            currentStanding += amount;
        }
    }
    }
}

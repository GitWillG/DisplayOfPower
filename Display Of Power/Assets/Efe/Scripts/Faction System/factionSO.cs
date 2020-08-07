using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace efe
{

    [CreateAssetMenu(menuName = "Factions/Create")]
    public class factionSO : ScriptableObject
    {
    
    public List<diplomacy> allies;
    public List<diplomacy> enemies;
    public List<diplomacy> neutral; 

    public class diplomacy : factionSO
    {
        public factionSO targetFaction;
        public int currentStanding;

        public void changeStatus(factionSO target, int amount)
        {
            currentStanding += amount;
        }
    }
    }
}

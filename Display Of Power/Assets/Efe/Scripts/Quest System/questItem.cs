using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

// needs to be called "using efe;"
namespace efe
{
    [CreateAssetMenu(menuName = "Quests/Create a new quest")]
    public class questItem : ScriptableObject
    {
        // used for future
        public int questID;
        public string questName;
        public string questDesc;
        public enum questType { daily, regular, storyline}
        public questType curType;
        public enum status {availale, started, succeeded, ended}
        public float questGold;
        public int questXp;
        public GameObject[] targetObject;
        public GameObject targetAmount;
        public enum rewardType {diplomacy, xp, unit, heroes, relics, pointsInterest, currency, stats, lore}
        public rewardType curReward;

    }
}
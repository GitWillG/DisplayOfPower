using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{

    public class playerStats : MonoBehaviour
    {
        [SerializeField]
        public static List<questItem> questsInProgress;

        public float playerGold;
        public factionSO playerFaction;
        public float curXP_avatar;
        public float xpRequiredForNextLevel_avatar;
        
    }
}
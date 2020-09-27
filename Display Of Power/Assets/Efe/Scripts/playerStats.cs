using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe {

    public class playerStats : MonoBehaviour
    {
        public string playerName;
        public List<questItem> questsInProgress;
        public float playerGold;
        public factionSO playerFaction;
        public float avatarXP;
        float xpRequiredForNextLevel_avatar;
        public float avatarLevel;

        public void addXP(float amount)
        {
            avatarXP += amount;
            Debug.Log(amount + " XP earned.");
            if(avatarXP > xpRequiredForNextLevel_avatar)
            {
                avatarLevel++;
                xpRequiredForNextLevel_avatar *= xpRequiredForNextLevel_avatar * 2;
                Debug.Log("Your avatar leveled up.");
            }
        }

        public void addGold(float amount)
        {
            playerGold += amount;
            Debug.Log(amount + " gold added.");
        }
        
    }
}
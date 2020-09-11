using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe {

    public class partyData : MonoBehaviour
    {
        
        public List<actorData> partyMembers;
        public string partyName;

        // Start is called before the first frame update
        public void addPartyMember(partyData targetParty, actorData targetUnit, int amount)
        {
            if(amount == 0)
            {
                return;
            }
            
            for(int i = 0; i < amount; i++)
            {
                targetParty.partyMembers.Add(targetUnit);
                Debug.Log(targetParty.partyName + " received " + amount + " " + targetUnit.actorName);
            }
        }
    }
}
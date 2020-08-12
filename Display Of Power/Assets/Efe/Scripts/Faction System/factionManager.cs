using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace efe
{
    public class factionManager : MonoBehaviour
    {
        // Stores all factions in the game
        public List<factionSO> allFactions;
        factionSO faction_1, faction_2;
        void Awake()
        {
            Object[] resource_factions = Resources.LoadAll("Factions", typeof(factionSO));
            foreach(factionSO curResource in resource_factions)
            {
                allFactions.Add(curResource);
                // Debug.Log(curResource.factionName);
            }
            foreach(factionSO faction in allFactions)
            {
                faction.temp_factions = allFactions;
                for(int i = 0; i < allFactions.Count; i++)
                {
                    faction.temp_relations.Add(0);
                }
                
            }


        }
        void Start()
        {   

            // Debug.Log(allFactions.Count);
            // setDiplomacyByReference(allFactions[0], allFactions[1], 0);
            // call script to set int value between target and source between -100 and 100
            // sourcefaction, targetfaction, value
            // factionso will store the value in a list of integers that equals to a list of factions 
            // that each factionso also hold in themselves which they pull from factionmanager here
        }

        public void setDiplomacyByReference(factionSO sourceFaction, factionSO targetFaction, int amount)
        {
            
            int[] targetIndexes = {0, 0};
            // Find the source faction in allfaction list and save its index
            foreach(factionSO loop_1 in allFactions)
            {
                if(sourceFaction == loop_1)
                {
                    faction_1 = loop_1;
                    targetIndexes[0] = allFactions.IndexOf(sourceFaction);
                }
                // Go through second loop to find the target reference
                // Find the target faction in allfaction list and save its index
                foreach(factionSO loop_2 in allFactions)
                {
                        if(targetFaction == loop_2)
                        {
                        faction_2 = loop_2;
                        targetIndexes[1] = allFactions.IndexOf(targetFaction);
                        }
                        // Go through relations list and find the same index of faction_2 relation with faction 1
                        faction_1.temp_relations[targetIndexes[0]] = amount;
                    
                }
            }
        }
    }
}
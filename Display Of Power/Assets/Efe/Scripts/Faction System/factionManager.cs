using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace efe
{
    public class factionManager : MonoBehaviour
    {
        
        public List<int> factionRelations;
        int factionIndex;
        int curValue;
        int targetIndex;
        int minClamp;
        int maxClamp;
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

            // // Relations - int
            // foreach(factionSO faction in allFactions)
            // {
            //     faction.temp_factions = allFactions;
            //     for(int i = 0; i < allFactions.Count; i++)
            //     {
            //         faction.temp_relations.Add(0);
            //     } 
            // }
        }


        void Start()
        {   
            intializeDiplomacy();
            // Debug.Log(allFactions.Count);
            // setDiplomacyByReference(allFactions[0], allFactions[1], 0);
            // call script to set int value between target and source between -100 and 100
            // sourcefaction, targetfaction, value
            // factionso will store the value in a list of integers that equals to a list of factions 
            // that each factionso also hold in themselves which they pull from factionmanager here
        }


        public void intializeDiplomacy()
        {
            for(int i = 0; i < 21; i++)
            {
                factionRelations.Add(0);
            }
        }

        public void changeDiplomacyByReference(factionSO factionReference_1, factionSO factionReference_2, int value)
        {   
            
            // FIRE CITY
            if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "Water City")
            {
                targetIndex = 0;
            }
            else if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "Earth City")
            {
                targetIndex = 1;
            }
            else if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "Pahro")
            {
                targetIndex = 2;
            }
            else if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "City of Adventurers")
            {
                targetIndex = 3;
            }
            else if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 4;
            }
            else if(factionReference_1.factionName == "Fire City" && factionReference_2.factionName == "Fearless")
            {
                targetIndex = 5;
            }
            // WATER CITY
            else if(factionReference_1.factionName == "Water City" && factionReference_2.factionName == "Earth City")
            {
                targetIndex = 6;
            }
            else if(factionReference_1.factionName == "Water City" && factionReference_2.factionName == "Pahro")
            {
                targetIndex = 7;
            }
            else if(factionReference_1.factionName == "Water City" && factionReference_2.factionName == "City of Adventurers")
            {
                targetIndex = 8;
            }
            else if(factionReference_1.factionName == "Water City" && factionReference_2.factionName == "Fearless")
            {
                targetIndex = 9;
            }
            else if(factionReference_1.factionName == "Water City" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 10;
            }
            // PAHRO
            else if(factionReference_1.factionName == "Pahro" && factionReference_2.factionName == "City of Adventurers")
            {
                targetIndex = 11;
            }
            else if(factionReference_1.factionName == "Pahro" && factionReference_2.factionName == "Fearless")
            {
                targetIndex = 12;
            }
            else if(factionReference_1.factionName == "Pahro" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 13;
            }
            else if(factionReference_1.factionName == "Pahro" && factionReference_2.factionName == "Earth City")
            {
                targetIndex = 14;
            }
            // EARTH CITY
            else if(factionReference_1.factionName == "Earth City" && factionReference_2.factionName == "City of Adventurers")
            {
                targetIndex = 15;
            }
            else if(factionReference_1.factionName == "Earth City" && factionReference_2.factionName == "Fearless")
            {
                targetIndex = 16;
            }
            else if(factionReference_1.factionName == "Earth City" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 17;
            }
            // City of Adventurers
            else if(factionReference_1.factionName == "City of Adventurers" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 18;
            }
            else if(factionReference_1.factionName == "City of Adventurers" && factionReference_2.factionName == "Fearless")
            {
                targetIndex = 19;
            }
            // Fearless
            else if(factionReference_1.factionName == "Fearless" && factionReference_2.factionName == "Player Faction")
            {
                targetIndex = 20;
            }
            else
            {
                Debug.Log("No match found.");
                return;
            }

            if(value > 0)
            {
                curValue += value;
            }
            else
            {
                curValue -= value;
            }
            
            // Debug.Log("Relationship between " + factionReference_1.factionName + " and " + factionReference_2.factionName + " is " + curValue);
            factionRelations[targetIndex] = curValue;
            
        }
        public void changeDiplomacyByString(string sourceText, int value)
        {
            
            if(sourceText == "Fire City Water City")
            {   
                targetIndex = 0;
            }
            else if(sourceText == "Fire City Fearless")
            {
                targetIndex = 1;
            }
            else if(sourceText == "Fire City City of Adventurers")
            {
                targetIndex = 2;
            }
            else if(sourceText == "Fire City Earth City")
            {
                targetIndex = 3;
            }
            else if(sourceText == "Fire City Pahro")
            {
                targetIndex = 4;
            }
            else if(sourceText == "Fire City Player Faction")
            {
                targetIndex = 5;
            }
            
            if(value > 0)
            {
                curValue += value;
            }
            else
            {
                curValue -= value;
            }
            
            Debug.Log(sourceText + " relationship is " + curValue);
            factionRelations[targetIndex] = curValue;
        }

        public void addDiplomacy(int indexReference, int value)
        {
            int curValue = factionRelations[targetIndex];
            curValue += value;
            factionRelations[indexReference] = curValue;
        }
        public void subDiplomacy(int indexReference, int value)
        {
            int curValue = factionRelations[indexReference];
            curValue -= value;
            factionRelations[indexReference] = curValue;
        }

        public void setDiplomacy(int indexReference, int value)
        {
             factionRelations[indexReference] = value;
        }

        int checkDiplomacy(int indexReference)
        {
            Debug.Log(factionRelations[indexReference]);
            return factionRelations[indexReference];

        }

        // public void setDiplomacyByReference(factionSO sourceFaction, factionSO targetFaction, int amount)
        // {
            
        //     int[] targetIndexes = {0, 0};
        //     // Find the source faction in allfaction list and save its index
        //     foreach(factionSO loop_1 in allFactions)
        //     {
        //         if(sourceFaction == loop_1)
        //         {
        //             faction_1 = loop_1;
        //             targetIndexes[0] = allFactions.IndexOf(sourceFaction);
        //         }
        //         // Go through second loop to find the target reference
        //         // Find the target faction in allfaction list and save its index
        //         foreach(factionSO loop_2 in allFactions)
        //         {
        //                 if(targetFaction == loop_2)
        //                 {
        //                     faction_2 = loop_2;
        //                     targetIndexes[1] = allFactions.IndexOf(targetFaction);
        //                 }
        //                 // Go through relations list and find the same index of faction_2 relation with faction 1
        //                 faction_1.temp_relations[targetIndexes[0]] = amount;
                    
        //         }
        //     }
        // }
    }
}
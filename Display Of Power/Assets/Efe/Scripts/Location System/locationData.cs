using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

// needs to be called "using efe;"
namespace efe{
    public class locationData : MonoBehaviour
    {
        public string locationName;
        public GameObject locationEntry;
        public actorData[] NPCsLocation;
        public factionSO ownerFaction;
        public enum type{generated, manual}
        public type curLocType;
        public bool isBattleOnly;
        public bool peaceful;
        public GameObject levelReference;

    }
}
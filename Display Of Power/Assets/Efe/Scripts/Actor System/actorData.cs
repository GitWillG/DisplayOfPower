using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;

// needs to be called "using efe;"
namespace efe{
    public class actorData : MonoBehaviour
    {
        public string actorName;
        public List<questItem> actorQuests;
        public bool walkAround;
        public bool peaceful; // false = unit
        public enum locationList {waterCity, Pahro}
        public locationList actorLocation;
        public GameObject[] locationArray;
        public int curIndex;
        public int actorEntryPoint;

        NavMeshAgent agent;
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            locationArray = GameObject.FindGameObjectsWithTag("Location");
            if(actorLocation == locationList.waterCity)
            {
                
            }
            else if(actorLocation == locationList.Pahro)
            {

            }
            // Debug.Log(this.name + " will spawn in " + actorEntryPoint + " " + actorLocation.locationName);

            if(peaceful)
            {
                agent.speed = 1;
            }
        }

        [ContextMenu("Sync Editor")]
        public void syncEditor()
        {
            this.gameObject.name = actorName;
            // Object reference = Resources.FindObjectsOfTypeAll
        }
    }
}
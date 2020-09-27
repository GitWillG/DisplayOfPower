using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;

namespace efe{
    public class locationManager : MonoBehaviour
    {
        public List<locationData> locations;
        public GameObject[] location_presets;
        gameManager gm;

        void Start()
        {
            gm = GetComponent<gameManager>();
        }

        public void enterLocation(bool levelGenerated)
        {
            gm.levelAvatar.GetComponent<NavMeshAgent>().enabled = false;
            gm.levelAvatar.transform.position = gm.curLocation.GetComponent<locationData>().locationEntry.transform.position;
            gm.levelAvatar.GetComponent<NavMeshAgent>().enabled = true;

            Debug.Log("Entered the " + gm.curLocation.name);
            gm.changeField("Level");

        }

        public void leaveLocation()
        {
            gm.changeField("World");
        }

    }
}
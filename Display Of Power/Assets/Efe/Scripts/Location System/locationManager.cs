using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    public class locationManager : MonoBehaviour
    {
        public List<locationData> locations;
        gameManager gm;

        void Start()
        {
            gm = GetComponent<gameManager>();
        }

        public void enterLocation()
        {
            gm.levelAvatar.transform.position = gm.curLocation.GetComponent<locationData>().locationEntry.transform.position;
            gm.changeField("Level");
            Debug.Log(gm.curLocation.GetComponent<locationData>().locationName);

        }
    }
}
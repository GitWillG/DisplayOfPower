using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    public class worldMapManager : MonoBehaviour
    {

        GameObject[] towers;
        float tower_distance_shoot;
        public GameObject gmObj;
        gameManager gm;
        GameObject avatar;

        // Start is called before the first frame update
        void Start()
        {
            towers = GameObject.FindGameObjectsWithTag("Tower");
            gm = gmObj.GetComponent<gameManager>();

            avatar = gm.curAvatar;
            tower_distance_shoot = 3;
        }

        // Update is called once per frame
        void Update()
        {
            if(gm.curPlayfield == gameManager.playfields.onWorld)
            {
                foreach(GameObject tower in towers)
                {
                    if(tower != null)
                    {
                        float distance = Vector3.Distance(avatar.transform.position, tower.transform.position);
                        if(distance < tower_distance_shoot)
                        {
                            Debug.Log("Tower is damaging.");
                        }
                    }
                }
            }
        }

        public void generateBattleLocation(locationData location)
        {
            
        }
    }
}
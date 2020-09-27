using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe{
    public class worldMapManager : MonoBehaviour
    {

        GameObject[] towers;
        float tower_distance_shoot;
        gameManager gm;
        locationManager lm;
        GameObject avatar;
        public GameObject baseLocationTemplate;
        public GameObject[] locationSpawnPoints;
        public GameObject banditCamp;
        // Start is called before the first frame update
        void Start()
        {
            towers = GameObject.FindGameObjectsWithTag("Tower");
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<gameManager>();
            lm = gm.GetComponent<locationManager>();

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

        public void generateLocation(bool isBattle)
        {
            foreach(GameObject temp in locationSpawnPoints)
            {
                // int dice = Random.Range(0, 2);
                // if(dice == 0)
                // {
                    GameObject newSpawn = Instantiate(baseLocationTemplate, temp.transform.position, Quaternion.identity);
                    locationData data = newSpawn.GetComponent<locationData>();
                    if(isBattle)
                    {
                        data.isBattleOnly = true;
                        data.peaceful = false;
                        data.curLocType = locationData.type.generated;
                        // data.locationEntry = 
                        // // GameObject banditCamp = Instantiate(lm.location_presets[0], transform.position, Quaternion.identity);
                        // banditCamp.transform.position = 
                        // new Vector3(
                        //     banditCamp.transform.position.x,
                        //     banditCamp.transform.position.y + 24,
                        //     banditCamp.transform.position.z
                        // );
                        // data.levelReference = banditCamp;
                        // data.locationEntry = banditCamp.transform.Find("Terrain").transform.Find("playerSpawn").gameObject;
                        data.locationEntry = banditCamp.GetComponent<levelData>().levelEntryPoint;
                        newSpawn.name = banditCamp.name;
                        data.GetComponent<Renderer>().material.color = Color.yellow;
                        Debug.Log("Location generated.");
                    }
                // }
            }
        }


    }
}
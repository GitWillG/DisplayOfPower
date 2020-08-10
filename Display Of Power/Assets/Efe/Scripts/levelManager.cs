using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    GameObject[] npcSpawnGroups;
    public GameObject NPC;

    float[] population_meter = {5, 15};
    // Start is called before the first frame update
    void Start()
    {
        npcSpawnGroups = GameObject.FindGameObjectsWithTag("npcSpawn");
        float random = Random.Range(population_meter[0], population_meter[1]);
        // for(int i = 0; i < random; i++)
        // {
            foreach(GameObject spawn in npcSpawnGroups)
            {
                Instantiate(NPC, spawn.transform.position, Quaternion.identity);
            }
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

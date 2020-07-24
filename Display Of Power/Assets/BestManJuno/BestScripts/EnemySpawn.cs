using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    //Prefab is set through editor
    public GameObject enemyPrefab;

    //array for the hexes spawned on the map
    public GameObject[] hex;
    //the selected hex to be spawned at
    public GameObject hexSpawn;
    //number of enemies to be spawned
    public int numOfEnemies;

    //function that calls a single enemy unit to be spawned at a given hex
    [ContextMenu("Spawn Enemy")]
    public void SpawnEnemy()
    {
        //assigns all hexes to the array 'hex' and indexes them 
        //NOTE SHOULD BE CALLED IN START FUNCTION 
        //ONLY ASSIGNED IN FUCNTION FOR TESTING MEASURES
        hex = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            hex[i] = transform.GetChild(i).gameObject;
        }

        //grabs a random index from the hex array and stores it as an int
        int hexChoice = Random.Range(0, hex.Length);

        //gets the randomly slected index and assigns the gameobject on the index to be the spawn point
        hexSpawn = hex[hexChoice].gameObject;

        //if there is no object on the selected hex, spawn an enemy if need be
        if(hexSpawn.transform.childCount < 1)
        {
            GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, new Vector3(hexSpawn.transform.position.x, 0.8f, hexSpawn.transform.position.z), Quaternion.identity);
            newEnemy.transform.SetParent(hexSpawn.transform);
            newEnemy.layer = 9;
        }
    }

    //Spawn number of enemies dictated in the editor
    //NOTE NUMBER OF ENEMIES WILL NOT BE PUBLIC FOR IN GAME FUNCTION 
    //RATHER WILL BE CALLED THRU THE FUNCTION AS IT HAS BEEN COMMENTED OUT FOR NOW
    [ContextMenu("Spawn Multiple Enemies")]
    public void SpawnEnemies(/*int numOfEnemies*/)
    {
        for (int i = 0; i < numOfEnemies; i++)
        {
            SpawnEnemy();
        }
    }
}

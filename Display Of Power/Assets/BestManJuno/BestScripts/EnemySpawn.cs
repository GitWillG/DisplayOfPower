using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemySpawn : MonoBehaviour
{

    //Prefab is set through editor
    public GameObject enemyPrefab;
    public GenerateGrid grid;

    //array for the hexes spawned on the map
    public GameObject[] hex;
    //the selected hex to be spawned at
    public GameObject hexSpawn;
    //number of enemies to be spawned
    int numOfEnemies;
    GameObject newEnemy;
    public GameObject allyPrefab;
    public GameObject[] teamFeedbackObjects;

    /// <summary>
    GameObject[] targetHexes;
    /// </summary>

    public TMP_InputField numOfBads;

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
        if (hexSpawn.transform.childCount < 1)
        {
            GameObject newEnemy = (GameObject)Instantiate(enemyPrefab, new Vector3(hexSpawn.transform.position.x, hexSpawn.transform.position.y + 0.8f, hexSpawn.transform.position.z), Quaternion.identity);
            newEnemy.transform.SetParent(hexSpawn.transform);
            newEnemy.layer = 9;
        }
    }

    //function that calls a single enemy unit to be spawned at a given hex
    public void SpawnEnemy(GameObject unitToSpawn)
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
            newEnemy = (GameObject)Instantiate(unitToSpawn, new Vector3(hexSpawn.transform.position.x, hexSpawn.transform.position.y + 0.8f, hexSpawn.transform.position.z), Quaternion.identity);
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
        numOfEnemies = int.Parse(numOfBads.text);

        for (int i = 0; i < numOfEnemies; i++)
        {
            SpawnEnemy(enemyPrefab);
        }
    }

    public void SpawnSpecificLocation(GameObject unitToSpawn, List<GameObject> spawnGrid, string teamString)
    {


        //assigns all hexes to the array 'hex' and indexes them 
        //NOTE SHOULD BE CALLED IN START FUNCTION 
        //ONLY ASSIGNED IN FUCNTION FOR TESTING MEASURES
        targetHexes = new GameObject[40];
        targetHexes = spawnGrid.ToArray();
        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    hex[i] = transform.GetChild(i).gameObject;
        //}
        hex = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            hex[i] = transform.GetChild(i).gameObject;
        }

        //grabs a random index from the hex array and stores it as an int
        int hexChoice = Random.Range(0, targetHexes.Length);

        //gets the randomly slected index and assigns the gameobject on the index to be the spawn point
        hexSpawn = targetHexes[hexChoice].gameObject;

        //if there is no object on the selected hex, spawn an enemy if need be
        if (hexSpawn.transform.childCount < 1)
        {
            newEnemy = (GameObject)Instantiate(unitToSpawn, new Vector3(hexSpawn.transform.position.x, hexSpawn.transform.position.y + 0.8f, hexSpawn.transform.position.z), Quaternion.identity);
            newEnemy.transform.SetParent(hexSpawn.transform);
            newEnemy.layer = 9;
           
        }
        // Assign team and feedback objects
        prefabUnits data = newEnemy.GetComponent<prefabUnits>();
        Vector3 spawnPosition = new Vector3
        (
            newEnemy.transform.position.x,
            newEnemy.transform.position.y + 2,
            newEnemy.transform.position.z
        );



        if (teamString == "ally")
        {
            grid.allyList.Add(newEnemy);
            data.belongsToPlayer = true;
            newEnemy.GetComponent<prefabUnits>().Factions = "Ally";
            newEnemy.name = "Mage";
            teamFeedbackObjects[1] = Instantiate(teamFeedbackObjects[1], spawnPosition, Quaternion.identity);
            teamFeedbackObjects[1].transform.parent = newEnemy.transform;
             
        }
        else if (teamString == "enemy")
        {
            grid.enemyList.Add(newEnemy);
            newEnemy.name = "Soldier";
            teamFeedbackObjects[0] = Instantiate(teamFeedbackObjects[0], spawnPosition, Quaternion.identity);
            teamFeedbackObjects[0].transform.parent = newEnemy.transform;
            
        }

        
        
    }

    //public void SpawnSpecificLocation(int numOfUnits, GameObject unitToSpawn, List<GameObject> spawnGrid)
    //{
    //    for (int i = 0; i < numOfUnits; i++)
    //    {
    //        SpawnSpecificLocation(unitToSpawn, spawnGrid);
    //    }
    //}

    

    public void SpawnEnemies(int numOfUnits, GameObject unitToSpawn)
    {
        for (int i = 0; i < numOfUnits; i++)
        {
            SpawnEnemy(unitToSpawn);
        }
    }
    public void SpawnEnemies(int numOfUnits, GameObject unitToSpawn, List<GameObject> populateList)
    {
        for (int i = 0; i < numOfUnits; i++)
        {
            SpawnEnemy(unitToSpawn);
            populateList.Add(newEnemy);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GenerateGrid generateGrid;

    [ContextMenu("Spawn Enemies")]
    public void SpawnEnemies()
    {
        // generateGrid.hexPrefab
    }
}

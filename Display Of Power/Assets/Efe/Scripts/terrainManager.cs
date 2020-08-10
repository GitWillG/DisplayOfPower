using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainManager : MonoBehaviour
{
    public TreeInstance[] terrainTrees;
    Terrain masterTerrain;
    TerrainData data;
    public GameObject treeModel;
    public List<GameObject> instancedTrees;
    // Start is called before the first frame update
    void Start()
    {
        masterTerrain = GetComponent<Terrain>();
        data = masterTerrain.terrainData;
        float width = data.size.x;
        float height = data.size.z;
        float y = data.size.y;
        terrainTrees = masterTerrain.terrainData.treeInstances;
       
        foreach(TreeInstance tree in terrainTrees)
        {
            for(int i = 0; i < terrainTrees.Length; i++)
            {
            Vector3 position = new Vector3(tree.position.x, tree.position.y, tree.position.z);
            Debug.Log(tree);

            // if(treeModel != null)
            // {
                Instantiate(treeModel, position, Quaternion.identity);
            // }
            // tree.
            }


            
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

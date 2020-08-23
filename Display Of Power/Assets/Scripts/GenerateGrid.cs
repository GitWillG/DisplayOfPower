using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GenerateGrid : MonoBehaviour
{
    //nnumber of tiles along x axis of grid
    public int Width;
    //number of tilels along z axis of grid
    public int Depth;
    public CubeUnit cubeclass;
    public List<GameObject> innerList;
    public List<List<GameObject>> movementRadius;
    public GameObject hexPrefab;
    public List<GameObject> tempList;
    List<GameObject> parent;
    public List<GameObject> path;
    List<CubeUnit> possibleCubes;

    ///////////////////////testing
    //public Material newmat;
    public GameObject testLocation;
    public GameObject[,] hexArray;
    public List<GameObject> legalHex;
    public Material testmat;
    public List<GameObject> postObCheck;
    //////////

    public List<GameObject> enemyList;
    public List<GameObject> allyList;

    public EnemySpawn enemySpawn;
    public MouseControl mouseControl;

    //actual dimensions of our prefab for refference
    private float hexWidth = 1.732f;
    private float hexDepth = 2f;

    //zOffset is 0.75 * depth of the hex
    public float zOffset = 1.5f;
    //xOffset is half of the Width
    public float xOffset = 0.866f;

    //initial list to add all units on field
    List<GameObject> unitsOnField = new List<GameObject>();
    //New list for turn order that will include all units on field
    public List<GameObject> turnOrder = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        enemyList = new List<GameObject>();
        allyList = new List<GameObject>();
        gridGeneration();

        enemySpawn.SpawnEnemies(5, enemySpawn.allyPrefab, allyList);
        enemySpawn.SpawnEnemies(5, enemySpawn.enemyPrefab, enemyList);
    }

    [ContextMenu("Generate Grid")]
    public void gridGeneration()
    {
        hexArray = new GameObject[Width, Depth];
        //2 Dimension grid
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                //change the default x positioning to fit the dimensions of the hex
                float xPos = x * hexWidth;

                //every odd row we offset the x position
                if (z % 2 == 1)
                {
                    xPos += xOffset;
                }
                //make a hex at the location and name it with its 2D dimensions
                GameObject hexOb = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, z * zOffset), Quaternion.Euler(0, 90, 0));
                hexOb.name = "Hex " + x + " " + z;
                hexOb.transform.SetParent(this.gameObject.transform);
                hexArray[x, z] = hexOb.gameObject;
            }
        }
    }

    public void gridGeneration(int gWidth, int gDepth)
    {
        Width = gWidth;
        Depth = gDepth;
        //2 Dimension grid
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                //change the default x positioning to fit the dimensions of the hex
                float xPos = x * hexWidth;

                //every odd row we offset the x position
                if (z % 2 == 1)
                {
                    xPos += xOffset;
                }
                //make a hex at the location and name it with its 2D dimensions
                GameObject hexOb = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, z * zOffset), Quaternion.Euler(0, 90, 0));
                hexOb.name = "Hex " + x + " " + z;
                hexOb.transform.SetParent(this.gameObject.transform);
            }
        }
    }







    //[ContextMenu("CheckRadius")]
    //This is takes a point and Checks each surrounding hex to see if a unit is on them, each hex that does not have a unit, and hasn't already been checked is added to a list
    //That list is then moved to a different layer and re-coloured
    public void checkMoveLegality(int radius, GameObject centerPoint, Material newMat)
    {
        movementRadius = new List<List<GameObject>>();
        innerList.Add(centerPoint);
        movementRadius.Add(innerList);
        tempList = new List<GameObject>();
        List<GameObject> rowVal;
        tempList.Add(centerPoint);
        parent = new List<GameObject>();
        parent.Add(centerPoint);
        
        for (int k = 1; k < radius + 1; k++)
        {
            rowVal = new List<GameObject>();
            rowVal.Clear();
            for (int j =0; j<movementRadius[k-1].Count; j++)
            {

                Collider[] closeHexes = Physics.OverlapSphere(movementRadius[k-1][j].transform.position, 1f, 1<<8);
                foreach (var currentHex in closeHexes)
                {
                    if (!tempList.Contains(currentHex.gameObject) && currentHex.transform.childCount <1)
                    {
                        rowVal.Add(currentHex.gameObject);
                        tempList.Add((currentHex.gameObject));
                        parent.Add(movementRadius[k - 1][j]);
                    }
                }

            }
            movementRadius.Add(rowVal);

        }



        for (int i = 0; i < tempList.Count; i++)
        {
            if (tempList[i] != centerPoint)
            {
                tempList[i].gameObject.GetComponent<Renderer>().material = newMat;
                tempList[i].gameObject.layer = 10;                

            }
            else
            {
                tempList[i].gameObject.layer = 10;
            }
        }
        innerList.Clear();
        movementRadius.Clear();
            
    }

    //This converts our 2x2 grid into a grid using axial co-ordinates
    //it then calculates the radius in this axial grid, and checks for hexes in that radius and adds them to a list
    //That list is then moved to a new layer and re-coloured
    public void checkAttackLegality(int radius, GameObject centerPoint, Material newMat)
    { 
        int testRadius = radius;
        float xNum = 0;
        float zNum = 0;
        int centerX = 0;
        int centerZ = 0;

        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                if (centerPoint == hexArray[x, z].gameObject)
                {
                    centerX = x;
                    centerZ = z;

                    xNum = x - (z - (z & 1)) / 2;
                    zNum = z;


                }
            }
        }

        for (int a = 0; a < Width; a++)
        {
            for (int b = 0; b < Depth; b++)
            {
                float newx = a - (b - (b & 1)) / 2;
                float newz = b;
                float distance = Mathf.Max(Mathf.Abs(xNum - newx) + Mathf.Abs(xNum + zNum - newx - newz) + Mathf.Abs(zNum - newz));
                if (distance <= testRadius * 2)
                {
                    legalHex.Add(hexArray[a, b]);
                }

            }
        }

        for (int i = 0; i < legalHex.Count; i++)
        {
            if (legalHex[i] != centerPoint)
            {
                legalHex[i].gameObject.GetComponent<Renderer>().material = newMat;
                legalHex[i].gameObject.layer = 10;
            }
            else
            {
                legalHex[i].gameObject.layer = 10;
            }
        }

    }
    //This takes the list of attack hexes and reverts them to their original layer then clears the list
    public void removeCheck(Material newMat)
    {
        for (int i = 0; i < legalHex.Count; i++)
        {
            legalHex[i].gameObject.GetComponent<Renderer>().material = newMat;

            legalHex[i].gameObject.layer = 8;
        }
        legalHex.Clear();

    }
    //This takes the list of movement hexes and reverts them to their original layer then clears the list
    public void removeMoveCheck(Material newMat)
    {
        for (int i = 0; i < tempList.Count; i++)
        {
            tempList[i].gameObject.GetComponent<Renderer>().material = newMat;

            tempList[i].gameObject.layer = 8;
        }
        tempList.Clear();
        //possibleCubes.Clear();

    }

    //Function to randomize turn order
    //TESTING MEASURE FOR PROTOTYPE
    public List<GameObject> RandomizeList(List<GameObject> inputList)
    {
        int rand = 0;
        List<GameObject> returnList = new List<GameObject>();
        //while the first list has contents it runs this code
        while (inputList.Count > 0)
        {
            //Randomly take contents from first list then adds to second list 
            //also removes from first list to meet while loop conditions
            rand = UnityEngine.Random.Range(0, inputList.Count);
            returnList.Add(inputList[rand]);
            inputList.Remove(inputList[rand]);
        }
        return returnList;
    }

    [ContextMenu("Create Turn Order")]
    public void CreateTurnOrder()
    {
        ///Array of all hexes in game exists in EnemySpawn.cs
        ///run through the existing array of hexes and 
        ///adds all game object that are children to the 
        ///list units on field
        for (int i = 0; i < enemySpawn.hex.Length; i++)
        {
            if (enemySpawn.hex[i].transform.childCount > 0)
            {
                unitsOnField.Add(enemySpawn.hex[i].transform.GetChild(0).gameObject);
            }     
        }

        //print all units on field
        for (int i = 0; i < unitsOnField.Count; i++)
        {
            //Debug.Log(unitsOnField[i]);
        }

        //using previous function to randomize list
        turnOrder = RandomizeList(unitsOnField);

        //print the turn order
        for(int i = 0; i < turnOrder.Count; i++)
        {
            //Debug.Log("Turn order: " + (i+1) + " " + turnOrder[i]);
        }
    }

    public int k = 0;

    [ContextMenu("Start Next Turn")]
    public void NextTurn()
    {
        if (turnOrder[k].GetComponent<prefabUnits>().actionsRemaining == 0)
        {
            turnOrder[k].GetComponent<prefabUnits>().isTurn = false;
            if (k+1 <= turnOrder.Count)
            {
                k = k + 1;
            }
            else
            {
                k = 0;
            }
            //print("next turn is" + k);

        }
        mouseControl.hoveredTarget = turnOrder[k].transform.parent;
        turnOrder[k].GetComponent<prefabUnits>().isTurn = true;
        if (turnOrder[k].GetComponent<prefabUnits>().isTurn == true)
        {
            mouseControl.selectHex(turnOrder[k].transform.parent.gameObject);
        }

      
    }

    public void choosePath(GameObject start, GameObject end)
    {
        path = new List<GameObject>();
        GameObject checkNext;
    
        path.Clear();
        path.Add(end);
        checkNext = end;
        while (checkNext != start)
        {
            int indexCheck = tempList.IndexOf(checkNext);
            checkNext = parent[indexCheck];
            path.Add(checkNext);

        }
        path.Reverse();


    }

    public void EndTurn()
    {
        if (turnOrder[k].GetComponent<prefabUnits>().isTurn)
        {
            turnOrder[k].GetComponent<prefabUnits>().actionsRemaining = 0;
            //mouseControl.selectHex(turnOrder[k].transform.parent.gameObject);
        }
    }

}

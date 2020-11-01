using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using TMPro;
using efe;
using UnityEngine.UI;

public class GenerateGrid : MonoBehaviour
{

    [Header("Grid Size")]
    public int Depth;
    public int Width;
    [Header("Spawn Parameters")]
    //nnumber of tiles along x axis of grid
    public GameObject currTurn;
    //number of tiles along z axis of grid
    
    // public CubeUnit cubeclass;
    public List<GameObject> innerList;
    public List<List<GameObject>> movementRadius;
    public GameObject hexPrefab;
    public List<GameObject> tempList;
    List<GameObject> parent;
    public List<GameObject> path;
    List<CubeUnit> possibleCubes;
    public int k = 0;
    ///////////////////////testing
    //public Material newmat;
    // public GameObject testLocation;
    public GameObject[,] hexArray;
    public List<GameObject> legalHex;
    // public Material testmat;
    public List<GameObject> postObCheck;
    //////////

    [Header("Battle Parameters")]
    public List<GameObject> enemyList;
    public List<GameObject> allyList;

    [Header("References")]
    public EnemySpawn enemySpawn;
    public MouseControl mouseControl;

    //actual dimensions of our prefab for refference
    private float hexWidth = 1.732f;
    // private float hexDepth = 2f;
    public bool hasStarted = false;

    //zOffset is 0.75 * depth of the hex
    public float zOffset = 1.5f;
    //xOffset is half of the Width
    public float xOffset = 0.866f;

    //initial list to add all units on field
    List<GameObject> unitsOnField = new List<GameObject>();
    //New list for turn order that will include all units on field
    public List<GameObject> turnOrder =  new List<GameObject>(); 

    /// new stuff
    public List<GameObject> allySpawnHexes;
    public List<GameObject> enemySpawnHexes;
    int hexesSpawned;
    public List<SO_Units> charPrefabList;

    //enemies/allies can spawn in the last/first hexes
    public int constrainSpawn;

    /// new stuff

    [Header("Editor")]
    public List<GameObject> generated_grids;
    public GameObject VictoryScreen;
    public GameObject DefeatScreen;
    bool gridHidden = false;

    public GameObject turnNotification;
    int addedPropAmount;
    public GameObject blockade;

    public List<GameObject> blockedHexes;
    GUIManager guim;
    
    [Header("Initiative Bar")]
    public GameObject initiativeSprite;
    public GameObject initiativeAligner;
    public List<GameObject> initiatives;

    CameraControl cc;
    audioManager am;
    spellManager sm;

    public bool firstTurnPlayed = false;
    int turnDelaySecond;

    // Start is called before the first frame update
    void Start()
    {   

        cc = Camera.main.GetComponent<CameraControl>();

        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        am = GameObject.FindGameObjectWithTag("GM").GetComponent<audioManager>();
        sm = GameObject.FindGameObjectWithTag("GM").GetComponent<spellManager>();
        ///
        allySpawnHexes = new List<GameObject>();
        enemySpawnHexes = new List<GameObject>();
        hexesSpawned = 0;
        //charPrefabList = new List<GameObject>();
        //charPrefabList.Add()
        ///
        enemyList = new List<GameObject>();
        allyList = new List<GameObject>();
        hexArray = new GameObject[Width, Depth];
        gridGeneration();

        enemySpawn.SpawnSpecificLocation(enemySpawn.allyUnits[0], allySpawnHexes, "Ally");
        enemySpawn.SpawnSpecificLocation(enemySpawn.allyUnits[1], allySpawnHexes, "Ally");
        enemySpawn.SpawnSpecificLocation(enemySpawn.allyUnits[2], allySpawnHexes, "Ally");
        enemySpawn.SpawnSpecificLocation(enemySpawn.allyUnits[3], allySpawnHexes, "Ally");

        enemySpawn.SpawnSpecificLocation(enemySpawn.enemyUnits[0], enemySpawnHexes, "Enemy");
        enemySpawn.SpawnSpecificLocation(enemySpawn.enemyUnits[1], enemySpawnHexes, "Enemy");
        enemySpawn.SpawnSpecificLocation(enemySpawn.enemyUnits[2], enemySpawnHexes, "Enemy");
        enemySpawn.SpawnSpecificLocation(enemySpawn.enemyUnits[1], enemySpawnHexes, "Enemy");
        hasStarted = true;
     

        // addPropsRandomly(blockade);
        //enemySpawn.SpawnEnemies(5, enemySpawn.allyPrefab, allyList);
        //enemySpawn.SpawnEnemies(5, enemySpawn.enemyPrefab, enemyList);
    }
    private void Update()
    {   

        showGrid();
        // if(Input.GetKeyDown(KeyCode.B))
        // {
        //     addPropsRandomly(blockade);
        // }

        if (hasStarted)
        {

            if (allyList.Count <= 0)
            {
                // Debug.Log("you lose");
                hasStarted = false;
                Instantiate(DefeatScreen, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            }
            else if (enemyList.Count <= 0)
            {
                // Debug.Log("you win");
                hasStarted = false;
                Instantiate(VictoryScreen, new Vector2(Screen.width / 2, Screen.height /2), Quaternion.identity);
            }
  
        }

    }

    public void winTest()
    {

            enemyList.Clear();


    }

    public void loseTest()
    {

            allyList.Clear();

    }

    [ContextMenu("Generate Grid")]
    public void gridGeneration()
    {
        hexesSpawned = 0;
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
                hexOb.transform.localPosition = new Vector3(xPos, 0, z * zOffset);
                hexArray[x, z] = hexOb.gameObject;
                generated_grids.Add(hexOb);

                hexesSpawned++; if (hexesSpawned <= 300 && hexesSpawned >200)
                {
                    allySpawnHexes.Add(hexOb);
                }
                else if (hexesSpawned > (400 - constrainSpawn))
                {
                    enemySpawnHexes.Add(hexOb);
                }

            }
        }
    }

    public void gridGeneration(int gWidth, int gDepth)
    {
        hexesSpawned = 0;
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
                
                if (hexesSpawned < 160 && hexesSpawned >120)
                {
                    allySpawnHexes.Add(hexOb);
                }
                else if (hexesSpawned > ((gWidth * gDepth) - constrainSpawn))
                {
                    enemySpawnHexes.Add(hexOb);
                }
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
        //legalHex.Clear();
        for (int x = 0; x< generated_grids.Count; x++)
        {
            float distance = Vector3.Distance(centerPoint.transform.position, generated_grids[x].transform.position);
            if (distance <= 1.8f * radius)
            {
                legalHex.Add(generated_grids[x]);
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
    //
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

    


    [ContextMenu("Start Next Turn")]
    public void NextTurn()
    {
        StartCoroutine(pauseforTurn());
        
    }

    public void createInitiativeSprite(GameObject sourceObject)
    {
        
        GameObject temp = Instantiate(initiativeSprite, initiativeAligner.transform.position, Quaternion.identity);
        temp.transform.parent = initiativeAligner.transform;
        initiatives.Add(temp);

        actorData data = sourceObject.GetComponent<actorData>();
        temp.transform.Find("Avatar").GetComponent<Image>().sprite = data.initiativeAvatar;

        data.initiativeReference = temp;

        temp.GetComponent<temp_initiativeDataHolder>().referenceObject = sourceObject;
        temp.name = data.actorName;

        // if(data.isTurn)
        // {
        //     temp.transform.SetAsFirstSibling();
        //     // temp.transform.localScale = new Vector2(2,2);
        // }
        // else
        // {
        //     temp.transform.localScale = new Vector2(1, 1);
        //     // temp.transform.SetAsLastSibling();
        // }


        // Debug.Log("Created sprite.");
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
        if (turnOrder[k] !=null)
        {
            if (turnOrder[k].GetComponent<actorData>().isTurn && turnOrder[k].GetComponent<actorData>().actionsRemaining > 0)
            {
                turnOrder[k].GetComponent<actorData>().actionsRemaining = 0;
                //mouseControl.selectHex(turnOrder[k].transform.parent.gameObject);
            }
        }
        guim.updateLog("Turn ended.", Color.green);
        mouseControl.playerTurnGUI.SetActive(true);
        am.playAudio2D("endturn");
        Time.timeScale = 1;
        
        NextTurn();
        
    }

    [ContextMenu("Clear grids")]
    void clearList()
    {   
        bool clear = false;
        foreach(GameObject temp in generated_grids)
        {
            if(generated_grids == null)
            {
                return;
            }
            if(temp != null)
            { 
                DestroyImmediate(temp);
                generated_grids.Remove(temp);
                clear = true;
             
            }
            if(clear)
            {
                generated_grids.Clear();
            }
            
        }
    }


    public void showGrid()
    {
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if(!gridHidden)
            {
                gridHidden = true;
                Debug.Log("Grid is hidden");
                foreach(GameObject temp in generated_grids)
                {
                    temp.GetComponent<Renderer>().enabled = false;
                }
            }
            else
            {
                gridHidden = false;
                Debug.Log("Grid is not hidden");
                foreach(GameObject temp in generated_grids)
                {
                    temp.GetComponent<Renderer>().enabled = true;
                }
            }
        }
    }

    public void addPropsRandomly(GameObject targetObject)
    {
            for(int b = 0; b < 5; b++)
            {
                int randomNo = UnityEngine.Random.Range(0, generated_grids.Count);     
                if(generated_grids[randomNo].transform.childCount == 0)
                {               
                    Vector3 spawnPos = new Vector3(
                        generated_grids[randomNo].transform.position.x,
                        generated_grids[randomNo].transform.position.y + 2,
                        generated_grids[randomNo].transform.position.z

                    );
                    Instantiate(targetObject, spawnPos, Quaternion.identity);
                    blockedHexes.Add(generated_grids[randomNo]);
                    generated_grids[randomNo].layer = 15;
                }
                else
                {
                    Debug.Log("There is something in this grid already.");
                }
                
            }

    }
    public IEnumerator pauseforTurn()
    {
        if(!firstTurnPlayed)
        {
            turnDelaySecond = 0;
        }
        else
        {
            firstTurnPlayed = true;
            turnDelaySecond = 2;
        }

        yield return new WaitForSeconds(turnDelaySecond);
        mouseControl.isMove = true;
        //foreach (GameObject turnorder in turnOrder)
        //{
        //    if (turnorder == null)
        //    {
        //        turnOrder.Remove(turnorder);
        //    }
        //}
        if (mouseControl.selectedTarget != null && mouseControl.selectedTarget.childCount > 0)
        {
           
            mouseControl.swapRange();
            mouseControl.removeRangeInd();
        }



        //if (k >= turnOrder.Count - 1)
        //{
        //    k = 0;
        //}
        if (turnOrder[k].GetComponent<actorData>().actionsRemaining <= 0)
        {
           
            //if (initiatives.Count > 0)
            //{
            //    initiativeAligner.transform.GetChild(0).transform.SetAsLastSibling();
            //    // foreach(GameObject a in initiatives)
            //    // {
            //    //     Destroy(a);
            //    //     Debug.Log(a + " destroyed.");
            //    // }
            //    // initiatives.Clear();
            //}

            turnOrder[k].GetComponent<actorData>().actionsRemaining = turnOrder[k].GetComponent<actorData>().TotalActions;
            turnOrder[k].GetComponent<actorData>().isTurn = false;
            // turnOrder[k].GetComponent<actorData>().actionsRemaining = 2;
            sm.refreshAP();
            if (k < turnOrder.Count - 1)
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
        turnOrder[k].GetComponent<actorData>().isTurn = true;
        currTurn = turnOrder[k].transform.parent.gameObject;
        if (turnOrder[k].GetComponent<actorData>().isTurn == true)
        {
            if (turnOrder[k].GetComponent<actorData>().belongsToPlayer == true)
            {
                mouseControl.selectionMaterial = mouseControl.legalMove;
            }
            else
            {
                mouseControl.selectionMaterial = mouseControl.enemiesMat;
            }
            mouseControl.clickedHex = false;
            //mouseControl.selectedTarget = turnOrder[k].transform;
            mouseControl.selectHex(turnOrder[k].transform.parent.gameObject);
            // Debug.Log("test2");

            // Show whose turn
            GameObject tempTurn = Instantiate(turnNotification, new Vector2(Screen.width / 2, Screen.height / 4), Quaternion.identity);
            tempTurn.transform.localScale /= 2;
            tempTurn.transform.parent = guim.battleGUI.transform;
            if (turnOrder[k].GetComponent<actorData>().ownerFaction_string == "Ally")
            {
                tempTurn.transform.Find("Image").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "Player's Turn";
            }
            else
            {
                tempTurn.transform.Find("Image").transform.Find("Text").GetComponent<TextMeshProUGUI>().text = "AI's Turn";
            }
            Destroy(tempTurn, 2);
            // Debug.Log("test");
        }

        cc.panToObject(turnOrder[k]);
        if (initiatives.Count == 0)
        {
            // update initiatve GUI with turn order
            // Initiative bar
            for (int z = 0; z < turnOrder.Count; z++)
            {
                createInitiativeSprite(turnOrder[z]);

            }
        }

        sm.processStatuses();
        sm.processCooldowns();

        guim.updateLog("Turn ended.", Color.green);
        mouseControl.playerTurnGUI.SetActive(true);
        am.playAudio2D("endturn");


    }

}

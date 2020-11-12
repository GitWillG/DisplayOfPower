using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using efe;
using UnityEngine.UI;

public class MouseControl : MonoBehaviour
{
    //
    /// <summary>
    /// NEED TO REHASH RIGHT CLICK TO ENABLE MOVEMENT RADIUS
    /// </summary>
    public EventSystem ev_system;
    public GameObject basicAttackButton;
    [Header("GUI")]
    public TextMeshProUGUI lifeBox;
    public TextMeshProUGUI unitBox;
    public TextMeshProUGUI attackBox;
    public TextMeshProUGUI actionsLeft;
    public TextMeshProUGUI buffDescField;
    [Header("Materials")]
    //Selected hex material
    public Material selectedMat;
    //hovered hex material
    public Material hoveredMat;
    //the last appropriate material, changes when we move between highlighting legal moves and not
    public Material oldMat;
    //legal radius material
    public Material legalMove;
    //original hexs material
    public Material defaultMat;
    public Material attackMat;
    public Material enemiesMat;
    public Material selectionMaterial;
    [Space(5)]
    public GenerateGrid GridOb;
    public bool doneMoving;
    public GameObject selectionManager;
    public GameObject currClickedHex;

    //detection range for movement/attacks
    public int detectRange;
    //this is our grid, we need access to it to swap grid colors
    public GameObject grid;
    //default layer to raycast on is the hex layer (8)
    public int currentMask =  1 << 8; 
    //Are we checking for movement radius? if not we are checking for attack radius
    public bool isMove = true;

    public bool isMoving = false;

    //Temporary, we need access to the prefab we are using for unit testing
    public GameObject unitPrefab;


    //the transform of a selected hexes
    public Transform selectedTarget;
    public Transform lastSelectedTarget;
    //the transform of any hovered hexes
    public Transform hoveredTarget;
    //have you selected a hex for the purpose of checking the appropriate radius of its child?
    public bool clickedHex;
    //The renderer of any given selection
    Renderer selectionRenderer;
    spellManager sm;
    GUIManager guim;
    public GameObject playerTurnGUI;
    public GameObject tutorial;
    public List<GameObject> listSelectionCircles;
    public List<GameObject> listRays;
    public GameObject rayParticle;
    public GameObject selectionCircle;
    immersionManager im;
    public Material initativeMaterialHighlight;

    private void Start()
    {
        ev_system = EventSystem.current;
        //nothing is selected at the start
        clickedHex = false;
        doneMoving = true;
    
        tutorial.SetActive(true);
        
        sm = GameObject.FindGameObjectWithTag("GM").GetComponent<spellManager>();
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        im = GameObject.FindGameObjectWithTag("GM").GetComponent<immersionManager>();
        selectionMaterial = legalMove;
    }

    private void Update()
    {
        if(GridOb.currTurn != null)
        {
            GridOb.currTurn.GetComponent<Renderer>().material = hoveredMat;

        }

        if(selectedTarget != null)
        {
            lastSelectedTarget = selectedTarget;
        }

        if (isMoving == false) 
        { 
            //whenever there is no hovered target or cicked hex reset the last selected hex to its original material
            if (hoveredTarget != null)
            {
                //if youve clicked a hex we use the selection colors, otherwise we use our default hex colors
                if(clickedHex == true)
                {
                    oldMat = selectionMaterial;
                }
               
                else
                {
                    oldMat = defaultMat;
                }

                //get the rennderer of the last hovered targed
                selectionRenderer = hoveredTarget.GetComponent<Renderer>();
                //reset it
                selectionRenderer.material = oldMat;
                //null the old target
                hoveredTarget = null;
            }

            //after you've reset the hexes to their original color, if a hex is selected keep it colored as such
            if (selectedTarget != null)
            {
                selectedTarget.gameObject.GetComponent<Renderer>().material = selectedMat;
            }

        // checks if mouse is not hovering GUI
        if(!EventSystem.current.IsPointerOverGameObject())
        {
            // Check if player is previewing a skill

                    if (Input.GetMouseButtonUp(1) && clickedHex == true)
                    {
                        moveRadius();
                    }
                    //Ray cast from the mouse to find objects
                    var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    // Debug.Log(0);
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, currentMask))
                    {
                        // Debug.Log(1);
                        //save the selection and get its renderer
                        var selection = hit.transform;
                        
                        selectionRenderer = selection.GetComponent<Renderer>();
                    
                        //if we have not clicked a hex and the hovered object has a renderer we change the material to a hovered material, and declare it our selected target
                        // Hovering
                        if (selectionRenderer != null)
                        {
                            
                            oldMat = selectionRenderer.material;
                            selectionRenderer.material = hoveredMat;
                            hoveredTarget = selection;
                            // Debug.Log(2);

                            //if (selectedTarget != null && isMove && hoveredTarget != null)
                            //{
                            //    GridOb.choosePath(selectedTarget.gameObject, hoveredTarget.gameObject);
                            //}
                        }
                    //otherwise if you have selected a target, and you click on that object, we will revert it to its original material and reset the clicked Bool
                    // Deselection
                    if (!sm.castPreviewEnabled)
                    {
                        if (selection == selectedTarget && Input.GetMouseButtonUp(0) && clickedHex == true && hoveredTarget == selectedTarget)
                        {

                            removeRangeInd();
                            return;
                        }
                    }
                    }

                //  if you click, while hovering a selected hex, and you have not already clicked a hex,
                //  change that object to the selected color and Declare that a hex has been clicked
                // Selecting
                // prefabUnits data = selection.GetComponentInChildren<prefabUnits>();
                if (!sm.castPreviewEnabled)
                {
                    // Moving units here
                    if (Input.GetMouseButtonUp(0) && hoveredTarget != null)
                    {
                        selectHex(hoveredTarget.gameObject);
                        // Debug.Log(4);
                    }
                }

                //}
                else if (isMoving)
                {
                    finishMovement();
                    // Debug.Log(5);
                }
            }
        }
    }

    //Switch the selected range to the appropriate range
    public void swapRange()
    {
        if (selectedTarget != null)
        {

        
        //if move, use move range, otherwise use the attack range
        if (isMove)
        {
            detectRange = selectedTarget.GetChild(0).GetComponent<actorData>().MovementRange;
        }
        else
        {
            detectRange = selectedTarget.GetChild(0).GetComponent<actorData>().AttackRange;
        }
        }
    }
    public void removeRangeInd()
    {
        selectionRenderer = selectedTarget.GetComponent<Renderer>();    
        //reset the selected hex
        selectionRenderer.material = oldMat;
        //nothing is selected anymore
        clickedHex = false;
        //revert all the highlighted hexes to their original colors
        grid.GetComponent<GenerateGrid>().removeCheck(defaultMat);
        grid.GetComponent<GenerateGrid>().removeMoveCheck(defaultMat);
        //null the selected hex
        selectedTarget.GetComponentInChildren<actorData>().overheadReference.SetActive(false);
        
        im.restoreHighlight(selectedTarget.GetChild(0).gameObject, "Character");

        if(selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference == null) 
        {
            return;
        }
        else
        {
            selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference.GetComponent<Image>().material = null;
        }

        
        foreach(GameObject temp in listSelectionCircles)
        {
            Destroy(temp);
        }
        listSelectionCircles.Clear();
        
        selectedTarget = null;
        //go back to raycasting on our default hex layer
        currentMask = 1 << 8; 

        lifeBox.text = "";
        attackBox.text = "";
        unitBox.text = "";
        actionsLeft.text = "";
        buffDescField.text = "";
        
    }

    [ContextMenu("switch between attack or move")]
    public void moveAttackSwap()
    {
        //flip the is move bool
        isMove = !isMove;
        //swap the range to appropriate range
        if (selectedTarget != null)
        {
            swapRange();
            grid.GetComponent<GenerateGrid>().removeCheck(defaultMat); 
            grid.GetComponent<GenerateGrid>().removeMoveCheck(defaultMat);

            if (isMove)
            {
                grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, selectionMaterial);
            }
            else
            {
                grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, attackMat);
            }
        }
        //reset and rehighlight appropriate hexes
    }


    public void finishMovement()
    {
        if (lastSelectedTarget.GetChild(0).transform.position.x >= lastSelectedTarget.transform.position.x - 0.2 && lastSelectedTarget.GetChild(0).transform.position.x <= lastSelectedTarget.transform.position.x + 0.2 && lastSelectedTarget.GetChild(0).transform.position.z >= lastSelectedTarget.transform.position.z - 0.2 && lastSelectedTarget.GetChild(0).transform.position.z <= lastSelectedTarget.transform.position.z + 0.2)
        {
            // selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = false;
            lastSelectedTarget.GetChild(0).transform.position = new Vector3(
                lastSelectedTarget.transform.position.x, 
                lastSelectedTarget.transform.position.y, 
                lastSelectedTarget.transform.position.z);



            grid.GetComponent<GenerateGrid>().removeCheck(defaultMat);
            grid.GetComponent<GenerateGrid>().removeMoveCheck(defaultMat);
            ////reset the selected hex
            //selectionRenderer.material = oldMat;
            ////nothing is selected anymore
            //clickedHex = false;
            ////revert all the highlighted hexes to their original colors
            //grid.GetComponent<GenerateGrid>().removeCheck(defaultMat);
            ////null the selected hex
            //selectedTarget = null;
            ////go back to raycasting on our default hex layer
            //currentMask = 1 << 8;
            swapRange();
            removeRangeInd();
            isMoving = false;
            GridOb.currTurn = GridOb.turnOrder[GridOb.k].transform.parent.gameObject;

            actorData data = lastSelectedTarget.GetChild(0).GetComponent<actorData>();
            data.resetLookTarget();
        }
    }

    public void selectHex(GameObject hexSelected)
    {
        // if(sm.castPreviewEnabled) return;
        
        Transform transformSelected = hexSelected.transform;
        currClickedHex = hexSelected;
        //Debug.Log("test");
        //Debug.Log(transformSelected);
        //Debug.Log(selectedTarget);
        if (hoveredMat == false)
        {
            selectionRenderer.material = selectionMaterial;
        }

        if (clickedHex == false)
        {
            
            ////////////////////////////
            //temporary testing measure, this allows us to easilly add units to the battlefield at run time for testing purposes
            if (transformSelected.childCount == 0)
            {
                //when you click ka hex, we instantiate a unit at that location, name it, and child it to that hex. 
                // GameObject newUnit = (GameObject)Instantiate(unitPrefab, new Vector3(transformSelected.transform.position.x, 0.8f, transformSelected.transform.position.z), Quaternion.identity);
                // newUnit.name = unitPrefab.name;
                // newUnit.transform.SetParent(transformSelected.transform);
                // newUnit.GetComponent<NavMeshAgent>().enabled = false;

            }
            ///////////////////////////
            else
            {
                //save the hovered target as a selected one
                selectedTarget = transformSelected;
                clickedHex = true;
                lifeBox.text = selectedTarget.GetComponentInChildren<actorData>().Life.ToString();
                attackBox.text = selectedTarget.GetComponentInChildren<actorData>().baseDamage.ToString();
                unitBox.text = selectedTarget.GetComponentInChildren<actorData>().actorName.ToString();
                actionsLeft.text = selectedTarget.GetComponentInChildren<actorData>().actionsRemaining.ToString();

                if(selectedTarget.GetComponentInChildren<actorData>().affectedbyBuff)
                {
                    buffDescField.text = "This unit is affected by " + selectedTarget.GetComponentInChildren<actorData>().buffName + 
                    ". This unit gains " + selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " + selectedTarget.GetComponentInChildren<actorData>().buffProperty;
                    buffDescField.color = Color.green;
                }

                if(selectedTarget.GetComponentInChildren<actorData>().affectedbyDebuff)
                {
                    buffDescField.text = "This unit is affected by " + selectedTarget.GetComponentInChildren<actorData>().buffName + 
                    ". This unit suffers " + selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " + selectedTarget.GetComponentInChildren<actorData>().buffProperty;
                   
                    buffDescField.color = Color.red;
                }

                selectedTarget.GetComponentInChildren<actorData>().overheadReference.SetActive(true);
                im.highlighObject(selectedTarget.GetChild(0).gameObject, "Character");
                GameObject tempCircle = Instantiate(selectionCircle, selectedTarget.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
                tempCircle.transform.parent = selectedTarget.transform.GetChild(0).gameObject.transform;
                listSelectionCircles.Add(tempCircle);
                
                if(selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference != null)
                {
                    selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference.GetComponent<Image>().material = initativeMaterialHighlight;
                }
                
                //swap the mask to our legal hex layer for raycasting
                currentMask = 1 << 10;
                //swap to the appropriate range
                swapRange();
                //run the range detection script
                if (isMove)
                {
                    //Debug.Log("test");
                    grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, selectionMaterial);
                }
                else
                {
                    grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, selectionMaterial);
                }
            }
            return;
        }
        else if (clickedHex == true)
        {
            //movement
            GameObject currentChar = selectedTarget.transform.GetChild(0).gameObject;

            if (transformSelected != null && Input.GetMouseButtonUp(0) && isMove && transformSelected.childCount <= 0 && currentChar.GetComponent<actorData>().actionsRemaining >0 && currentChar.GetComponent<actorData>().isTurn)
            {
                if (selectedTarget != null )
                {
                    GridOb.choosePath(selectedTarget.gameObject, hoveredTarget.gameObject);

                }
                runMovement();
                selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().actionsRemaining -= 1;
                return;
                //grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);   
            }

            //attack
            else if (!isMove && transformSelected != null && Input.GetMouseButtonUp(0) && transformSelected.childCount > 0 && currentChar.GetComponent<actorData>().actionsRemaining > 0 && currentChar.GetComponent<actorData>().isTurn)
            {
                this.gameObject.GetComponent<BestClickToMove>().ClickAttack(selectedTarget.GetChild(0).gameObject, transformSelected.gameObject);
                selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().actionsRemaining -= 1;
                if (transformSelected.GetChild(0).gameObject.GetComponent<actorData>().Life <= 0)
                {
                    killUnit(transformSelected.GetChild(0).gameObject);
                }
                if (selectedTarget.GetComponentInChildren<actorData>().actionsRemaining == 0)
                {
                    GridOb.EndTurn();
                    playerTurnGUI.SetActive(true);
                }

                return;
            }
        }


    }

    public void selectHexFromGUI(GameObject hexSelected)
    {

         Transform transformSelected = hexSelected.transform;
         currClickedHex = hexSelected;
         //save the hovered target as a selected one
         selectedTarget = transformSelected;
         clickedHex = true;
         lifeBox.text = selectedTarget.GetComponentInChildren<actorData>().Life.ToString();
         attackBox.text = selectedTarget.GetComponentInChildren<actorData>().baseDamage.ToString();
         unitBox.text = selectedTarget.GetComponentInChildren<actorData>().actorName.ToString();
         actionsLeft.text = selectedTarget.GetComponentInChildren<actorData>().actionsRemaining.ToString();

         if (selectedTarget.GetComponentInChildren<actorData>().affectedbyBuff)
         {
             buffDescField.text = "This unit is affected by " + selectedTarget.GetComponentInChildren<actorData>().buffName +
             ". This unit gains " + selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " + selectedTarget.GetComponentInChildren<actorData>().buffProperty;
             buffDescField.color = Color.green;
         }

         if (selectedTarget.GetComponentInChildren<actorData>().affectedbyDebuff)
         {
             buffDescField.text = "This unit is affected by " + selectedTarget.GetComponentInChildren<actorData>().buffName +
             ". This unit suffers " + selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " + selectedTarget.GetComponentInChildren<actorData>().buffProperty;

             buffDescField.color = Color.red;
         }

         selectedTarget.GetComponentInChildren<actorData>().overheadReference.SetActive(true);
         im.highlighObject(selectedTarget.GetChild(0).gameObject, "Character");
         GameObject tempCircle = Instantiate(selectionCircle, selectedTarget.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
         tempCircle.transform.parent = selectedTarget.transform.GetChild(0).gameObject.transform;
         listSelectionCircles.Add(tempCircle);

         if (selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference != null)
         {
             selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference.GetComponent<Image>().material = initativeMaterialHighlight;
         }


         //swap the mask to our legal hex layer for raycasting
         currentMask = 1 << 10;
         //swap to the appropriate range
         swapRange();
         //run the range detection script
         if (isMove)
         {
             //Debug.Log("test");
             grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, selectionMaterial);
         }
         else
         {
             grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, selectionMaterial);
         }

        removeRangeInd();
        isMoving = false;



    }
    public void killUnit(GameObject deadUnit)
    {
        GridOb.allyList.Remove(deadUnit);
        GridOb.enemyList.Remove(deadUnit);
        GridOb.turnOrder.Remove(deadUnit);
        
        Destroy(deadUnit.GetComponent<actorData>().initiativeReference);

        guim.updateLog(deadUnit.name + " died.");
        Destroy(deadUnit, 3);


    }

    public void runMovement()
    {
        StartCoroutine(movementRoutine());
    }
    public void runMovement(GameObject start, GameObject end)
    {
        GridOb.choosePath(start, end);
        StartCoroutine(movementRoutine());
    }

    IEnumerator movementRoutine()
    {
        GameObject unit = selectedTarget.GetChild(0).gameObject;
        for (int i = 1; i < GridOb.path.Count; i++)
        {
            // selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = true;
            isMoving = true;
            this.gameObject.GetComponent<BestClickToMove>().ClickMove(selectedTarget.GetChild(0).gameObject, GridOb.path[i]);
            selectedTarget = GridOb.path[i].transform;
            yield return new WaitForSeconds(0.9f);
            if (isMoving == true)
            {
                finishMovement();

            }

            if (i + 1 < GridOb.path.Count)
            {
                selectedTarget = GridOb.path[i].transform;
            }

        }
        doneMoving = true;
        if (unit.GetComponent<actorData>().actionsRemaining == 0)
        {
            GridOb.EndTurn();
            playerTurnGUI.SetActive(true);
        }
        else
        {
            GridOb.NextTurn();
        }

    }
    public void moveRadius()
    {
        isMove = true;
        removeRangeInd();
        selectHex(currClickedHex);
        basicAttackButton.SetActive(true);
        //Debug.Log(isMove);
        //attackBox
        //detectRange = currClickedHex.transform.GetChild(0).GetComponent<actorData>().MovementRange;
        //swapRange();
    }
}


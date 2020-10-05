using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;
using UnityEngine.EventSystems;
using efe;

public class MouseControl : MonoBehaviour
{
    
    public EventSystem ev_system;
    [Header("GUI")]
    public TextMeshProUGUI lifeBox;
    public TextMeshProUGUI unitBox;
    public TextMeshProUGUI attackBox;
    public TextMeshProUGUI actionsLeft;
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
    [Space(5)]
    public GenerateGrid GridOb;
    public bool doneMoving;
    public GameObject selectionManager;

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
    //the transform of any hovered hexes
    public Transform hoveredTarget;
    //have you selected a hex for the purpose of checking the appropriate radius of its child?
    public bool clickedHex;
    //The renderer of any given selection
    Renderer selectionRenderer;
    spellManager sm;

    private void Start()
    {
        ev_system = EventSystem.current;
        //nothing is selected at the start
        clickedHex = false;
        doneMoving = true;
        
        sm = GameObject.FindGameObjectWithTag("GM").GetComponent<spellManager>();
    }

    private void Update()
    {
        if (isMoving == false) 
        { 
            //whenever there is no hovered target or cicked hex reset the last selected hex to its original material
            if (hoveredTarget != null)
            {
                //if youve clicked a hex we use the selection colors, otherwise we use our default hex colors
                if(clickedHex == true)
                {
                    oldMat = legalMove;
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

        // if(!EventSystem.current.IsPointerOverGameObject())
        // {
            //Ray cast from the mouse to find objects
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, currentMask))
                {
                    //save the selection and get its renderer
                    var selection = hit.transform;
                    selectionRenderer = selection.GetComponent<Renderer>();

                    //if we have not clicked a hex and the hovered object has a renderer we change the material to a hovered material, and declare it our selected target
                    // Hovering
                    if (selectionRenderer != null )
                    {
                        oldMat = selectionRenderer.material;
                        selectionRenderer.material = hoveredMat;
                        hoveredTarget = selection;

                        //if (selectedTarget != null && isMove && hoveredTarget != null)
                        //{
                        //    GridOb.choosePath(selectedTarget.gameObject, hoveredTarget.gameObject);
                        //}

                    }

                    //otherwise if you have selected a target, and you click on that object, we will revert it to its original material and reset the clicked Bool
                    // Deselection
                    if (selection == selectedTarget && Input.GetMouseButtonUp(0) && clickedHex == true)
                    {
                        removeRangeInd();
                        return;
                    }
                }

                //  if you click, while hovering a selected hex, and you have not already clicked a hex,
                //  change that object to the selected color and Declare that a hex has been clicked
                if (Input.GetMouseButtonUp(0) && hoveredTarget != null)
                {
                    selectHex(hoveredTarget.gameObject);
                }

            }
            else
            {
                finishMovement();
            }
        // }
    }

    //Switch the selected range to the appropriate range
    public void swapRange()
    {
        //if move, use move range, otherwise use the attack range
        if (isMove)
        {
            detectRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().MovementRange;
        }
        else
        {
            detectRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().AttackRange;
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
        selectedTarget = null;
        //go back to raycasting on our default hex layer
        currentMask = 1 << 8; 

        lifeBox.text = "";
        attackBox.text = "";
        unitBox.text = "";
        actionsLeft.text = "";
    }

    [ContextMenu("switch between attack or move")]
    public void moveAttackSwap()
    {
        Debug.Log("swap");
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
                grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, legalMove);
            }
            else
            {
                grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, legalMove);
            }
        }
        //reset and rehighlight appropriate hexes
    }


    public void finishMovement()
    {
        if (selectedTarget.GetChild(0).transform.position.x >= selectedTarget.transform.position.x - 0.2 && selectedTarget.GetChild(0).transform.position.x <= selectedTarget.transform.position.x + 0.2 && selectedTarget.GetChild(0).transform.position.z >= selectedTarget.transform.position.z - 0.2 && selectedTarget.GetChild(0).transform.position.z <= selectedTarget.transform.position.z + 0.2)
        {
            selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = false;
            selectedTarget.GetChild(0).transform.position = new Vector3(selectedTarget.transform.position.x, selectedTarget.transform.position.y, selectedTarget.transform.position.z);
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
        }
    }

    public void selectHex(GameObject hexSelected)
    {
        Transform transformSelected = hexSelected.transform;
        //Debug.Log("test");
        //Debug.Log(transformSelected);
        //Debug.Log(selectedTarget);
        if (hoveredMat == false)
        {
            selectionRenderer.material = selectedMat;
        }
        if (clickedHex == false)
        {
            ////////////////////////////
            //temporary testing measure, this allows us to easilly add units to the battlefield at run time for testing purposes
            if (transformSelected.childCount == 0)
            {
                //when you click ka hex, we instantiate a unit at that location, name it, and child it to that hex. 
                GameObject newUnit = (GameObject)Instantiate(unitPrefab, new Vector3(transformSelected.transform.position.x, 0.8f, transformSelected.transform.position.z), Quaternion.identity);
                newUnit.name = unitPrefab.name;
                newUnit.transform.SetParent(transformSelected.transform);
                newUnit.GetComponent<NavMeshAgent>().enabled = false;

            }
            ///////////////////////////
            else
            {
                //save the hovered target as a selected one
                selectedTarget = transformSelected;
                clickedHex = true;
                lifeBox.text = selectedTarget.GetComponentInChildren<prefabUnits>().Life.ToString();
                attackBox.text = selectedTarget.GetComponentInChildren<prefabUnits>().Damage.ToString();
                unitBox.text = selectedTarget.GetComponentInChildren<prefabUnits>().name.ToString();
                actionsLeft.text = selectedTarget.GetComponentInChildren<prefabUnits>().actionsRemaining.ToString();
                //swap the mask to our legal hex layer for raycasting
                currentMask = 1 << 10;
                //swap to the appropriate range
                swapRange();
                //run the range detection script
                if (isMove)
                {
                    grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, legalMove);
                }
                else
                {
                    grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, legalMove);
                }
            }
            return;
        }
        else if (clickedHex == true)
        {
            //movement
            GameObject currentChar = selectedTarget.transform.GetChild(0).gameObject;

            if (transformSelected != null && Input.GetMouseButtonUp(0) && isMove && transformSelected.childCount <= 0 && currentChar.GetComponent<prefabUnits>().actionsRemaining >0)
            {
                if (selectedTarget != null )
                {
                    GridOb.choosePath(selectedTarget.gameObject, hoveredTarget.gameObject);

                }
                runMovement();
                selectedTarget.GetChild(0).gameObject.GetComponent<prefabUnits>().actionsRemaining -= 1;
                return;
                //grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);   
            }

         

            //attack


            else if (!isMove && transformSelected != null && Input.GetMouseButtonUp(0) && transformSelected.childCount > 0 && currentChar.GetComponent<prefabUnits>().actionsRemaining > 0)
            {
                this.gameObject.GetComponent<BestClickToMove>().ClickAttack(selectedTarget.GetChild(0).gameObject, transformSelected.gameObject);
                selectedTarget.GetChild(0).gameObject.GetComponent<prefabUnits>().actionsRemaining -= 1;
                if (transformSelected.GetChild(0).gameObject.GetComponent<prefabUnits>().Life <= 0)
                {
                    killUnit(transformSelected.GetChild(0).gameObject);
                }
                if (selectedTarget.GetComponentInChildren<prefabUnits>().actionsRemaining == 0)
                {
                    GridOb.EndTurn();
                }

                return;
            }
        }


    }
    public void killUnit(GameObject deadUnit)
    {
        GridOb.allyList.Remove(deadUnit);
        GridOb.enemyList.Remove(deadUnit);
        GridOb.turnOrder.Remove(deadUnit);
        Destroy(deadUnit);


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
            selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = true;
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
        if (unit.GetComponent<prefabUnits>().actionsRemaining == 0)
        {
            GridOb.EndTurn();
        }
        else
        {
            GridOb.NextTurn();
        }

    }
}


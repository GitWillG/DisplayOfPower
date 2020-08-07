using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class MouseControl : MonoBehaviour
{
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
    private Renderer selectionRenderer;



    private void Start()
    {
        //nothing is selected at the start
        clickedHex = false;
    }

    private void Update()
    {
        if (isMoving == false) { 


      
        //whenever there is no hovered target or cicked hex reset the last selected hex to its original material
        if (hoveredTarget != null )
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




        //Ray cast from the mouse to find objects
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, currentMask))
        {
           //save the selection and get its renderer
            var selection = hit.transform;
            selectionRenderer = selection.GetComponent<Renderer>();

            //if we have not clicked a hex and the hovered object has a renderer we change the material to a hovered material, and declare it our selected target
            if (selectionRenderer != null )
            {
                oldMat = selectionRenderer.material;
                selectionRenderer.material = hoveredMat;
                hoveredTarget = selection;
            }

            //otherwise if you have selected a target, and you click on that object, we will revert it to its original material and reset the clicked Bool
            if (selection == selectedTarget && Input.GetMouseButtonUp(0) && clickedHex == true)
            {

                    removeRangeInd();
                    return;
            }
        }



            //if you click, while hovering a selected hex, and you have not already clicked a hex, change that object to the selected color and Declare that a hex has been clicked
            if (Input.GetMouseButtonUp(0) && hoveredTarget != null)
            {
                selectionRenderer.material = selectedMat;
                if (clickedHex == false)
                {


                    ////////////////////////////
                    //temporary testing measure, this allows us to easilly add units to the battlefield at run time for testing purposes
                    if (hoveredTarget.childCount == 0)
                    {
                        //when you click ka hex, we instantiate a unit at that location, name it, and child it to that hex. 
                        GameObject newUnit = (GameObject)Instantiate(unitPrefab, new Vector3(hoveredTarget.transform.position.x, 0.8f, hoveredTarget.transform.position.z), Quaternion.identity);
                        newUnit.name = unitPrefab.name;
                        newUnit.transform.SetParent(hoveredTarget.transform);
                        newUnit.GetComponent<NavMeshAgent>().enabled = false;

                    }
                    ///////////////////////////


                    else
                    {
                        //save the hovered target as a selected one
                        selectedTarget = hoveredTarget;
                        clickedHex = true;
                        //swap the mask to our legal hex layer for raycasting
                        currentMask = 1 << 10;
                        //swap to the appropriate range
                        swapRange();
                        //run the range detection script
                        grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);
                    }
                    return;
                }
                else if (clickedHex == true)
                {
                    //movement


                    if (hoveredTarget != null && Input.GetMouseButtonUp(0) && isMove && hoveredTarget.childCount <=0)
                    {
                        selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = true;
                        isMoving = true;
                        this.gameObject.GetComponent<BestClickToMove>().ClickMove(selectedTarget.GetChild(0).gameObject, hoveredTarget.gameObject);
                        selectedTarget = hoveredTarget;

                        return;
                        //grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);
                    }

                    //attack


                    else if (!isMove && hoveredTarget !=null &&Input.GetMouseButtonUp(0) && hoveredTarget.childCount > 0)
                    {
                        this.gameObject.GetComponent<BestClickToMove>().ClickAttack(selectedTarget.GetChild(0).gameObject, hoveredTarget.gameObject);
                        //selectedTarget.GetChild(0).gameObject.GetComponent<prefabUnits>().actions -= 1;
                        return;
                    }
                }
               


            }

        }
        else
        {
            if (selectedTarget.GetChild(0).transform.position.x >= selectedTarget.transform.position.x -0.2 && selectedTarget.GetChild(0).transform.position.x <= selectedTarget.transform.position.x + 0.2 && selectedTarget.GetChild(0).transform.position.z >= selectedTarget.transform.position.z - 0.2 && selectedTarget.GetChild(0).transform.position.z <= selectedTarget.transform.position.z + 0.2)
            {
                selectedTarget.GetChild(0).GetComponent<NavMeshAgent>().enabled = false;
                selectedTarget.GetChild(0).transform.position = new Vector3(selectedTarget.transform.position.x, 0.8f, selectedTarget.transform.position.z);
                grid.GetComponent<GenerateGrid>().removeCheck(defaultMat);
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
                removeRangeInd();
                
                isMoving = false;
            }
        }
    }



    //Switch the selected range to the appropriate range
    private void swapRange()
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

    private void removeRangeInd()
    {
        //reset the selected hex
        selectionRenderer.material = oldMat;
        //nothing is selected anymore
        clickedHex = false;
        //revert all the highlighted hexes to their original colors
        grid.GetComponent<GenerateGrid>().removeCheck(defaultMat);
        //null the selected hex
        selectedTarget = null;
        //go back to raycasting on our default hex layer
        currentMask = 1 << 8;
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
            grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);

        }
        //reset and rehighlight appropriate hexes
    }


}


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

    #region Inspector assigned Variables
    public EventSystem ev_system;
    //public GameObject basicAttackButton;
    #region GUI
    [Header("GUI")]
    public TextMeshProUGUI lifeBox;
    public TextMeshProUGUI unitBox;
    public TextMeshProUGUI attackBox;
    public TextMeshProUGUI actionsLeft;
    public TextMeshProUGUI buffDescField;
    public GameObject playerTurnGUI;
    public GameObject tutorial;
    #endregion
    #region Materials
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
    public Material currTurnMat;
    #endregion
    [Space(5)]
    #region Managers
    public GenerateGrid GridOb;
    public GameObject selectionManager;
    public GameObject currClickedHex;
    immersionManager im;
    //The renderer of any given selection
    Renderer selectionRenderer;
    spellManager sm;
    GUIManager guim;
    #endregion
    #region Grid Variables
    //detection range for movement/attacks
    public int detectRange;
    //this is our grid, we need access to it to swap grid colors
    public GameObject grid;
    //default layer to raycast on is the hex layer (8)
    public int currentMask =  1 << 10; 
    //Are we checking for movement radius? if not we are checking for attack radius
    public bool isMove = true;
    public bool isMoving;
    public bool doneMoving;
    #endregion

    //Temporary, we need access to the prefab we are using for unit testing
    public GameObject unitPrefab;

    #region Memory Variables
    //the transform of a selected hexes
    public Transform selectedTarget;
    public Transform lastSelectedTarget;
    //the transform of any hovered hexes
    public Transform hoveredTarget;
    //have you selected a hex for the purpose of checking the appropriate radius of its child?
    public bool clickedHex;
    #endregion

    #region Efe rename this i dunno what it's for
    public List<GameObject> listSelectionCircles;
    public List<GameObject> listRays;
    public GameObject rayParticle;
    public GameObject selectionCircle;
    public Material initativeMaterialHighlight;
    public Image curSelectedSprite;
    #endregion
    #endregion

    CameraControl cc;

    
    #region Runtime Functionality
    private void Start()
    {
        //nothing is moving
        isMoving = false;
        doneMoving = true;

        ev_system = EventSystem.current;
        //nothing is selected at the start
        clickedHex = false;
        selectionMaterial = legalMove;

        tutorial.SetActive(true);
        
        //get managers
        sm = GameObject.FindGameObjectWithTag("GM").GetComponent<spellManager>();
        guim = GameObject.FindGameObjectWithTag("GM").GetComponent<GUIManager>();
        im = GameObject.FindGameObjectWithTag("GM").GetComponent<immersionManager>();
        cc = Camera.main.GetComponent<CameraControl>();

        selectionMaterial = legalMove;
    }

    private void Update()
    {

        if (sm.castPreviewEnabled == true) return;
        //keep a memory of the last hex selected
        if(selectedTarget != null)
        {
            lastSelectedTarget = selectedTarget;
        }

        //as long as we haven't reached the end of the path, and stopped moving keep following the path
        if (GridOb.path.Count > 0)
        {
            if (isMoving == true)
            {

                newEndMove();
            }
            else
            {
                runMovement();
            }
        }

        //once units have reached their destination return functionality
        else
        {        
            //colour the selected unit's hex
            if (GridOb.currTurn != null)
            {
                GridOb.currTurn.GetComponent<Renderer>().material = currTurnMat;

            }
            //whenever there is no hovered target or cicked hex reset the last selected hex to its original material
            if (hoveredTarget != null)
            {


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
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    // Check if player is previewing a skill

                    if (Input.GetMouseButtonUp(1) && clickedHex == true)
                    {
                    if (!isMove)
                    {
                        selectionMaterial = legalMove;
                        moveRadius();
                    }
                    else if (selectedTarget != null)
                    {
                        removeRangeInd();
                    }
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
                    if (!sm.castPreviewEnabled)
                    {
                        // Moving units here
                        if (Input.GetMouseButtonUp(0) && hoveredTarget != null)
                        {
                            selectHex(hoveredTarget.gameObject);
                            // Debug.Log(4);
                        }
                    }

                }
            //}
        }
    }
    #endregion

    #region Change Selection Display

    #region Avoid Using
    //Switch the selected range to the appropriate range
    public void swapRange()
    {
        if (selectedTarget != null)
        {
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
                grid.GetComponent<GenerateGrid>().checkMoveLegality(detectRange, selectedTarget.gameObject, legalMove);
            }
            else
            {
                grid.GetComponent<GenerateGrid>().checkAttackLegality(detectRange, selectedTarget.gameObject, attackMat);
            }
        }
    }
    #endregion
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
        //selectedTarget.GetComponentInChildren<actorData>().overheadReference.SetActive(false);
        
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
        //currentMask = 1 << 8;
        currentMask = 1 << 10;

        lifeBox.text = "";
        attackBox.text = "";
        unitBox.text = "";
        actionsLeft.text = "";
        buffDescField.text = "";

        //curSelectedSprite.sprite = null;
        //lastSelectedTarget = null;

        foreach(Image t in guim.stanceIcons)
        {
            t.color = Color.gray;
        }


    }
   
    //switches to the movement radius of the currently selected unit 
    //or the unit whose turn it is if none are selected
    public void moveRadius()
    {
        isMove = true;
        if (selectedTarget == null)
        {
            selectedTarget = GridOb.currTurn.transform;
        }
        removeRangeInd();
        selectHex(currClickedHex);
        //basicAttackButton.SetActive(true);
    }
    #endregion

    #region Unit Selection
    public void selectHex(GameObject hexSelected)
    {
        //if(sm.castPreviewEnabled == true) return;
        
        Transform transformSelected = hexSelected.transform;
        currClickedHex = hexSelected;
        if (hoveredMat == false)
        {
            selectionRenderer.material = selectionMaterial;
        }

        if (clickedHex == false)
        {
            
            if (transformSelected.childCount > 0)
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
                    buffDescField.text =
                selectedTarget.GetComponentInChildren<actorData>().buffName + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffProperty; buffDescField.color = Color.green;
                }

                if(selectedTarget.GetComponentInChildren<actorData>().affectedbyDebuff)
                {
                    buffDescField.text =
                selectedTarget.GetComponentInChildren<actorData>().buffName + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffProperty;
                    buffDescField.color = Color.red;
                }


                
                im.highlighObject(selectedTarget.GetChild(0).gameObject, "Character");

                GameObject tempCircle = Instantiate(selectionCircle, selectedTarget.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
                tempCircle.transform.parent = selectedTarget.transform.GetChild(0).gameObject.transform;
                listSelectionCircles.Add(tempCircle);
                
                if(selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference != null)
                {
                    selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference.GetComponent<Image>().material = initativeMaterialHighlight;
                }

                curSelectedSprite.sprite = selectedTarget.GetComponentInChildren<actorData>().initiativeAvatar;
                foreach (Image t in guim.stanceIcons)
                {
                    t.color = Color.white;
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

            if (hoveredTarget != null)
            {
                if (hoveredTarget.childCount > 0 && isMove)
                {
                    removeRangeInd();
                    selectedTarget = hoveredTarget;
                    selectHex(selectedTarget.gameObject);
                    return;
                }
            }
            if (transformSelected != null && Input.GetMouseButtonUp(0) && isMove && transformSelected.childCount <= 0 && currentChar.GetComponent<actorData>().actionsRemaining > 0 && currentChar.GetComponent<actorData>().isTurn)
            {
                runMovement(selectedTarget.gameObject, hoveredTarget.gameObject);
                selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().actionsRemaining -= 1;
                return;
                //grid.GetComponent<GenerateGrid>().checkLegality(detectRange, selectedTarget.gameObject, legalMove);   
            }

            //attack
            else if (!isMove && transformSelected != null && Input.GetMouseButtonUp(0) && transformSelected.childCount > 0 && currentChar.GetComponent<actorData>().actionsRemaining > 0 && currentChar.GetComponent<actorData>().isTurn && GridOb.legalHex.Contains(transformSelected.gameObject) && !transformSelected.GetComponentInChildren<actorData>().belongsToPlayer)
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
            else if (!isMove && transformSelected != null && Input.GetMouseButtonUp(0) && transformSelected.childCount > 0 && !GridOb.legalHex.Contains(transformSelected.gameObject))
            {
                isMove = true;
                selectionMaterial = legalMove;
                removeRangeInd();
                selectedTarget = transformSelected;
                selectHex(selectedTarget.gameObject);
                return;
            }

            else if(!isMove && transformSelected != null && Input.GetMouseButtonUp(0) && transformSelected.childCount > 0 && GridOb.legalHex.Contains(transformSelected.gameObject) && transformSelected.GetComponentInChildren<actorData>().belongsToPlayer)
            {
                //Efe make this go into the player log please
                Debug.Log("That is an ally, friendly fire is bad :( ");

            }
        }


    }

    public void selectHexFromGUI(GameObject hexSelected)
    {
        if (selectedTarget != null)
        {
            removeRangeInd();
        }

         Transform transformSelected = hexSelected.transform;
         currClickedHex = hexSelected;
        selectedTarget = transformSelected;
        selectHex(transformSelected.gameObject);
         //save the hovered target as a selected one
         clickedHex = true;
         lifeBox.text = selectedTarget.GetComponentInChildren<actorData>().Life.ToString();
         attackBox.text = selectedTarget.GetComponentInChildren<actorData>().baseDamage.ToString();
         unitBox.text = selectedTarget.GetComponentInChildren<actorData>().actorName.ToString();
         actionsLeft.text = selectedTarget.GetComponentInChildren<actorData>().actionsRemaining.ToString();

         if (selectedTarget.GetComponentInChildren<actorData>().affectedbyBuff)
         {
             buffDescField.text = 
                selectedTarget.GetComponentInChildren<actorData>().buffName + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " +
                selectedTarget.GetComponentInChildren<actorData>().buffProperty;
             buffDescField.color = Color.green;
         }

         if (selectedTarget.GetComponentInChildren<actorData>().affectedbyDebuff)
         {
            buffDescField.text =
               selectedTarget.GetComponentInChildren<actorData>().buffName + " " +
               selectedTarget.GetComponentInChildren<actorData>().buffHeld + " " +
               selectedTarget.GetComponentInChildren<actorData>().buffProperty;
            buffDescField.color = Color.red;
         }

         //selectedTarget.GetComponentInChildren<actorData>().overheadReference.SetActive(true);

         im.highlighObject(selectedTarget.GetChild(0).gameObject, "Character");
         GameObject tempCircle = Instantiate(selectionCircle, selectedTarget.transform.GetChild(0).gameObject.transform.position, Quaternion.identity);
         tempCircle.transform.parent = selectedTarget.transform.GetChild(0).gameObject.transform;
         listSelectionCircles.Add(tempCircle);

         if (selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference != null)
         {
             selectedTarget.GetChild(0).gameObject.GetComponent<actorData>().initiativeReference.GetComponent<Image>().material = initativeMaterialHighlight;
         }
    }
    #endregion

    #region Unit Actions
    public void killUnit(GameObject deadUnit)
    {
        ////TESTING
        deadUnit.transform.parent.gameObject.layer = 8;


        //1.Remove dead unit from all lists it is a part of 
        GridOb.allyList.Remove(deadUnit);
        GridOb.enemyList.Remove(deadUnit);
        GridOb.turnOrder.Remove(deadUnit);

        //2. then destroy its place in the initiative
        Destroy(deadUnit.GetComponent<actorData>().initiativeReference);

        //3. then destroy the object
        guim.updateLog(deadUnit.name + " died.");
        Destroy(deadUnit, 3);


    }


    //method for if you have a path already
    public void runMovement()
    {
       //StartCoroutine(movementRoutine());
        newMovement();
    }

    //overload to include generating a path
    public void runMovement(GameObject start, GameObject end)
    {
        //1. Generate a path to follow
        GridOb.choosePath(start, end);

        //2. Follow path
        //StartCoroutine(movementRoutine());
        newMovement();
    }


    public void newMovement()
    {
        doneMoving = false;
        GameObject unit = selectedTarget.GetChild(0).gameObject;
        GridOb.currTurn.GetComponent<Renderer>().material = defaultMat;
        if (GridOb.path.Count > 0)
        {
            //while moving we disable all other player functionality
            isMoving = true;

            //1.a) move the unit to the new hex
            this.gameObject.GetComponent<BestClickToMove>().ClickMove(unit, GridOb.path[0]);

            //1.b) since we are controlling units based on their parent hex, we need to select the new hex.
            selectedTarget = GridOb.path[0].transform;

            ////TESTING
            lastSelectedTarget.gameObject.layer = 8;

        }
    }

    public void newEndMove()
    {

        if (Vector3.Distance(lastSelectedTarget.GetChild(0).transform.position, GridOb.path[0].transform.position) <= 0.2f)
        {
            //1. null velocity
            lastSelectedTarget.GetChild(0).GetComponent<NavMeshAgent>().velocity = new Vector3(0, 0, 0);


            //2. set unit position to new hex position
            lastSelectedTarget.GetChild(0).transform.position = new Vector3(
                GridOb.path[0].transform.position.x,
                GridOb.path[0].transform.position.y,
                GridOb.path[0].transform.position.z);

            //3. remove range indicators
            if (selectedTarget != null)
            {
                removeRangeInd();
            }

            //4. unit has reached first waypoint and stopped moving; remove this waypoint from the path
            selectedTarget = GridOb.path[0].transform;
            GridOb.path.RemoveAt(0);
            isMoving = false;
            currClickedHex = selectedTarget.gameObject;


            //once your path is empty:
            if (GridOb.path.Count <=0)
            {
                GridOb.currTurn = selectedTarget.gameObject;
                GridOb.currTurn.GetComponent<Renderer>().material = defaultMat;
                //1. reset unit orientation
                actorData data = lastSelectedTarget.GetChild(0).GetComponent<actorData>();
                data.resetLookTarget();
                moveRadius();
                removeRangeInd();
                //cc.panToObject(lastSelectedTarget.GetChild(0).gameObject);
                
                #region for AI
                //2. let the ai know it's done its entire movement
                doneMoving = true;
                #endregion
                //3. go to next turn
                GridOb.NextTurn();
            }


           
        }
    }
#endregion
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.AI;
using will;

namespace will{

public class BestMouseControl : MonoBehaviour
{
    //Selected hex material
    public Material selectedMat;
    //hovered hex material
    public Material hoveredMat;
    //original hexs material
    public Material oldMat;
    //legal radius material
    public Material legalMove;

    public GameObject grid;

    NavMeshAgent agent;


    //Temporary
    public GameObject unitPrefab;

    private Transform selectedTarget;
    private bool clickedHex;
    Renderer selectionRenderer;
    private void Start()
    {
        //nothing is selected at the start
        clickedHex = false;

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {



        //whenever there is no hovered target or cicked hex reset the last selected hex to its original material
        if (selectedTarget != null && clickedHex == false)
        {
            selectionRenderer = selectedTarget.GetComponent<Renderer>();
            selectionRenderer.material = oldMat;
            selectedTarget = null;

        }

        //Ray cast from the mouse to find objects
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        {
            //save the selection and get its renderer
            var selection = hit.transform;
            selectionRenderer = selection.GetComponent<Renderer>();
            //if we have not clicked a hex and the hovered object has a renderer we change the material to a hovered material, and declare it our selected target
            if (selectionRenderer != null && clickedHex == false)
            {
                oldMat = selectionRenderer.material;
                selectionRenderer.material = hoveredMat;
                selectedTarget = selection;
            }
            //otherwise if you have selected a target, and you click on that object, we will revert it to its original material and reset the clicked Bool
            else if (selection == selectedTarget && Input.GetMouseButtonUp(0))
            {
                //Debug.Log(selection);
                selectionRenderer.material = oldMat;
                clickedHex = false;
                int movableRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().MovementRange;
                //Debug.Log(movableRange);
                //checkRadius(selectedTarget.position, movableRange, oldMat, "Hex");
                grid.GetComponent<GenerateGrid>().removeCheck(oldMat);
                return;
            }
        }
        //if you click, while hovering a selected hex, and you have not already clicked a hex, change that object to the selected color and Declare that a hex has been clicked
        if (Input.GetMouseButtonUp(0) && selectedTarget != null && clickedHex == false)
        {
            selectionRenderer.material = selectedMat;
            clickedHex = true;

            ////////////////////////////
            //temporary testing measure
            if (selectedTarget.childCount == 0)
            {
                GameObject newUnit = (GameObject)Instantiate(unitPrefab, new Vector3(selectedTarget.transform.position.x, 0.8f, selectedTarget.transform.position.z), Quaternion.identity);
                newUnit.name = unitPrefab.name;
                newUnit.transform.SetParent(selectedTarget.transform);
            }
            else
            {
                int movableRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().MovementRange;
                Debug.Log(movableRange);
                //grid.GetComponent<GenerateGrid>().checkLegality(movableRange, selectedTarget.gameObject, selectedMat);
                //checkRadius(selectedTarget.position, movableRange, legalMove, "MovableHex");
            }
            ///////////////////////////
        }

    }

    private void checkRadius(Vector3 center, float radius, Material changeMat, string layerName)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius * 1.5f, 1 << 8);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<Renderer>().material = changeMat;
            //hitColliders[i].gameObject.layer = LayerMask.NameToLayer(layerName);
            //Debug.Log(hitColliders[i].transform.name);
            //hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }

    public void ClickMove()
    {
        //If Left click detected
        if (Input.GetMouseButtonDown(0))
        {
            //creating raycast to detect where mouse is clicked
            RaycastHit hit;

            //creates a raycast from the camera to the location of the mouse
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                //destination on the nav mesh is the location of where the raycast hit
                agent.destination = hit.point;
            }
        }
    }
}

}
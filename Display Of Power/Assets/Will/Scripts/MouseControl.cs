using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    //Selected hex material
    public Material selectedMat;
    //hovered hex material
    public Material hoveredMat;
    //original hexs material
    public Material oldMat;
    //legal radius material
    public Material legalMove;


    //Temporary
    public GameObject unitPrefab;

    private Transform selectedTarget;
    private bool clickedHex;
    Renderer selectionRenderer;
    private void Start()
    {
        //nothing is selected at the start
        clickedHex = false;
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
                Debug.Log(selection);
                selectionRenderer.material = oldMat;
                clickedHex = false;
                int movableRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().movementRange;
                Debug.Log(movableRange);
                checkRadius(selectedTarget.position, movableRange, oldMat);
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
                int movableRange = selectedTarget.GetChild(0).GetComponent<prefabUnits>().movementRange;
                Debug.Log(movableRange);
                checkRadius(selectedTarget.position, movableRange, legalMove);
            }
            ///////////////////////////
        }

    }
    private void checkRadius(Vector3 center, float radius, Material changeMat)
    {
        Collider[] hitColliders = Physics.OverlapSphere(center, radius* 1.6f, 1<<8);
        int i = 0;
        while (i < hitColliders.Length)
        {
            hitColliders[i].gameObject.GetComponent<Renderer>().material = changeMat;
            Debug.Log(hitColliders[i].transform.name);
            //hitColliders[i].SendMessage("AddDamage");
            i++;
        }
    }
}


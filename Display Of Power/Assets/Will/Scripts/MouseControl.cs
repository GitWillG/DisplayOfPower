using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public Material selectedMat;
    public Material hoveredMat;
    public Material oldMat;
    //private GameObject hitTarget;
    private Transform selectedTarget;
    private bool selectedHex;
    Renderer selectionRenderer;

    private void Start()
    {
        selectedHex = false;
    }
    private void Update()
    {
     
        if (selectedTarget != null && selectedHex == false)
        {
            selectionRenderer = selectedTarget.GetComponent<Renderer>();
            selectionRenderer.material = oldMat;
            selectedTarget = null;

        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
           
            var selection = hit.transform;
            selectionRenderer = selection.GetComponent<Renderer>();
            if (selectionRenderer != null && selectedHex == false)
            {
                oldMat = selectionRenderer.material;
                selectionRenderer.material = hoveredMat;
                selectedTarget = selection;
            }
            else if (selection == selectedTarget && Input.GetMouseButtonUp(0))
            {
                Debug.Log(selection);
                selectionRenderer.material = oldMat;
                selectedHex = false;
                return;
            }
        }
        if (Input.GetMouseButtonUp(0) && selectedTarget != null && selectedHex == false)
        {
            selectionRenderer.material = selectedMat;
            selectedHex = true;
        }

    }
}

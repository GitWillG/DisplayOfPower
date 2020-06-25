﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BestClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    BestSelectionScript selScr;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //If Left click detected
        if (Input.GetMouseButtonDown(1) && selScr.isSelected)
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

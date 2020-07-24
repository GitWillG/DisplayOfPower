using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BestClickToMove : MonoBehaviour
{
    NavMeshAgent agent;
    public NavMeshSurface surface;

    Renderer unitCol;
    public Material selectedMaterial;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //ClickMove();
    }

    public void ClickMove(GameObject unit, GameObject targetHex)
    {
        ////If Left click detected
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //creating raycast to detect where mouse is clicked
        //    RaycastHit hit;

        //    //creates a raycast from the camera to the location of the mouse
        //    if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        //    {
        //        //destination on the nav mesh is the location of where the raycast hit
        //        agent.destination = hit.point;
        //    }
        //}

        unitCol = unit.GetComponent<Renderer>();

        if (Input.GetMouseButtonDown(0))
        {
            if (unitCol.material == selectedMaterial)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
                {

                }
            }
        }
    }

}

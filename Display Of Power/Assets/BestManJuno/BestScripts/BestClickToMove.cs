using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BestClickToMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public NavMeshSurface surface;

    Renderer unitCol;
    public Material selectedMaterial;

    public Vector3 location;
    public GameObject feedbackParticle;


    // Start is called before the first frame update
    void Start()
    {
        //agent = GetComponent<NavMeshAgent>();

        //surface.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //ClickMove();
    }

    public void ClickMove(GameObject unit, GameObject targetHex)
    {
        ////If Left click detected
        //if (Input.GetMouseButtonUp(0))
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
        // unit.GetComponent<NavMeshAgent>().enabled = true;

        agent = unit.GetComponent<NavMeshAgent>();

        agent.destination = new Vector3(targetHex.transform.position.x, unit.transform.position.y, targetHex.transform.position.z);

        unit.transform.SetParent(targetHex.transform);

        //unitCol = unit.GetComponent<Renderer>();

        //if (Input.GetMouseButtonDown(0))
        //{
        //    if (unitCol.material == selectedMaterial)
        //    {
        //        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hit;
        //        if (Physics.Raycast(ray, out hit, Mathf.Infinity, 1 << 8))
        //        {

        //        }
        //    }
        //}
    }
    public void ClickAttack(GameObject unit, GameObject targetHex)
    {
        // unit = source/dealer
        // targetHex = target/receiver
        //subtract life from targetted unit equal to "damage" of selected unit
        targetHex.GetComponentInChildren<prefabUnits>().Life -= unit.GetComponent<prefabUnits>().Damage;
        targetHex.GetComponentInChildren<prefabUnits>().statObject.life -= unit.GetComponent<prefabUnits>().Damage;
        Instantiate(feedbackParticle, targetHex.transform.position, Quaternion.identity);
        
        Animator targetAnimator = targetHex.GetComponentInChildren<Animator>();
        Animator sourceAnimator = unit.GetComponent<Animator>();
        targetAnimator.SetTrigger("takeHit");
        sourceAnimator.SetTrigger("basicAttack");

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace efe
{
    public class mouseControls : MonoBehaviour
    {

        gameManager gm;

        GameObject playerToControl;
        // Start is called before the first frame update
        void Start()
        {
            gm = GetComponent<gameManager>();
            playerToControl = gm.curAvatar;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if(Physics.Raycast(ray, out hit, 1000))
                {playerToControl.GetComponent<NavMeshAgent>().SetDestination(hit.point);}
            }
        }
    }
}
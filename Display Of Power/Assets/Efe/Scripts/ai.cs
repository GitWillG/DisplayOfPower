using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using efe;

namespace efe{

    public class ai : MonoBehaviour
    {

        actorData data;
        NavMeshAgent agent;
        Animator animator;
        float[] x_radius = {-15, 15};
        float[] z_radius = {-15, 15};
        // Start is called before the first frame update
        void Start()
        {
            data = GetComponent<actorData>();
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();

            InvokeRepeating("orderWalkAround", 0, 5);
        }

        // Update is called once per frame
        void Update()
        {   
            
        }

        public void orderWalkAround()
        {
            if(data.peaceful)
            {
                if(data.walkAround)
                {   
                    Vector3 initial_position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    Vector3 target_position = new Vector3(Random.Range(x_radius[0], x_radius[1]), 0, Random.Range(z_radius[0], z_radius[1]));
                    initial_position += target_position;
                    agent.SetDestination(initial_position);
                    animator.SetFloat("Speed", 1);
                }
            }
        }
    }
}
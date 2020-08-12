using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe 
{
    public class faceCamera : MonoBehaviour
    {
    
        // Update is called once per frame
        void FixedUpdate()
        {
            this.transform.LookAt(Camera.main.transform);
        }
    }
}

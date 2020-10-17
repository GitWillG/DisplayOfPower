using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class CameraControl : MonoBehaviour
{
    //main camera
    Camera m_Camera;
    //a point at which the camera will move towards
    private Vector3 cameraFollow;
    //the Field of view of the camera (allows for zooming)
    private float currentFOV;
    private float zoomSpeed = 3f;
    GameObject objectToPan;
    bool isPanning = false;
    Vector3 panPosition;
    float camMoveSpeed = 3;
    void Start()
    {
        //Get the scenes main camera
        m_Camera = Camera.main;
        //set the follow position to the main cameras position to prevent issues with scene instantiation.
        cameraFollow = m_Camera.transform.position;
        //set the current FOV to the camera's default FOV
        currentFOV = m_Camera.fieldOfView;
    }
    
    public void panToObject(GameObject targetObject)
    {
        isPanning = true;
        objectToPan = targetObject;
    }

    // Update is called once per frame
    void Update()
    {   
    
        // WASD Camera steer
        //WASD allows a player to pan the camera
        //movement speed set to 20 at run time
        if(!isPanning)
        {
            float moveAmount = 20f;
            if ((Input.GetKey(KeyCode.W)))
            {
                cameraFollow.z += moveAmount * Time.deltaTime;
            }
            if ((Input.GetKey(KeyCode.S)))
            {
                cameraFollow.z -= moveAmount * Time.deltaTime;
            }
            if ((Input.GetKey(KeyCode.A)))
            {
                cameraFollow.x -= moveAmount * Time.deltaTime;
            }
            if ((Input.GetKey(KeyCode.D)))
            {
                cameraFollow.x += moveAmount * Time.deltaTime;
            }

            // Edge steering

            //Touching an edge of the screen will also pan the camera in that direction
            // float edgeSize = 3f;
            // if(Input.mousePosition.x < Screen.width && Input.mousePosition.y < Screen.height)
            // // {
            //     if (Input.mousePosition.x > Screen.width - edgeSize)
            //     {
            //         cameraFollow.x += moveAmount * Time.deltaTime;
            //     }
            //     if (Input.mousePosition.x < edgeSize)
            //     {
            //         cameraFollow.x -= moveAmount * Time.deltaTime;
            //     }
            //     if (Input.mousePosition.y > Screen.height - edgeSize)
            //     {
            //         cameraFollow.z += moveAmount * Time.deltaTime;
            //     }
            //     if (Input.mousePosition.y < edgeSize)
            //     {
            //         cameraFollow.z -= moveAmount * Time.deltaTime;
            //     }
            //     //Once we have moved the camera target to the appropriate position we move the actual camera there
                
            // }
            m_Camera.transform.position = cameraFollow;

            // Scroll wheel zoom

            //get the Scroll wheel input
            float scrollData;
            scrollData = Input.GetAxis("Mouse ScrollWheel");
            //Only zoom if you are actually scrolling 
            if (scrollData != 0.0)
            {
                //zoom in the direction scrolled
                currentFOV += Mathf.Sign(scrollData) * zoomSpeed;
            }
            //limit zoom in and outwards
            currentFOV = Mathf.Clamp(currentFOV, 20, 80);
            //move the camera in the clamped limits
            m_Camera.fieldOfView = currentFOV;
        }
        // Panning is true
        else if(isPanning)
        {

            panPosition = new Vector3
            (
                objectToPan.transform.position.x - 5,
                cameraFollow.y,
                objectToPan.transform.position.z - 5
            );
            cameraFollow = Vector3.MoveTowards(cameraFollow, panPosition, 1);
            
                if(Vector3.Distance(cameraFollow, panPosition) <= 3)
                {
                   StartCoroutine("resetPan", 1/4);
                }
        }


    }


    void rotateCamera()
    {
        
    }

    IEnumerator resetPan(float time)
    {
        yield return new WaitForSeconds(time);
        isPanning = false;
        
    }
}

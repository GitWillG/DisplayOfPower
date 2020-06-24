using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //main camera
    public Camera m_Camera;
    //a point at which the camera will move towards
    private Vector3 cameraFollow;
    //the Field of view of the camera (allows for zooming)
    private float currentFOV;
    private float zoomSpeed = 3f;
    void Start()
    {
        //Get the scenes main camera
        m_Camera = Camera.main;
        //set the follow position to the main cameras position to prevent issues with scene instantiation.
        cameraFollow = m_Camera.transform.position;
        //set the current FOV to the camera's default FOV
        currentFOV = m_Camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //WASD allows a player to pan the camera
        //movement speed set to 20 at run time
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
        //Touching an edge of the screen will also pan the camera in that direction
        float edgeSize = 3f;
        if (Input.mousePosition.x > Screen.width - edgeSize)
        {
            cameraFollow.x += moveAmount * Time.deltaTime;
        }
        if (Input.mousePosition.x < edgeSize)
        {
            cameraFollow.x -= moveAmount * Time.deltaTime;
        }
        if (Input.mousePosition.y > Screen.height - edgeSize)
        {
            cameraFollow.z += moveAmount * Time.deltaTime;
        }
        if (Input.mousePosition.y < edgeSize)
        {
            cameraFollow.z -= moveAmount * Time.deltaTime;
        }
        //Once we have moved the camera target to the appropriate position we move the actual camera there
        m_Camera.transform.position = cameraFollow;

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
}

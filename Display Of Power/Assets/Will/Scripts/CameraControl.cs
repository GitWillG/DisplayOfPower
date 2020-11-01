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
    bool isTracking = false;
    //public GameObject _trackTarget;
    Vector3 panPosition;
    Transform rightAnchor;
    Transform forwardAnchor;
    Transform backAnchor;
    Transform leftAnchor;
    // float camMoveSpeed = 3;
    // public GameObject anchor;
    // Vector3 cameraRight = anchor.transform.right;
    // Vector3 cameraForward = anchor.transform.forward;

    void Start()
    {
        //Get the scenes main camera
        m_Camera = Camera.main;
        //set the follow position to the main cameras position to prevent issues with scene instantiation.
        cameraFollow = m_Camera.transform.position;
        //set the current FOV to the camera's default FOV
        currentFOV = m_Camera.fieldOfView;

        rightAnchor = transform.Find("D");
        forwardAnchor = transform.Find("W");
        backAnchor = transform.Find("S");
        leftAnchor = transform.Find("A");

    }



    // Update is called once per frame
    void Update()
    {

        // WASD Camera steer
        //WASD allows a player to pan the camera
        //movement speed set to 20 at run time
        if (!isPanning || !isTracking)
        {
            // float moveAmount = 20f;
            // if ((Input.GetKey(KeyCode.W)))
            // {
            //     // anchor.transform.position += cameraRight * Time.deltaTime;
            //     cameraFollow.z += moveAmount * Time.deltaTime;
            // }
            // if ((Input.GetKey(KeyCode.S)))
            // {
            //     cameraFollow.z -= moveAmount * Time.deltaTime;
            // }
            // if ((Input.GetKey(KeyCode.A)))
            // {
            //     cameraFollow.x -= moveAmount * Time.deltaTime;
            // }
            // // left control is for debug tools
            // if (!Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.D)))
            // {
            //     cameraFollow.x += moveAmount * Time.deltaTime;
            // }

            if ((Input.GetKey(KeyCode.W)))
            {
                // anchor.transform.position += cameraRight * Time.deltaTime;
                cameraFollow = Vector3.MoveTowards(cameraFollow, forwardAnchor.position, 1);
            }
            if ((Input.GetKey(KeyCode.S)))
            {
                
                cameraFollow = Vector3.MoveTowards(cameraFollow, backAnchor.position, 1);
            }
            if ((Input.GetKey(KeyCode.A)))
            {
                cameraFollow = Vector3.MoveTowards(cameraFollow, leftAnchor.position, 1);
            }
            // left control is for debug tools
            if (!Input.GetKey(KeyCode.LeftControl) && (Input.GetKey(KeyCode.D)))
            {
                cameraFollow = Vector3.MoveTowards(cameraFollow, rightAnchor.position, 1);
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
        
        if(isPanning)
        {

            panPosition = new Vector3
            (
                objectToPan.transform.position.x - 5,
                cameraFollow.y,
                objectToPan.transform.position.z - 5
            );
            cameraFollow = Vector3.MoveTowards(cameraFollow, panPosition, Mathf.Infinity);
            
                if(Vector3.Distance(cameraFollow, panPosition) <= 3)
                {
                   StartCoroutine("resetPan", 1/4);
                }
        }
        
        if(isTracking)
        {
            panPosition = new Vector3
            (
                objectToPan.transform.position.x - 5,
                cameraFollow.y,
                objectToPan.transform.position.z - 5
            );
            cameraFollow = Vector3.MoveTowards(cameraFollow, panPosition, Mathf.Infinity);
        }


    }

    public void panToObject(GameObject targetObject)
    {
        isPanning = true;
        objectToPan = targetObject;
    }

    public IEnumerator panToObjectWithDelay(GameObject target, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        panToObject(target);
    }

    public void trackObject(GameObject targetObject)
    {
        isTracking = true;
        objectToPan = targetObject;

    }
    public void finishTracking()
    {
        isTracking = false;
        objectToPan = null;

    }

    void rotateCamera()
    {
        
    }

    IEnumerator resetPan(float time)
    {
        yield return new WaitForSeconds(time);
        isPanning = false;
        objectToPan = null;

    }
}

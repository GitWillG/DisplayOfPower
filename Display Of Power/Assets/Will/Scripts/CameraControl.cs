using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera m_Camera;
    private Vector3 cameraFollow;
    //public GameObject cameraBox;
    private float currentFOV;
    private float zoomSpeed = 3f;
    [SerializeField] private float zoomLerp = 10;
    // Start is called before the first frame update
    void Start()
    {

        m_Camera = Camera.main;
        cameraFollow = m_Camera.transform.position;
        currentFOV = m_Camera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
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

        m_Camera.transform.position = cameraFollow;

        float scrollData;

        scrollData = Input.GetAxis("Mouse ScrollWheel");

        if (scrollData != 0.0)
        {

            currentFOV += Mathf.Sign(scrollData) * zoomSpeed;
        }
        currentFOV = Mathf.Clamp(currentFOV, 20, 80);
        m_Camera.fieldOfView = currentFOV;



    }
}

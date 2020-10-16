using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using efe;

public class temp_initiativeDataHolder : MonoBehaviour
{   
    CameraControl cc;
    public GameObject referenceObject;

    void Start()
    {
        cc = Camera.main.GetComponent<CameraControl>();
    }
    

    public void Pan()
    {
        cc.panToObject(referenceObject);
        Debug.Log("Clicked");

    }
}

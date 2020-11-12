using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using efe;

public class temp_initiativeDataHolder : MonoBehaviour
{   
    CameraControl cc;
    MouseControl mc;
    public GameObject referenceObject;

    void Start()
    {
        cc = Camera.main.GetComponent<CameraControl>();
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();
    }
    

    public void Pan()
    {

        mc.selectHexFromGUI(referenceObject.transform.parent.gameObject);
        cc.panToObject(referenceObject);
        Debug.Log("Clicked" + referenceObject.transform.parent.gameObject.name);

    }
}

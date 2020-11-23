using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using efe;
using UnityEngine.UI;

public class temp_initiativeDataHolder : MonoBehaviour
{   
    CameraControl cc;
    MouseControl mc;
    public GameObject referenceObject;

    Vector3 scaleToGo;
    Vector3 oldScale;

    void Start()
    {
        cc = Camera.main.GetComponent<CameraControl>();
        mc = GameObject.FindGameObjectWithTag("SM").GetComponent<MouseControl>();

        scaleToGo = scaleToGo * 2;
        oldScale = transform.localScale;

    }

    private void Update()
    {
        if(referenceObject.GetComponent<actorData>().isTurn)
        {
            this.GetComponent<Image>().material = mc.initativeMaterialHighlight;
        }
        else
        {
            this.GetComponent<Image>().material = null;
        }
    }
    public void Pan()
    {

        mc.selectHexFromGUI(referenceObject.transform.parent.gameObject);
        cc.panToObject(referenceObject);
        Debug.Log("Clicked" + referenceObject.transform.parent.gameObject.name);

    }
}

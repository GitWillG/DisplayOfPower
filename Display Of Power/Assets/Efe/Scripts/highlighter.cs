using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(BoxCollider))]
public class highlighter : MonoBehaviour 
{


    private MeshRenderer curRenderer;

    [SerializeField]    
    private Material originalMaterial;

    [SerializeField]
    private Material highlightMaterial;
    // Start is called before the first frame update
    void Start()
    {
        curRenderer = GetComponent<MeshRenderer>();
        // originalMaterial = curRenderer.material;
        Debug.Log(this.gameObject.name);
        
    }

    void Update()
    {
        bool onOff = true;
        if(Input.GetMouseButtonDown(1))
        {   
            Debug.Log("Clicked");
            curRenderer.material = onOff ? highlightMaterial : originalMaterial;
        }
    }


    void EnableHighlight(bool onOff)
    {
        Debug.Log("1");
        if(curRenderer != null && originalMaterial != null && highlightMaterial != null)
        {
            Debug.Log("2");
            curRenderer.material = onOff ? highlightMaterial : originalMaterial;
        }

        Debug.Log("3");
    }

    private void onMouseOver(){EnableHighlight(true);Debug.Log("4");}
    private void onMouseExit(){EnableHighlight(false);Debug.Log("5");}
}

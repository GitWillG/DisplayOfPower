using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestSelectionScript : MonoBehaviour
{
    Color basicColor = Color.gray;
    Color hoverColor = Color.red;
    Renderer ren;

    bool isHovered = false;
    public bool isSelected = false;

    void Start()
    {
        ren = GetComponent<Renderer>();
        ren.material.color = basicColor;
    }

    void OnMouseEnter()
    {
        ren.material.color = hoverColor;
        isHovered = true;
    }

    void OnMouseExit()
    {
        ren.material.color = basicColor;
        isHovered = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isHovered)
        {
            isSelected = true;
            print(isSelected);
        }
        else if (Input.GetMouseButtonDown(0) && !isHovered)
        {
            isSelected = false;
            print(isSelected);
        }
    }
}

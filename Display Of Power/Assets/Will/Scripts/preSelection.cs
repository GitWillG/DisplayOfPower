using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using will;

namespace will{

public class preSelection : MonoBehaviour
{
    public GameObject grid;
    public GameObject preGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void makeGrid()
    {
        grid.SetActive(true);
        //preGO.SetActive(false);

    }
}
}
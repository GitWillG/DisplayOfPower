using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prefabUnits : MonoBehaviour
{
    public SO_Units statObject;
    public int movementRange;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        movementRange = statObject.movementRange;
        name = statObject.name;
        
    }

}

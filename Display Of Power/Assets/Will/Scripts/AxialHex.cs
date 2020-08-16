using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxialHex 
{
    public float q;
    public float r;

    public AxialHex(float qcoord, float rcoord)
    {
        q = qcoord;
        r = rcoord;
    }

    public AxialHex cube_to_axial(CubeUnit cube) {
        var q = cube.x;
        var r = cube.z;
        AxialHex newHex = new AxialHex(q,r);
        return newHex;
    }
}

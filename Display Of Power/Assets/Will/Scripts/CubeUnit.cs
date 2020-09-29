using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;



public class CubeUnit
{
    public float x;
    public float y;
    public float z;

    public CubeUnit(float xcord, float ycord, float zcord)
    {
        x = xcord;
        y = ycord;
        z = zcord;
    }

    // public CubeUnit Axial_to_Cube(AxialHex hex)
    // {
    //     float x = hex.q;
    //     float z = hex.r;
    //     float y = -x - z;
    //     CubeUnit newCube = new CubeUnit(x, y, z);
    //     return newCube;
    // }
    public static int cubeDistance(CubeUnit cubeA, CubeUnit cubeB)
    {
    return (int)(Mathf.Max(Math.Abs(cubeA.x - cubeB.x), Math.Abs(cubeA.y - cubeB.y), Math.Abs(cubeA.z - cubeB.z)));

    }
    public static CubeUnit cubeLerp(CubeUnit cubeA, CubeUnit cubeB, float t)
    {
        CubeUnit lerpCube = new CubeUnit(Mathf.Lerp(cubeA.x, cubeB.x, t), Mathf.Lerp(cubeA.y, cubeB.y, t), Mathf.Lerp(cubeA.z, cubeB.z, t));
        return lerpCube;
    }

    // public static List<CubeUnit> lineArray(CubeUnit cubeA, CubeUnit cubeB)
    // {
    //     int n = cubeDistance(cubeA, cubeB);
    //     List<CubeUnit> targetList = new List<CubeUnit>();
    //     for (int i= 0; i<n; i++)
    //     {
    //         targetList.Add(cubeLerp(cubeA, cubeB, (float)(1.0 / n * i)));
    //     }
    //     return targetList;

    // }
}




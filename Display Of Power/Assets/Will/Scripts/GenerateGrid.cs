﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    //nnumber of tiles along x axis of grid
    public int Width;
    //number of tilels along z axis of grid
    public int Depth;

    public GameObject hexPrefab;

    //actual dimensions of our prefab for refference
    private float hexWidth = 1.732f;
    private float hexDepth = 2f;

    //zOffset is 0.75 * depth of the hex
    public float zOffset = 1.5f;
    //xOffset is half of the Width
    public float xOffset = 0.866f;
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                float xPos = x *hexWidth;

                if (z% 2 == 1)
                {
                    xPos += xOffset;
                }

                Instantiate(hexPrefab, new Vector3(xPos, 0, z * zOffset), Quaternion.Euler(0, 90, 0));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

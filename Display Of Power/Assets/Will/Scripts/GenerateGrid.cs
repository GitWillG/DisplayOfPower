using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class GenerateGrid : MonoBehaviour
{
    //nnumber of tiles along x axis of grid
    public int Width;
    //number of tilels along z axis of grid
    public int Depth;

    public GameObject hexPrefab;

    ///////////////////////testing
    //public Material newmat;
    public GameObject testLocation;
    public GameObject[,] hexArray;
    public List<GameObject> legalHex;
    public Material testmat;
    public List<GameObject> postObCheck;
    //////////

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
        gridGeneration();
    }

    [ContextMenu("Generate Grid")]
    public void gridGeneration()
    {
        hexArray = new GameObject[Width, Depth];
        //2 Dimension grid
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                //change the default x positioning to fit the dimensions of the hex
                float xPos = x * hexWidth;

                //every odd row we offset the x position
                if (z % 2 == 1)
                {
                    xPos += xOffset;
                }
                //make a hex at the location and name it with its 2D dimensions
                GameObject hexOb = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, z * zOffset), Quaternion.Euler(0, 90, 0));
                hexOb.name = "Hex " + x + " " + z;
                hexOb.transform.SetParent(this.gameObject.transform);
                hexArray[x, z] = hexOb.gameObject;
                //Debug.Log(hexArray[x, z].gameObject);
            }
        }
    }

    public void gridGeneration(int gWidth, int gDepth)
    {
        Width = gWidth;
        Depth = gDepth;
        //2 Dimension grid
        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                //change the default x positioning to fit the dimensions of the hex
                float xPos = x * hexWidth;

                //every odd row we offset the x position
                if (z % 2 == 1)
                {
                    xPos += xOffset;
                }
                //make a hex at the location and name it with its 2D dimensions
                GameObject hexOb = (GameObject)Instantiate(hexPrefab, new Vector3(xPos, 0, z * zOffset), Quaternion.Euler(0, 90, 0));
                hexOb.name = "Hex " + x + " " + z;
                hexOb.transform.SetParent(this.gameObject.transform);
            }
        }
    }







    [ContextMenu("CheckRadius")]
    public void checkLegality(int radius, GameObject centerPoint, Material newMat)
    {
        //math
        //Debug.Log("test");
        int testRadius = radius;
        float xNum = 0;
        float zNum = 0;
        int centerX =0;
        int centerZ = 0;

        for (int x = 0; x < Width; x++)
        {
            for (int z = 0; z < Depth; z++)
            {
                if (centerPoint == hexArray[x, z].gameObject)
                {
                    centerX = x;
                    centerZ = z;

                    xNum = x - (z - (z & 1)) / 2;
                    zNum = z;


                }
            }
        }

        for (int a = 0; a < Width; a++)
        {
            for (int b = 0; b < Depth; b++)
            {
                float newx = a - (b - (b & 1)) / 2;
                float newz = b;
                float distance = Mathf.Max(Mathf.Abs(xNum - newx) + Mathf.Abs(xNum + zNum - newx - newz) + Mathf.Abs(zNum - newz));
                if (distance <= testRadius * 2)
                {
                    legalHex.Add(hexArray[a, b]);
                }

            }
        }
        //postObCheck = new List<GameObject>();
        //postObCheck.Add(centerPoint);
        //testRadius = 2;


        //for (int P = 1; P < radius; P++)
        //{
        //    foreach (GameObject hex in postObCheck.ToList())
        //    {
        //        for (int Q = 0; Q < 6; Q++)
        //        {
        //            if ()
        //        }
        //    }

        //}

















        //Debug.Log(legalHex);
        for (int i = 0; i < legalHex.Count; i++)
        {
            if (legalHex[i] != centerPoint)
            {
                legalHex[i].gameObject.GetComponent<Renderer>().material = newMat;
                legalHex[i].gameObject.layer = 10;
            }
            else
            {
                legalHex[i].gameObject.layer = 10;
            }
        }
    }
    public void removeCheck(Material newMat)
    {
        for (int i = 0; i < legalHex.Count; i++)
        {
            legalHex[i].gameObject.GetComponent<Renderer>().material = newMat;

            legalHex[i].gameObject.layer = 8;
        }
        legalHex.Clear();

    }
}

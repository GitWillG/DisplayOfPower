﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class baseAI : MonoBehaviour
{
    public GenerateGrid gridOb;
    public MouseControl mouseController;
    public GameObject target;
    public prefabUnits self;
    public GameObject hexTarget;
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject.GetComponent<prefabUnits>();
        self.isTurn = false;
        gridOb = GameObject.Find("grid").GetComponent<GenerateGrid>();
        mouseController = GameObject.Find("selectionManager").GetComponent<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (self.isTurn)
        {
            mouseController.selectedTarget = this.transform.parent;
            if (target == null)
            {
                findClosest();
            }
            //if (!mouseController.isMoving)
            //{
            //    if (self.actionsRemaining > 0)
            //    {
            //        Debug.Log(self.actionsRemaining);
            //        closeDistance();
            //    }
            //}
            //else
            //{
            //    //mouseController.finishMovement();
            //}
            closeDistance();
        }
        
    }

    private void findClosest()
    {
        List<float> distanceCheck = new List<float>();
        for (int i = 0; i< gridOb.allyList.Count; i++)
        {
            distanceCheck.Add(Vector3.Distance(this.transform.position, gridOb.allyList[i].transform.position));

            float minVal = distanceCheck.Min();
            int index = distanceCheck.IndexOf(minVal);
            target = gridOb.allyList[index].transform.gameObject;
        }
    }
    private void closeDistance()
    {
        List<float> moveDistCheck = new List<float>();
        gridOb.checkMoveLegality(self.MovementRange, this.transform.parent.gameObject, mouseController.legalMove);
        mouseController.currentMask = 1 << 10;

        //for (int j = 0; j < gridOb.tempList.Count; j++)
        //{
        //    moveDistCheck.Add(Vector3.Distance(target.transform.parent.position, gridOb.tempList[j].transform.position));
        //    float minVal = moveDistCheck.Min();
        //    int index = moveDistCheck.IndexOf(minVal);
        //    hexTarget = gridOb.tempList[index].transform.gameObject;

        //}
        //Debug.Log("create path");
        //gridOb.choosePath(this.transform.parent.gameObject, hexTarget);
        //Debug.Log("move");
        //mouseController.runMovement();
        //mouseController.selectedTarget.GetChild(0).gameObject.GetComponent<prefabUnits>().actionsRemaining -= 1;
        //return;
    }
}

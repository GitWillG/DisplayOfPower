﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace efe
{    
    public class cameraControl : MonoBehaviour
    {
    
    // 2 playfields are world map and levels.


    [Range(6, 200)]
    public float minFov;
    [Range(6, 200)]
    public float maxFov;
    float curFov;

    Camera mainCam;

    [Range(1, 100)]
    public float sensitivity;
    
    #region LayerMasks
    // [SerializeField]
    // LayerMask WorldMapLayer;
    // [SerializeField]
    // LayerMask LevelLayer;

    // static SortingLayer[] layersInProject;
    #endregion

    #region Transition
    public float transition_treshold_FOV; // the FOV number that will start the transition from 2 playfields
    bool transition_begins = false;
    #endregion

        void Start()
        {   
            
            #region Initilization
            // WorldMapLayer = LayerMask.GetMask("WorldMapObject");
            // LevelLayer = LayerMask.GetMask("LevelObject");

            transition_treshold_FOV = 40;
            minFov = 6;
            maxFov = 200;
            mainCam = Camera.main;
            mainCam.fieldOfView = 6;
            sensitivity = 2;
            // mainCam.cullingMask = LevelLayer;
            #endregion
        }
       

        // Update is called once per frame
        void Update()
        {
            curFov = mainCam.fieldOfView; // Get field of view from main camera.
            float mouseWheel = Input.GetAxis("Mouse ScrollWheel"); // Get scroll wheel input

            if(mouseWheel > 0)
            {
                curFov--;
            }
            else if(mouseWheel < 0)
            {
                curFov++;
            }

            curFov = Mathf.Clamp(curFov, minFov, maxFov);
            mainCam.fieldOfView = curFov;
        
            startTransition();
        
        }

        
        bool checkTransition()
        {
            
            if(curFov > transition_treshold_FOV)
            {
                return transition_begins = true;
            }
            else
            {
                return transition_begins = false;
            }
        }

        void startTransition()
        {
            // float length_masks = layersInProject.Length;
            
            checkTransition();
            if(transition_begins)
            {
                
                // for(int i = 0; i < length_masks; i ++)
                // {
                //     mainCam.cullingMask = WorldMapLayer + 1<<i -1; // add all layers except level layer to camera's culling mask
                // }

                // mainCam.cullingMask = WorldMapLayer;
                 Debug.Log("We are in world map.");
                
            }
            else{
                // mainCam.cullingMask = LevelLayer;
                  Debug.Log("We are in level.");
            }

        }
    }

}
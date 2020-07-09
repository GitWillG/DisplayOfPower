using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace efe
{
    
    
    public class cameraControl : MonoBehaviour
    {
    
    // 2 playfields are world map and levels.


    [Range(6, 200)]
    public float minFov = 6;
    [Range(6, 200)]
    public float maxFov = 200;
    float curFov;

    Camera mainCam;

    [Range(1, 100)]
    public float sensitivity = 2;
    
    [SerializeField]
    LayerMask WorldMapLayer;
    [SerializeField]
    LayerMask LevelLayer;

    static SortingLayer[] layersInProject;

    public float transition_treshold_FOV = 60; // the FOV number that will start the transition from 2 playfields
    bool transition_begins = false;

        void Start()
        {   
            
            WorldMapLayer = LayerMask.GetMask("WorldMapObject");
            LevelLayer = LayerMask.GetMask("LevelObject");

            transition_treshold_FOV = 60;
            minFov = 6;
            maxFov = 200;
            mainCam = Camera.main;
            mainCam.cullingMask = LevelLayer;
            
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
        
            // startTransition();
        
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
            float length_masks = layersInProject.Length;
            
            checkTransition();
            if(transition_begins)
            {
                
                for(int i = 0; i < length_masks; i ++)
                {
                    mainCam.cullingMask = WorldMapLayer + 1<<i -1; // add all layers except level layer to camera's culling mask
                }
                Debug.Log("We are in world map.");
                
            }
            else{
                mainCam.cullingMask = LevelLayer | 1<<3;
                Debug.Log("We are in level.");
            }

        }
    }

}
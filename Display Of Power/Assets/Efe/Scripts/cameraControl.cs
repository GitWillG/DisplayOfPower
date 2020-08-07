using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace efe
{    
    public class cameraControl : MonoBehaviour
    {
    
    // 2 playfields are world map and levels.


    public GameObject gameManager;

    [Range(6, 60)]
    public float minFov;
    [Range(6, 60)]
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

    // #region Transition
    // public float transition_treshold_FOV; // the FOV number that will start the transition from 2 playfields
    // public bool transition_begins = false;
    // #endregion


    #region  Tracking
    GameObject player;
    gameManager gm;


    [Header("Tracking Parameters")]
    [Range(-100, 100)]
    public float varZ;
    [Range(-100, 100)]
    public float varY;
    [Range(-100, 100)]
    public float varX;

    public static float[] worldMapCamera_param = {16, 18, 11}; // x, y, z
    public static float[] levelMapCamera_param = {6, 8, 4}; // x, y, z
    #endregion

        void Start()
        {   
            
            #region Initilization
            // WorldMapLayer = LayerMask.GetMask("WorldMapObject");
            // LevelLayer = LayerMask.GetMask("LevelObject");
            gm = gameManager.GetComponent<gameManager>();

            // Default is level
            varX = levelMapCamera_param[0];
            varY = levelMapCamera_param[1];
            varZ = levelMapCamera_param[2];

            // transition_treshold_FOV = 40;

            minFov = 6;
            maxFov = 60;

            mainCam = Camera.main;
            mainCam.fieldOfView = 6;
            sensitivity = 2;

            player = gm.curAvatar;
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

            trackPlayer();
        
        }

        public void trackPlayer()
        {
            // Tracking 
            player = gm.curAvatar;
            mainCam.transform.position = new Vector3(player.transform.position.x - varX, player.transform.position.y + varY, 
            player.transform.position.z - varZ);
        }
        // bool checkTransition()
        // {
            
        //     if(curFov > transition_treshold_FOV)
        //     {
        //         return transition_begins = true;
        //     }
        //     else
        //     {
        //         return transition_begins = false;
        //     }
        // }

        // void startTransition()
        // {
        //     // float length_masks = layersInProject.Length;
            
        //     checkTransition();
        //     if(transition_begins)
        //     {
                
        //         // for(int i = 0; i < length_masks; i ++)
        //         // {
        //         //     mainCam.cullingMask = WorldMapLayer + 1<<i -1; // add all layers except level layer to camera's culling mask
        //         // }

        //         // mainCam.cullingMask = WorldMapLayer;
        //          Debug.Log("We are in world map.");
                
        //     }
        //     else{
        //         // mainCam.cullingMask = LevelLayer;
        //           Debug.Log("We are in level.");
        //     }

        // }
    }

}
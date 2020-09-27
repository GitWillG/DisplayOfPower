using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

namespace efe
{    
    public class cameraControl_freeroam : MonoBehaviour
    {
    
    // Reference to game manager manually
    public GameObject gameManager;

    // Minimum zoom amount
    [Range(6, 60)]
    public float minFov;

    // Maximum zoom amount
    [Range(6, 60)]
    public float maxFov;
    float curFov;

    // Reference to main camera which is always called with camera.main
    Camera mainCam;

    // NOT USED YET
    // [Range(1, 100)]
    // public float sensitivity;
    
    // #region LayerMasks
    // // [SerializeField]
    // // LayerMask WorldMapLayer;
    // // [SerializeField]
    // // LayerMask LevelLayer;

    // // static SortingLayer[] layersInProject;
    // #endregion

    // #region Transition
    // public float transition_treshold_FOV; // the FOV number that will start the transition from 2 playfields
    // public bool transition_begins = false;
    // #endregion


    #region  Tracking
    GameObject player;
    gameManager gm;

    // Manually preserves his distance and position to player
    [Header("Tracking Parameters for Freeroam Camera")]
    [Range(-100, 100)]
    public float varZ;
    [Range(-100, 100)]
    public float varY;
    [Range(-100, 100)]
    public float varX;

    // Reposition camera for different playfields
    public static float[] worldMapCamera_param = {16, 18, 11}; // x, y, z
    public static float[] levelMapCamera_param = {8, 10, 6}; // x, y, z
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
            mainCam.fieldOfView = 26;

            // NOT USED YET
            // sensitivity = 2;
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

            // Track player avatar always
            trackPlayer();
            // playerCamDetection();
        
        }

        public void trackPlayer()
        {
            // Tracking 
            if(player != null)
            {
                player = gm.curAvatar;
                mainCam.transform.position = new Vector3(player.transform.position.x - varX, player.transform.position.y + varY, 
                player.transform.position.z - varZ);
            }
        }

        // Detects any object between camera and player
        void playerCamDetection()
        {
            player = gm.curAvatar;
            float distance = Vector3.Distance(player.transform.position, mainCam.transform.position);
            RaycastHit[] hits = hits = Physics.RaycastAll(mainCam.transform.position, transform.forward, 100.0f);
            foreach(RaycastHit hit in hits)
            {
                if(hit.transform.tag == "Flora")
                {
                    hit.transform.gameObject.SetActive(false);
                    Debug.Log(hit.transform.name);
                }
            }

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
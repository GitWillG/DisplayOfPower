using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using will;

// needs to be called "using efe;"
namespace efe
{
    public class gameManager : MonoBehaviour
    {

        #region State Change System
        // const string transition_Key = "M";
        GUIManager guim;
        gameManager gm;
        string[] stateStrings = {"World", "Level", "HUD"};
        [Header("Avatars")]
        public GameObject worldAvatar;
        public GameObject levelAvatar;
        public GameObject levelLight;
        public GameObject curAvatar;
        public playfields curPlayfield;

        [Header("Object Holders")]
        public GameObject _levelcategory;
        public GameObject _worldcategory;
        public gameStates curGameState;
        bool onWorld = false;
        // TODO - causes stack overflow investigate
        // bool onWorld{get {return onWorld; } set{onWorld = false;}}
        cameraControl cc;
        public enum playfields {onWorld, onLevel, onMenu}
        public enum gameStates {inBattle, freeroam}
        #endregion
        public GameObject lastSelectedTarget;
        public GameObject curLocation;
        public GameObject curHoveredObject;
        public static factionSO curFactionInEffect;
        public static GameObject curGUI;
        public GameObject curInteractedNPC;
        public List<GameObject> openGUIs;
        public GameObject selectionManager;
        mouseControls_freeroam mc;
        BestClickToMove bctm;
        preSelection preS;
        // Start is called before the first frame update
        void Start()
        {
            cc = Camera.main.GetComponent<cameraControl>();
            guim = GetComponent<GUIManager>();
            // levelAvatar = GameObject.FindGameObjectWithTag("LevelAvatar");
            // worldAvatar = GameObject.FindGameObjectWithTag("WorldAvatar");

            initializeState();
        }



        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                if(curPlayfield == playfields.onLevel)
                {
                    changeField("World");
                }
                else if(curPlayfield == playfields.onWorld)
                {
                    changeField("Level");
                }
            }
        }


        void initializeState()
        {
            curGameState = gameStates.freeroam;
            changeField("Level");
        }

        public void changeState(string targetString)
        {
            if(targetString == "Battle")
            {
                curGameState = gameStates.inBattle;
                guim.HUD.SetActive(false);
            }
            else if(targetString == "Free")
            {
                curGameState = gameStates.freeroam;
                guim.HUD.SetActive(true);
            }
            
            
            
        }

        public void changeField(string inputString)
        {

            if(inputString == null || curGameState == gameStates.inBattle)
            {
                Debug.Log("Couldn't change states. Input string is empty or you are in battle state." + inputString + " " + curGameState);
                return;
            }
            else
            {
                // onWorld = cc.transition_begins;
                if(inputString == stateStrings[0]) // World input in script
                {  
                    if(curPlayfield == playfields.onWorld) // If you are in world, no need to run the script
                    {
                        Debug.Log("You cannot change the state to world when you are in world already.");
                        return;
                    }
                    else{
                
                    curPlayfield = playfields.onWorld;
                    curAvatar = worldAvatar;
                    Debug.Log("Changed state to world.");
                    Time.timeScale = 1;

                    // _levelcategory.SetActive(false);

                    cc.varX = cameraControl.worldMapCamera_param[0];
                    cc.varY = cameraControl.worldMapCamera_param[1];
                    cc.varZ = cameraControl.worldMapCamera_param[2];
                    cc.trackPlayer();
                    
                    }   
                }
                if(inputString == stateStrings[1]) // Level input in script
                {  
                    if(curPlayfield == playfields.onLevel) // if you are already in levels, no need to run the script
                    {
                        Debug.Log("You cannot change the state to level when you are in level already.");
                        return;
                    }
                    else{
                    curPlayfield = playfields.onLevel;
                    curAvatar = levelAvatar;
                    Debug.Log("Changed state to level.");
                    Time.timeScale = 1;

                //    _worldcategory.SetActive(false);

                    cc.varX = cameraControl.levelMapCamera_param[0];
                    cc.varY = cameraControl.levelMapCamera_param[1];
                    cc.varZ = cameraControl.levelMapCamera_param[2];
                    cc.trackPlayer();
                    }
                }
                if(inputString == stateStrings[2]) // HUD input in script
                {  
                    if(curPlayfield == playfields.onMenu) // If you are in HUD, no need to run the script
                    {
                        Debug.Log("You cannot change the state to HUD when you are in HUD already.");
                        return;
                    }
                    else{
                    curPlayfield = playfields.onMenu;
                    Debug.Log("Changed state to HUD.");
                    Time.timeScale = 0;
                                        
                    }   
                }
            }
        }
    }
}
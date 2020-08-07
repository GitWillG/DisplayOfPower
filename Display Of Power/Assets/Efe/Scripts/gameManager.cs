using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace efe
{
    public class gameManager : MonoBehaviour
    {

        #region State Change System
        // const string transition_Key = "M";
        string[] stateStrings = {"World", "Level"};
        public GameObject worldAvatar;
        public GameObject levelAvatar;
        public GameObject levelLight;
        public GameObject curAvatar;
        public playfields curPlayfield;
        gameStates curGameState;
        bool onWorld = false;
        // TODO - causes stack overflow investigate
        // bool onWorld{get {return onWorld; } set{onWorld = false;}}
        cameraControl cc;
        public enum playfields {onWorld, onLevel, onMenu}
        public enum gameStates {inBattle, freeroam}
        #endregion
        public GameObject lastSelectedTarget;
        public GameObject curLocation;
        // Start is called before the first frame update
        void Start()
        {
            cc = Camera.main.GetComponent<cameraControl>();
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
                    changeState("World");
                }
                else if(curPlayfield == playfields.onWorld)
                {
                    changeState("Level");
                }
            }
        }


        void initializeState()
        {
            curGameState = gameStates.freeroam;
            changeState("Level");
        }

        public void changeState(string inputString)
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
                   

                    cc.varX = cameraControl.levelMapCamera_param[0];
                    cc.varY = cameraControl.levelMapCamera_param[1];
                    cc.varZ = cameraControl.levelMapCamera_param[2];
                    cc.trackPlayer();
                    }
                }
            }
        }
    }
}
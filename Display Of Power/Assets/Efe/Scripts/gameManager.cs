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
        public GameObject worldMapLight;
        public GameObject curAvatar;
        public GameObject curLight;
        public playfields curPlayfield;
        gameStates curGameState;
        bool onWorld = false;

        // TODO - causes stack overflow investigate
        // bool onWorld{get {return onWorld; } set{onWorld = false;}}
        cameraControl cc;
        public enum playfields {onWorld, onLevel, onMenu}
        public enum gameStates {inBattle, freeroam}
        #endregion


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
                changeState("World");
            }
        }


        void initializeState()
        {
            curPlayfield = playfields.onLevel;
            curGameState = gameStates.freeroam;
            curAvatar = levelAvatar;
            Debug.Log(curAvatar + " " + curPlayfield);
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
                onWorld = cc.transition_begins;
                if(inputString == stateStrings[0]) // World input in script
                {  
                    if(curPlayfield == playfields.onWorld) // If you are in world, no need to run the script
                    {
                        Debug.Log("You cannot change the state to world when you are in world already.");
                        return;
                    }
                    else{
                    curPlayfield = playfields.onLevel;
                    curAvatar = levelAvatar;
                    Debug.Log("Changed state to level.");
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
                    curPlayfield = playfields.onWorld;
                    curAvatar = worldAvatar;
                    Debug.Log("Changed state to world.");
                    }
                }
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using efe;

namespace efe {
public class settingsManager : MonoBehaviour
{
    public bool gameMuted;
    public EventSystem curEvent;

    public difficultySO curDifficulty;
    public difficultySO[] difficultyOptions;
    
    // Start is called before the first frame update
    void Start()
    {
        curEvent = EventSystem.current;
        gameMuted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialManager : MonoBehaviour
{
    public bool isTutorialOn;
    public GameObject alignerChecklist;
    public GameObject questTemplate_GUI;

    public void startTutorial()
    {
        isTutorialOn = true;
    }

    public void endTutorial()
    {
        isTutorialOn = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;
using UnityEngine.SceneManagement;

namespace efe{

public class sceneManager : MonoBehaviour
{
    public void openScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    public void quitGame()
    {
        Application.Quit();
    }
}
}
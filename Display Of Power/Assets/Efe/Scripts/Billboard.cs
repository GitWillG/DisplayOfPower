using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    
    // Called from each instance of overheadBar that spawns in the game
    void LateUpdate()
    {
        if (Camera.main == null) return;

        transform.LookAt(Camera.main.transform.position);
    }
}

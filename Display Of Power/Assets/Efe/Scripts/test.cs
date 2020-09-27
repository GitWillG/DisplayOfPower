using UnityEngine;
using System.Collections;
 
public class test : MonoBehaviour {
 
    // Simple "Paint" based on LineRenderer (Unity 5)
    // New properties appeared for class LineRender in version 2017.1
    public LineRenderer l;
 
    int len=2;
 
    // Update is called once per frame
    void Update () {
        // Vector2 mousePos = Input.mousePosition;
        // Vector3 pos3d = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x,mousePos.y,Camera.main.nearClipPlane));
        // // l.SetVertexCount(len);
        // l.SetPosition(len-1,pos3d);
        // len++;
    }
}
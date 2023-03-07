using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPerfectCamera : MonoBehaviour
{
    public static float pixelsToUnits = 1f;
    public static float scale = 1f;
    public Vector2 nativResolution = new Vector2 (240,160);
    // Start is called before the first frame update
    void Awake()
    {
        var camera = GetComponent<Camera> ();

        if(camera.orthographic){
            scale = Screen.height/nativResolution.y;
            pixelsToUnits *= scale;
            camera.orthographicSize = (Screen.height / 2.0f) /pixelsToUnits;
        }
    }

}

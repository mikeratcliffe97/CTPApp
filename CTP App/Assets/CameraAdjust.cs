using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAdjust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float xFactor = Screen.width / 1080f;
        float yFactor = Screen.height / 1920f;
        Camera.main.rect = new Rect(0, 0, 1, xFactor / yFactor);
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

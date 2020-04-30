using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code taken from a Unity forum
public class Fullscreen : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(1080, 1920, false, 0);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float cameraHeight = Camera.main.orthographicSize * 2;

        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        Vector2 scale = transform.localScale;
        if (cameraSize.x >= cameraSize.y)
        {
            scale *= cameraSize.x / spriteSize.x;
        }
        else
        {
            scale *= cameraSize.y / spriteSize.y;
        }

        transform.position = Vector2.zero;
        transform.localScale = scale;
    

    }
}

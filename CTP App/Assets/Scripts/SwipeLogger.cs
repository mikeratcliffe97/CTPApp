using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeLogger : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        SwipeDetect.OnSwipe += SwipeDetect_OnSwipe;
    }


    private void SwipeDetect_OnSwipe(SwipeData data)
    {

        Debug.Log("Swiped: " + data.Direction);
    }

}
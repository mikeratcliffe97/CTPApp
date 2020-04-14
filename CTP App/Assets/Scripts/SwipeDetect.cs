using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetect : MonoBehaviour
{

    private Vector2 fingerTouchPosition;
    private Vector2 fingerReleasePosition;

    [SerializeField]
    private bool detectSwipeAfterRelease = false;

    [SerializeField]
    private float minSwipeDistance = 20f;

    public static event System.Action<SwipeData> OnSwipe = delegate { };

    public bool swipeEnded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerTouchPosition = touch.position;
                fingerReleasePosition = touch.position;
            }

            if (!detectSwipeAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerReleasePosition = touch.position;
                DetectSwipe();
                swipeEnded = false;
                Debug.Log(swipeEnded);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                swipeEnded = true;
                Debug.Log(swipeEnded);
            }
         }

      
    }

    //Detects if swipe was vertical
  private bool SwipeVertical()
  {
        return VerticalMovementDistance() > HorizontalMovementDistance();
  }

    //Detects if swipe was a touch or a swipe
    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minSwipeDistance || HorizontalMovementDistance() > minSwipeDistance;
    }

    //Calculates distance of swipe
    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerTouchPosition.y - fingerReleasePosition.y);
    }

    //ditto but sideways
    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerTouchPosition.x - fingerReleasePosition.x);
    }


    //
    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if (SwipeVertical())
            {
                var direction = fingerTouchPosition.y - fingerReleasePosition.y < 0 ? SwipeDirection.Up : SwipeDirection.Down;
                SendSwipe(direction);
             
            }

            else
            {
                var direction = fingerTouchPosition.x - fingerReleasePosition.x > 0 ? SwipeDirection.Left : SwipeDirection.Right;
                SendSwipe(direction);
              
            }

            fingerReleasePosition = fingerTouchPosition;

        }
    }

    private void SendSwipe(SwipeDirection direction)
    {
        SwipeData swipeData = new SwipeData()
        {
            Direction = direction,
            StartPosition = fingerTouchPosition,
            EndPosition = fingerReleasePosition
    
        };

        OnSwipe(swipeData);


    }

}

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public SwipeDirection Direction;

}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right

}
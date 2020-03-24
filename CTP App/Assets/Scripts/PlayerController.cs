using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> PlayerPositions;
    [SerializeField]
    Button LeftButton;
    [SerializeField]
    Button MiddleButton;
    [SerializeField]
    Button RightButton;

    public Collider2D playercol;

    private int rightbound;
    private int leftbound;
    [SerializeField]
    private GameController game;
    // Start is called before the first frame update
    private void Start()
    {
        
     //   MiddleButton.onClick.AddListener(delegate { MoveMiddle(); });
      
            LeftButton.onClick.AddListener(delegate { MoveLeft(); });
            RightButton.onClick.AddListener(delegate { MoveRight(); });
        rightbound = (int)RightButton.transform.position.x;
        leftbound = (int)LeftButton.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void MoveLeft()
    {
        if (game.GameRunning)
        {
            float xPos = transform.position.x;
            if (xPos != leftbound)
            {
                xPos = xPos - 390;
            }
            transform.position = new Vector3(xPos, 400, 0);
        }
    }

    void MoveRight()
    {
        if (game.GameRunning)
        {
            float xPos = transform.position.x;
            if (xPos != rightbound)
            {
                xPos = xPos + 390;
            }
            transform.position = new Vector3(xPos, 400, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
            Debug.Log("Scored!");
         
           if (collision.gameObject.tag == "StarIcon")
            {
                game.score += 100;
            }

           if (collision.gameObject.tag == "Feeling")
            {
                game.score -= 25;
            }
           else if (collision.gameObject.tag != "Feeling" && collision.gameObject.tag != "StarIcon")
            {
                game.score += 10;
            }
            if (game.numObjects >= 1)
            {
                collision.gameObject.SetActive(false);
            }
        
    }
    //void MoveMiddle()
    //{
    //    float xPos = transform.position.x;
    //    xPos = 0;
    //    transform.position = new Vector3(xPos, 400, 0);
    //}



}

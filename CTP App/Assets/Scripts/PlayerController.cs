using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    int MAX_CATS = 21;
    [SerializeField]
    private List<GameObject> PlayerPositions;
    [SerializeField]
    Button LeftButton;
    [SerializeField]
    Button MiddleButton;
    [SerializeField]
    Button RightButton;

    public Collider2D playercol;

    [SerializeField]
    private List<GameObject> catsToDisplay;
   
    private GameObject catOnDisplay;
    [SerializeField]
    private int catNumber;
    
    
    public AudioClip catchNoise;


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
       
       int[] loadedStats = SaveManager.LoadAvatarStats();
       catNumber = loadedStats[4];
       AddCats();
       this.GetComponent<RawImage>().texture = catsToDisplay[catNumber].GetComponent<RawImage>().texture;
    }

   
    // Update is called once per frame
    void Update()
    {

     
    
    }

    void AddCats()
    {   
        catsToDisplay = new List<GameObject>();

        GameObject[] cat = GameObject.FindGameObjectsWithTag("Cat");
            for (int i = 0; i < MAX_CATS; i++)
            {
            catsToDisplay.Add(cat[i]);
            }

            Debug.Log(catsToDisplay.Count + "cats");
     
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
          

                game.catchNoise.PlayOneShot(catchNoise);


            
        }
            
        if (collision.gameObject.tag == "Feeling")
            {
                game.score -= 25;
            }
          
        else if (collision.gameObject.tag != "Feeling" && collision.gameObject.tag != "StarIcon")
            {
                game.score += 10;
            game.catchNoise.PlayOneShot(catchNoise);
        }
           
        if (game.numObjects >= 1)
            {
                collision.gameObject.SetActive(false);
            }

        }


       

    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectLanes;
    private List<Color> colourFeel;
    public GameObject ObjectSpawnPos;

    [SerializeField]
    private ObjectDrop droppers;

    public int score = 0;
    public int numObjects = 0;
    public int RightLane = 3;
    public int LeftLane = 0;
    public int ChosenLane = 0;

    public bool GameComplete = false;
    public bool GameRunning = false;

    private GameObject buttonObject;
    [SerializeField]
    private Button backButton;

    [SerializeField]
    private GameObject WinScreen;

    [SerializeField]
    private GameObject DefeatScreen;

   [SerializeField]
    private GameObject Heart;
    [SerializeField]
    private GameObject Star;

    [SerializeField]
    private GameObject Symptom;
    private TextMeshProUGUI symptomText;
    private int symptomNumber;
    
    private GameObject clone;
    private GameObject symptomClone;

    private int maxScore = 450;
   

    public Button StartButton;
    private TextMeshProUGUI m_TMP;
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI winscreenText;
    private TextMeshProUGUI defeatscreenText;
    private TextMeshProUGUI timer;
    float timeLeft = 100f;

    private RawImage heartObj;
    // Start is called before the first frame update

    //Random Number Gen to select which lane the object will spawn in


    void Start()
    {
        //StartCoroutine(NumberGen());
        StartButton.onClick.AddListener(delegate { StartCoroutine(StartGame()); });
        m_TMP = StartButton.GetComponentInChildren<TextMeshProUGUI>();

        buttonObject = StartButton.gameObject;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();

        timer = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();

        heartObj = GameObject.Find("HeartObject").GetComponent<RawImage>();
        symptomText = Symptom.GetComponentInChildren<TextMeshProUGUI>();

        winscreenText = WinScreen.GetComponentInChildren<TextMeshProUGUI>();
        defeatscreenText = DefeatScreen.GetComponentInChildren<TextMeshProUGUI>();
        Symptom.SetActive(false);
        Heart.SetActive(false);
        Star.SetActive(false);
     //   AssignColors();
    }

    void Awake()
    {
     
    }

   /* void AssignColors()
    {
        colourFeel = new List<Color>();
        Color red = heartObj.color;
         colourFeel.Add(red); 
        
        Color blue = new Color(49, 77, 121);
        colourFeel.Add(blue); 
        
        Color orange = new Color(248, 180, 69);
        colourFeel.Add(orange);
       
        
        Debug.Log(colourFeel.Count + " Colours");
    }*/
    // Update is called once per frame
    void Update()
    {
        float DT = Time.deltaTime / 1000;
        //  Debug.Log(DT);
        scoreText.text = "Score: " + score.ToString();
        timer.text = "Time left: " + Mathf.Round(timeLeft);
        if (GameRunning)
        {
            timeLeft -= Time.deltaTime;    
            if (timeLeft < 15)
            {
                droppers.fallspeed = 1.25f;
            }

            if (score >= maxScore || timeLeft <= 0)
            {
                CancelInvoke();
                StopAllCoroutines();
                GameRunning = false;
                GameComplete = true;
            }
        }

        if (GameComplete)
        {
            if (score >= maxScore)
            {
                WinScreen.SetActive(true);
                winscreenText.text = "Congratulations! \nYour score was: " + score;
            }

            else
            {
                DefeatScreen.SetActive(true);
                defeatscreenText.text = "Unlucky! \nYour score was: " + score;

            }
        }


    }


    IEnumerator StartGame()
    {
        //Starts a countdown for player, disables button and starts the random generator.
        m_TMP.text = "Starting";

        yield return new WaitForSeconds(1);

        m_TMP.text = "3";
        yield return new WaitForSeconds(1);
        m_TMP.text = "2";
        yield return new WaitForSeconds(1);
        m_TMP.text = "1";
        yield return new WaitForSeconds(1);
        m_TMP.text = "Go";

        yield return new WaitForSeconds(1);
        buttonObject.SetActive(false);
        GameRunning = true;
        if (GameRunning)
        {
            InvokeRepeating("ChooseLane", 2.0f, 3.0f);
            InvokeRepeating("SpawnObject", 3f, 3.1f);
            InvokeRepeating("SymptomDrop", 5, 10f);
        }

    }

    //IEnumerator NumberGen()
    //{
    //    while (GameRunning)
    //    { 
    //     ChosenLane = Random.Range(LeftLane, RightLane);
    //     yield return new WaitForSeconds(5);
           
    //        Debug.Log(ChosenLane);
    //    }
    //}

    int ChooseLane()
    {
        ChosenLane = Random.Range(0, 3);
        return ChosenLane;
    }


    void SpawnObject()
    {

        int objtoSpawn = Random.Range(0, 6);
      //  Debug.Log(objtoSpawn);
        Vector3 SpawnPos = new Vector3(ObjectLanes[ChosenLane].transform.position.x, 2000, 0);
    //    clone.tag = "Clone";
        switch (ChosenLane)
        {
            case 0:
                {

                    if (objtoSpawn <= 4)
                    {
                        clone = Instantiate(Heart, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                    }
                    else
                    {
                        clone = Instantiate(Star, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                        droppers.fallspeed = 1.5f;
                    }
                    numObjects++;
                    
                    break;
                }

            case 1:
                {
                    if (objtoSpawn <= 4)
                    {
                        clone = Instantiate(Heart, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                    }
                    else
                    {
                        clone = Instantiate(Star, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                        droppers.fallspeed = 1.5f;
                    }
                    numObjects++;
                    break;
                }

            case 2:
                {
                    if (objtoSpawn <= 4)
                    {
                        clone = Instantiate(Heart, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                    }
                    else
                    {
                        clone = Instantiate(Star, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                        clone.SetActive(true);
                        droppers.fallspeed = 1.5f;
                    }
                    numObjects++;
                    break;
                }

           
        }
           
    }

    void SymptomDrop()
    {
        symptomNumber = Random.Range(0, 7);
        Vector3 SpawnPos = new Vector3(ObjectLanes[ChosenLane].transform.position.x, 2000, 0);
        switch (symptomNumber)
        {
            case 0:
                {
                    symptomText.text = "Low";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);

                    break;
                }
            case 1:
                {
                    symptomText.text = "Tired";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }
            case 2:
                {
                    symptomText.text = "Stressed";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }
            case 3:
                {
                    symptomText.text = "Sad";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }
            case 4:
                {
                    symptomText.text = "Lonely";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }
            case 5:
                {
                    symptomText.text = "Anxious";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }
            case 6:
                {
                    symptomText.text = "Jittery";
                    symptomClone = Instantiate(Symptom, SpawnPos, Quaternion.identity, ObjectLanes[0].transform) as GameObject;
                    symptomClone.SetActive(true);
                    break;

                }

        }
       
    }
}
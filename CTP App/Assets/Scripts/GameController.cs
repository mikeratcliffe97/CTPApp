using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> ObjectLanes;

    public GameObject ObjectSpawnPos;


    public int score = 0;
    public int RightLane = 3;
    public int LeftLane = 1;
    public int ChosenLane = 0;
    public bool GameRunning = false;

    private GameObject buttonObject;
    

    public Button StartButton;
    private TextMeshProUGUI m_TMP;

    // Start is called before the first frame update

    //Random Number Gen to select which lane the object will spawn in


    void Start()
    {
        StartCoroutine(NumberGen());
        StartButton.onClick.AddListener(delegate { StartCoroutine(StartGame()); });
        m_TMP = StartButton.GetComponentInChildren<TextMeshProUGUI>();

        buttonObject = StartButton.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        float DT = Time.deltaTime;
        

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
          

    }

    IEnumerator NumberGen()
    {
        while (GameRunning)
        {
            ChosenLane = Random.Range(LeftLane, RightLane);
            yield return new WaitForSeconds(5);
        }
    }
}
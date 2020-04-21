using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AvatarManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Variables

    [SerializeField]
    public int Hunger = 0;
    [SerializeField]
    public int Boredom = 0;
    [SerializeField]
    public int Sleep = 0;

    public int currentHour;
   
    public int lastUsedHour;
   
    
    [SerializeField]
    public int catNumber;

    private int max_mood = 10;
    private float initialTime = 0;
    private Slider hSlider;
    private Slider bSlider;
    private Slider sSlider;
    private ParticleSystem mood;

    private Button FoodButton;
    // int FButton = 0;

    private List<GameObject> catsToDisplay;
    public GameObject catOnDisplay;
   [SerializeField]
    private CarouselSlider customU;


    private Button FButton1;
    private Button FButton2;
    private Button FButton3;

    private Button SleepButton;
    private Button SocialButton;
    private Button BoredButton;


    private Image hFill;
    private Image sFill;
    private Image bFill;

    private List<Color> colours;
    private Color baseColour;
    #endregion
    [SerializeField]
    private GameObject[] breathTexts;
   
   
    public bool AnimEnabled = false;
   [SerializeField]
    private Animation breath;
    void Awake()
    {
        AddCats();
    }

    void Start()
    {
        customU.catSelect.onClick.AddListener(delegate { CatSelect(); });
        breath = this.GetComponent<Animation>();
        #region Initalising Buttons
        hSlider = GameObject.Find("Hunger").GetComponent<Slider>();
        bSlider = GameObject.Find("Social").GetComponent<Slider>();
        sSlider = GameObject.Find("Sleep").GetComponent<Slider>();

        mood = GameObject.Find("MoodPsystem").GetComponent<ParticleSystem>();
        initialTime = Time.time;

        hFill = GameObject.Find("HFill").GetComponent<Image>();
        sFill = GameObject.Find("SFill").GetComponent<Image>();
        bFill = GameObject.Find("Bored").GetComponent<Image>();


        SocialButton = GameObject.Find("ActivityButton").GetComponent<Button>();
        FoodButton = GameObject.Find("FoodButton").GetComponent<Button>();
        FoodButton.onClick.AddListener(delegate { AddFood(); });

        SleepButton = GameObject.Find("SleepButton").GetComponent<Button>();
        SleepButton.onClick.AddListener(delegate { AddSleep(); });

        BoredButton = GameObject.Find("ActivityButton").GetComponent<Button>();
        BoredButton.onClick.AddListener(delegate { AddActivity(); });

        baseColour = mood.startColor;
        
      
        #endregion
    }

    public void CatSelect()
    {
        catNumber = customU.current_index;
    }

    

   public void AddCats()
    {
       
        catsToDisplay = new List<GameObject>();

      
       for (int i = 0; i < customU.images.Length; i++)
        {
            GameObject Cat = customU.images[i].gameObject;
            catsToDisplay.Add(Cat);
           
        }

        Debug.Log(catsToDisplay.Count + "cats");
    }
    // Update is called once per frame


    void Update()
    {
       this.GetComponent<RawImage>().texture = catsToDisplay[catNumber].GetComponent<RawImage>().texture;
        PlayAnimation();
        hSlider.value = (float)Hunger;
        bSlider.value = (float)Boredom;
        sSlider.value = (float)Sleep;

        int lowestMood;
        var amount = Mathf.Min(Mathf.Min(Hunger, Boredom), Sleep);

        #region StatsBar
        if (amount == Hunger)
        {
            lowestMood = Hunger;
            mood.startColor = hFill.color;
            //      colors.Add(hFill.color);

        }
        else if (amount == Boredom)
        {
            lowestMood = Boredom;
            mood.startColor = bFill.color;
            //    colors.Add(bFill.color);

        }

        else if (amount == Sleep)
        {
            lowestMood = Sleep;
            mood.startColor = sFill.color;
            //    colors.Add(sFill.color);
        }
  #endregion
        if (breath.isPlaying)
        {
            breathTexts[0].SetActive(true);
            breathTexts[1].SetActive(true);
        }
    
        if (!breath.isPlaying)
        {
            breathTexts[0].SetActive(false);
            breathTexts[1].SetActive(false);
        }

        currentHour = System.DateTime.Now.Hour;
    }

    #region ButtonCalculations
    public int AddSleep()
    {
        float timeSlept = 2;
        float _sleep = (float)Sleep;


        _sleep = _sleep + timeSlept;
        Debug.Log("bedtime");
        Sleep = (int)_sleep;
        return Sleep;
    }

    public float AddActivity()
    {
        float boredomCured = 2;
        float _bored = (float)Boredom;

        _bored = _bored + boredomCured;

        Boredom = (int)_bored;
        return Boredom;
    }



    public void AddFood()
    {
        FButton1 = GameObject.Find("FoodOption1").GetComponent<Button>();
        FButton2 = GameObject.Find("FoodOption2").GetComponent<Button>();
        FButton3 = GameObject.Find("FoodOption3").GetComponent<Button>();

        FButton1.onClick.AddListener(delegate { Food1(); });

        FButton2.onClick.AddListener(delegate { Food2(); });

        FButton3.onClick.AddListener(delegate { Food3(); });
        Debug.Log("YUMTIME");


    }


    public int Food1()
    {
        if (Hunger <= 5)
            Hunger = Hunger + 5;

        return Hunger;
    }

    public int Food2()
    {
        if (Hunger == 0)
        {
            Hunger = Hunger + 10;
        }
        return Hunger;
    }

    public int Food3()
    {

        Hunger = Hunger + 2;
        return Hunger;
    }

    #endregion
    public void SaveStats()
    {
        lastUsedHour = 2;
        SaveManager.SaveAvatarStats(this);
    }

    public void Load()
    {
        int[] loadedStats = SaveManager.LoadAvatarStats();
        Boredom = loadedStats[0];
        Sleep = loadedStats[1];
        Hunger = loadedStats[2];
        lastUsedHour = loadedStats[3];
        catNumber = loadedStats[4];
       
    }

        public void PlayAnimation()
        {
        if (AnimEnabled)
        {
            breath.Play();
            breath.wrapMode = WrapMode.Loop;
        }

        else { breath.Stop(); }
        }
      
    public void setAnimation()
    {
        AnimEnabled = !AnimEnabled;
    }
     

    }


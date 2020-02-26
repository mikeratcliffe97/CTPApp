using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AvatarManager : MonoBehaviour
{
    // Start is called before the first frame update

    public int Hunger = 0;
    public int Boredom = 0;
    public int Sleep = 0;
    private float initialTime = 0;
    private Slider hSlider;
    private Slider bSlider;
    private Slider sSlider;
    private ParticleSystem mood;

    private Button FoodButton;
    int FButton = 0;


    private Button FButton1;
    private Button FButton2;
    private Button FButton3;

    private Button SleepButton;
    private Button SocialButton;

    private Image hFill;
    private Image sFill;
    private Image bFill;

    private List<Color> colors;
    void Start()
    {
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

    }
    // Update is called once per frame
    void Update()
    {
       

        hSlider.value = (float)Hunger;
        bSlider.value = (float)Boredom;
        sSlider.value = (float)Sleep;

        int lowestMood;
        if (Hunger < Boredom || Hunger < Sleep)
        {
            lowestMood = Hunger;
            mood.startColor = hFill.color;
      //      colors.Add(hFill.color);
           
        }

        else if (Boredom < Hunger || Boredom < Sleep)
        {
            lowestMood = Boredom;
            mood.startColor = bFill.color;
        //    colors.Add(bFill.color);

        }

        else if (Sleep < Hunger || Sleep < Boredom)
        {
            lowestMood = Sleep;
            mood.startColor = sFill.color;
        //    colors.Add(sFill.color);
        }

       
    }


   public int AddSleep()
    {
        float timeSlept = 2;
        float _sleep = (float)Sleep;


        _sleep = _sleep + timeSlept;
        Debug.Log("bedtime");
        Sleep = (int)_sleep;
        return Sleep;
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
}

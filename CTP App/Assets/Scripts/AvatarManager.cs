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
}

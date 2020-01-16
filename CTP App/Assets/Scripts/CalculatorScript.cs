using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CalculatorScript : MonoBehaviour
{

    static int HOUR = 60;
    static int REM = 90;
    static int MDNIGHT = 24;
    public Button subbutton;
    public Button otherbutton;
    public TMPro.TMP_Dropdown hrvalue;
    public TMPro.TMP_Dropdown mntvalue;
    public TMPro.TMP_Text rechours;

    //// private Dropdown mntvalue;
    private int hourvalue;
    private int minutevalue;

  //Sleep hr = hours of sleep
    public int sleephr = 0;
    public int sleepmin = 0;
   
    public int cycles = 0;
  
    void Awake()
     {
      
        subbutton.onClick.AddListener(delegate { OnClick(); });
        otherbutton.onClick.AddListener(delegate { AltOnClick(); });
     }


    void CalculateREMHours()
    {   
       
        int crnthour = System.DateTime.Now.Hour;
        int crntminute = System.DateTime.Now.Minute;
      
        //Hour/minute input to calculator

        hourvalue = hrvalue.value;
        minutevalue = mntvalue.value;

       
            sleephr = ((MDNIGHT - crnthour) + hourvalue) - 1;
            sleepmin = ((HOUR - crntminute) + (minutevalue * 5));

        //Checks to see if its past 60
            if (sleepmin > HOUR)
            {
                sleepmin = sleepmin - HOUR;
                sleephr = sleephr + 1;
                }
        
            //Checks to see if its after midnight (00.30)
            if (sleephr > MDNIGHT)
          {
              sleephr = sleephr - MDNIGHT;
             }
      
            //Calculates rem cycles accounting for average fall asleep
        cycles = (((sleephr * HOUR) + (sleepmin - 14)) / REM);
        rechours.SetText("If you go to bed now," +
            " you will get " + cycles + " REM cycles");

    }


    void CalculateWakeHours()
    {
        int crnthour = System.DateTime.Now.Hour;
        int crntminute = System.DateTime.Now.Minute;

        

        //Accounting for time to fall asleep
        int wakeminute = crntminute + 44 ;


        int wakehour = crnthour + 7;

        if (wakeminute > HOUR)
        {
            wakehour = wakehour + 1;
            wakeminute = wakeminute - HOUR;
        }

        

       
     

        if (wakehour >= 24 || wakeminute < 10)
        {
            wakehour = wakehour - 24;
            if (wakeminute < 10)
            {
                rechours.SetText("You should wake up at around: {0}:0{1} to get the minimum recommended amount of sleep.", wakehour, wakeminute);
            }
 
        }
            rechours.SetText("You should wake up at around: {0}:{1} to get the minimum recommended amount of sleep.", wakehour, wakeminute);
    }

 


    void OnClick()
    {

        CalculateREMHours();
        Debug.Log(System.DateTime.Now.Hour);
        Debug.Log("hr" + hrvalue.value + "min" + (mntvalue.value * 5));
        Debug.Log(sleephr + ":" + sleepmin);
    }

    void AltOnClick()
    {
        CalculateWakeHours();
    }
}

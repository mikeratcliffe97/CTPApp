using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainContr : MonoBehaviour
{
   [SerializeField]
    private AvatarManager avatar;

    TimeSpan timeCount;
    DateTime lastChecked;


    private Button quitbutton;
    // Start is called before the first frame update
    void Start()
    {
         avatar.Load();
        
        quitbutton = GameObject.Find("Quit").GetComponent<Button>();
        quitbutton.onClick.AddListener(delegate { Quit(); });

        int year = DateTime.Now.Year,
        month = DateTime.Now.Month, 
        day = DateTime.Now.Day, 
        hour = avatar.lastUsedHour, 
        minute = DateTime.Now.Minute;
        //Initialise the date time with the record of when the user last logged in
        lastChecked = new DateTime(year, month, day, hour, minute, 0);      
        long ticks = 0;
        long.TryParse(avatar.lastUsedHour.ToString(), out ticks);
        timeCount = new TimeSpan(ticks);
      //Calculate the difference between the last log in and now
        StartCoroutine(statsCalculate());
        
    }

    void Awake()
    {
       
       // TimeEffect();
    }

    void TimeEffect()
    {
        //Check to see if stat is already at its minimum
        bool minBReached = false;
        bool minSReached = false;
        bool minHReached = false;
        if (avatar.Boredom <= 0)
        {
            minBReached = true;
        }

        if (avatar.Hunger <= 0)
        {
            minHReached = true;
        }

        if (avatar.Sleep <= 0)
        {
            minSReached = true;
        }
       
        //Removes stat based on the hours the user has not been on the app
        for (int i = 0; i < timeCount.Hours; i++)
        {
            if (i <= 10)
            {
                if (!minBReached)
                {
                    avatar.Boredom = avatar.Boredom - 1;
                }
                if (!minSReached)
                {
                    avatar.Sleep = avatar.Sleep - 1;
                }

                if (!minHReached)
                {
                    avatar.Hunger = avatar.Hunger - 1;
                }
            }

            else if (i > 10)
            {
                avatar.Hunger = 0;
                avatar.Sleep = 0;
                avatar.Sleep = 0;
            }

            Debug.Log("Removed stats: " + i);
        }
      
    }
    // Update is called once per frame
    void Update()
    {
     
    }

   IEnumerator statsCalculate()
    {
      
            DateTime now = DateTime.Now;
            timeCount += now - lastChecked;
            Debug.Log(timeCount.ToString());

            TimeEffect();
            yield return new WaitForSeconds(5);
        
    }

    void Quit()
    {
      
        Debug.Log("Bye");
        Application.Quit();
    }

    void OnApplicationQuit()
    {
        avatar.SaveStats();
    }
}

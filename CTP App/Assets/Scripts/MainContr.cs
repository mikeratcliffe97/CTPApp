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

        int year = DateTime.Now.Year, month = DateTime.Now.Month, day = DateTime.Now.Day, hour = avatar.lastUsedHour, minute = DateTime.Now.Minute;
        lastChecked = new DateTime(year, month, day, hour, minute, 0);
        
        
        long ticks = 0;

        long.TryParse(avatar.lastUsedHour.ToString(), out ticks);
        
        timeCount = new TimeSpan(ticks);

        StartCoroutine(statsCalculate());
        
    }

    void Awake()
    {
       
       // TimeEffect();
    }

    void TimeEffect()
    {

        for (int i = 0; i > timeCount.Hours; i++)
        {
            if (i <= 10)
            {

                avatar.Boredom = avatar.Boredom - 1;
                avatar.Sleep = avatar.Sleep - 1;
                avatar.Hunger = avatar.Hunger - 1;
            }

            else if (i > 10)
            {
                avatar.Hunger = 0;
                avatar.Sleep = 0;
                avatar.Sleep = 0;
            }
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

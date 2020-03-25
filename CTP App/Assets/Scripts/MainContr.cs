using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainContr : MonoBehaviour
{
   [SerializeField]
    private AvatarManager avatar;
    private int MDNIGHT = 24;

    private Button quitbutton;
    // Start is called before the first frame update
    void Start()
    {
        quitbutton = GameObject.Find("Quit").GetComponent<Button>();
        quitbutton.onClick.AddListener(delegate { Quit(); });
       
    }

    void Awake()
    {
         avatar.Load();
        TimeEffect();
    }

    void TimeEffect()
    {
        var currentHour = System.DateTime.Now.Hour;
    

        var timePassed = currentHour - avatar.logOffHour;

         
        
        for (int i = 0; i > timePassed; i++)
        {
            avatar.Boredom = avatar.Boredom - 1;
            avatar.Sleep = avatar.Sleep - 1;
            avatar.Hunger = avatar.Hunger - 1;
         
        }

    }
    // Update is called once per frame
    void Update()
    {
     
    }

    void RunSleepTutorial()
    {
       
    }

    void Quit()
    {
        avatar.SaveStats();
        Debug.Log("Bye");
        Application.Quit();
    }
}

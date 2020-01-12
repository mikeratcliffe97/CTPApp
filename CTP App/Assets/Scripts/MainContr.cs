using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainContr : MonoBehaviour
{

    private Button quitbutton;
    // Start is called before the first frame update
    void Start()
    {
        quitbutton = GameObject.Find("Quit").GetComponent<Button>();
        quitbutton.onClick.AddListener(delegate { Quit(); }); 
     
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
        Debug.Log("Bye");
        Application.Quit();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SceneChange : MonoBehaviour
{
    [SerializeField]
    private Button game1button;
    [SerializeField]
    private Button game2button;
    [SerializeField]
    private Button game3button;



    // Start is called before the first frame update
    void Start()
    {
     
            game1button.onClick.AddListener(delegate { LoadGame1(); });
      
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadGame1()
    {
        SceneManager.LoadScene(1);
     
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    GameController game;

    [SerializeField]
    private Button button;
    [SerializeField]
    private Button reset;
    [SerializeField]
    private Button altReset;
    // Start is called before the first frame update
   
    void Start()
    {
        altReset.onClick.AddListener(delegate { Reset(); });
        reset.onClick.AddListener(delegate { Reset(); });
        button.onClick.AddListener(delegate { Return(); });
    }

    // Update is called once per frame
   void Return()
    {
        SaveManager.SaveFeelings(game);
        
        SceneManager.LoadScene(0);
        
       
    }

    void Reset()
    {
        SceneManager.LoadScene(1);
    }
}

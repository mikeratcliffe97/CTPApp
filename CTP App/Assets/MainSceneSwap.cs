using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneSwap : MonoBehaviour
{
  
    private Button button;
    // Start is called before the first frame update
   
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(delegate { Return(); });
    }

    // Update is called once per frame
   void Return()
    {
        SceneManager.LoadScene(0);
    }
}

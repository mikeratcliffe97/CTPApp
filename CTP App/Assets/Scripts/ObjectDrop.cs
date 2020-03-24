using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ObjectDrop : MonoBehaviour
{

    private float yPos = 0;
    public float fallspeed = 0.5f;
    [SerializeField]
    int objectNumber = 0;
    [SerializeField]
    private GameController gameController;
    [SerializeField]
    private PlayerController player;

    private Button icon;

    
   
    // Start is called before the first frame update
    void Start()
    {
        objectNumber = gameController.numObjects;
        icon = this.gameObject.GetComponent<Button>();
        icon.onClick.AddListener(delegate { onCatch(); });
    }

    // Update is called once per frame
    void Update()
    {
        float DT = Time.deltaTime * 1000;
        if (gameController.GameRunning)
        {
            yPos = this.transform.position.y;
            



            yPos = yPos - (fallspeed * DT);

            this.transform.position = new Vector3(this.transform.position.x, yPos, 0);

            if (yPos < -2000)
            {
                if (objectNumber != 0)
                {
                    this.gameObject.SetActive(false);
                    
                }
            }
              
        }
    }

    void onCatch()
    {
        this.gameObject.SetActive(false);
    }

 
  
}

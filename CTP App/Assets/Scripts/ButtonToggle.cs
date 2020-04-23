using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonToggle : MonoBehaviour

{
    // Start is called before the first frame update
    
    public bool clicked;
    public int boolNumber;
    private Button parent;
    private AssignText assignText;
    void Start()
    {
        parent = this.gameObject.GetComponent<Button>();
        parent.onClick.AddListener( delegate { isToggled(); });
    }

    public void isToggled()
    {
         if (!clicked)
        {
            clicked = true;
        }
       
        else if (clicked)
        {
            clicked = false;
        }

     
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}

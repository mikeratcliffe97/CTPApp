using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool clicked;
    public int boolNumber;

    private AssignText assignText;
    void Start()
    {
       
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

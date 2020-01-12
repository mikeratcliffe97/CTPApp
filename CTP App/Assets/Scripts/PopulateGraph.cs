using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateGraph : MonoBehaviour
{

    private Button drawbutton;
    private Button subbutton;
    private TMP_InputField hourinput;
    public TMPro.TMP_Dropdown daycheck;
    public WindowGraph newgraph;
    public List<int> hoursSlept = new List<int>(7);
    
    // Start is called before the first frame update
    void Awake()
    {
       
       
        subbutton = GameObject.Find("Submit").GetComponent<Button>();
        subbutton.onClick.AddListener(delegate { PopulateList(); });
        hourinput = GameObject.Find("Input").GetComponent<TMP_InputField>();
        drawbutton = GameObject.Find("Draw").GetComponent<Button>();
        drawbutton.onClick.AddListener(delegate { newgraph.ShowGraph(hoursSlept); });
    }

    // Update is called once per frame
    void Update()
    {
  
    }


    void PopulateList()
    {

        int hours = 0;
        int dayofweek = daycheck.value;

        //Checks to see if number is a number
        if (int.TryParse(hourinput.text, out hours))
        {
            //Retrieves number from string
            hours = int.Parse(hourinput.text, System.Globalization.NumberStyles.Integer);

            //Checks if number is in range
            if (hours < 0 || hours > 16)
            {
                hourinput.text = ("Out of Range");
            }

            Debug.Log(hours);

            hoursSlept.RemoveAt(dayofweek);
            hoursSlept.Insert(dayofweek, hours);

            if (hoursSlept.Count > 6)
            {
                hoursSlept.RemoveAt(7);
            }

            //Fills graph with number
              //  newgraph.ShowGraph(hoursSlept);
         }
        

        else
        {
            hourinput.text = ("Not valid");
            Debug.Log("no");
        }

      //  fillgraph = GameObject.FindObjectOfType(typeof(ShowGraph)) as ShowGraph;

      
       
       
       


    }
}

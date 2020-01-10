using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateGraph : MonoBehaviour
{

    private Button subbutton;
    private TMP_InputField hourinput;
    public TMPro.TMP_Dropdown daycheck;
    public WindowGraph newgraph;
    // Start is called before the first frame update
    void Awake()
    {
       
       
        subbutton = GameObject.Find("Submit").GetComponent<Button>();
        subbutton.onClick.AddListener(delegate { PopulateList(); });
        hourinput = GameObject.Find("Input").GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void PopulateList()
    {

        List<int> hoursSlept = new List<int> {};

        int hours = 0;
        int test = daycheck.value;

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

            //switch (test)
            //{
            //    case 0:
            //        hoursSlept = new List<int> {}
            //        break;
            //}

           
               
            //Fills graph with number
                newgraph.ShowGraph(hoursSlept);
         }
        

        else
        {
            hourinput.text = ("Not valid");
            Debug.Log("no");
        }

       // fillgraph = GameObject.FindObjectOfType(typeof(ShowGraph)) as ShowGraph;

      
       
       
       


    }
}

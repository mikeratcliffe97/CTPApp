using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveDiagnosis : MonoBehaviour
{

    private Button[] buttons;
    private List<string> symptomstoAdd;
    private ButtonToggle buttonToggle;

    [SerializeField]
    private TxTReader reader;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GetComponentsInChildren<Button>();
        symptomstoAdd = new List<string>();
       
    }


    
    // Update is called once per frame
    void Update()
    {
        foreach (Button button in buttons)
        {
            buttonToggle = button.GetComponent<ButtonToggle>();
           
            if (buttonToggle.clicked)
                { 
                string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
                symptomstoAdd.Add(buttonText);
                buttonToggle.clicked = false;
                
                }
        }
    }


   public void WritetoFile()
    {
        reader.WriteDiagnosis(symptomstoAdd);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AssignText : MonoBehaviour
{
    private TextMeshProUGUI buttonText;

    public Button[] symptomButtons;

    private int numberOfButtons;

    public List<string> assignedSymptoms;

    private ButtonToggle buttonScript;

    [SerializeField]
    private TxTReader reader;
    // Start is called before the first frame update
    void Start()
    {
        
        symptomButtons = GetComponentsInChildren<Button>();
        numberOfButtons = symptomButtons.Length;

        assignedSymptoms = new List<string>(numberOfButtons);
      
        foreach(string _symptom in reader.symptomsFromFile)
        {
            int i = assignedSymptoms.Count;
            assignedSymptoms.Add(_symptom);
          
            buttonScript = symptomButtons[i].GetComponent<ButtonToggle>();
            buttonScript.boolNumber = i + 1;

        }
        AssignToButtons();
    }


    void AssignToButtons()
    {
        for (int i = 0; i < assignedSymptoms.Count; i++)
        {
            buttonText = symptomButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = assignedSymptoms[i];

        }
        for (int i = 0; i < symptomButtons.Length; i++)
        {
           
            if (i > assignedSymptoms.Count - 1)
            {
                symptomButtons[i].gameObject.SetActive(false);
            }
    } 
    
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}

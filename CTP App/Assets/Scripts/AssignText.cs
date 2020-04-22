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
    private SymptomReader reader;
    // Start is called before the first frame update
    void Start()
    {
        reader.LoadSymptoms();
        symptomButtons = GetComponentsInChildren<Button>();
        numberOfButtons = symptomButtons.Length;

        assignedSymptoms = new List<string>(numberOfButtons);
      
        foreach(string str in SaveManager.LoadDiagnosisStats())
        {
            int i = assignedSymptoms.Count;
          assignedSymptoms.Add(str.ToString());
          
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

using System.IO;
using UnityEngine;
using UnityEngine.UI;
[SerializeField]
public class SymptomCollection
{
  
    //collection of symptoms
    public Symptom[] symptoms;
    public string collectionName;

    public override string ToString()
    {
        string result = "SYMPTOMS\n";
            foreach (var symptom in symptoms)
        {
            result += string.Format("text: {0}\n", symptom.text);
        }
        return result;
    }
}

[SerializeField]
public class Symptom
{
  //symptoms contain name
    public string text = "";
}

public class SymptomReader : MonoBehaviour
{
    [SerializeField]
    public SymptomCollection SymptomCollection;
    string path;
    //Loads json into game
    private void Start()
    {

        
    }

    private void Awake()
    {
        path = Application.persistentDataPath + "/symptom.json";
        Debug.Log(path);
    }

    public void LoadSymptoms()
    {



        if (File.Exists(Application.persistentDataPath + "/symptom.json"))

        {
            using (StreamReader stream = new StreamReader(path))

            {
                string jsonStr = stream.ReadToEnd();
                SymptomCollection = new SymptomCollection();



             
                   
                // SymptomCollection._symptoms.ToString
                FindObjectOfType<Text>().text = SymptomCollection.ToString();

                Debug.Log("Loaded: " + SymptomCollection.symptoms.Length);




            }
        }
        else
        {
            //if json doesn't exist, create
            WriteSymptoms();
        }
    }


    public void WriteSymptoms()
    {
        GenerateSymptoms();

        using (StreamWriter stream = new StreamWriter(path))
        {
            string json = SymptomCollection.ToString();
           
            stream.Write(json);
        }
    }

    private void GenerateSymptoms()
    {
        Symptom[] symptoms = new Symptom[7];
        symptoms[0] = new Symptom() { text = "Low" };
        symptoms[1] = new Symptom() { text = "Tired" };
        symptoms[2] = new Symptom() { text = "Stressed" };
        symptoms[3] = new Symptom() { text = "Sad" };
        symptoms[4] = new Symptom() { text = "Lonely" };
        symptoms[5] = new Symptom() { text = "Anxious" };
        symptoms[6] = new Symptom() { text = "Jittery" };

        SymptomCollection = new SymptomCollection() { symptoms = symptoms, collectionName = "DefaultSymptoms" };
    }
}
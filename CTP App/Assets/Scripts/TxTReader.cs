using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class TxTReader : MonoBehaviour
{
    [SerializeField]
    public string[] symptomsFromFile;
    private string[] defSymptoms;
    private string path;

    static int max_string = 8;
    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/symptoms.txt";
        if (!File.Exists(path))
        {
            WriteToFile(defSymptoms);
        }

        else 
        {
            ReadFromFile();
        }
     }


    private void ReadFromFile()
    {
        
        if (File.Exists(path))
        {
            symptomsFromFile = File.ReadAllLines(path);
        }

        else
        {
            symptomsFromFile = defSymptoms;
        }
    }
    private void WriteToFile(string[] _defSymptoms)
    {
        GenerateSymptoms();
        _defSymptoms = defSymptoms;
      //  FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
       
        File.WriteAllLines(path, _defSymptoms);
      
    }

    public void WriteDiagnosis(List<string> diagnosis)
    {
        string dPath = Application.persistentDataPath + "/diagnosis.txt";

            string[] dString = diagnosis.ToArray();
            File.WriteAllLines(dPath, dString);

    }

    private void GenerateSymptoms()
    {

        defSymptoms = new string[max_string];
        defSymptoms[0] = "Low";
        defSymptoms[1] = "Tired";
        defSymptoms[2] = "Stressed";
        defSymptoms[3] = "Lonely";
        defSymptoms[4] = "Sad";
        defSymptoms[5] = "Anxious";
        defSymptoms[6] = "Jittery";
        defSymptoms[7] = "SampleSymptom/7";
        defSymptoms[8] = "SampleSymptom/8";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

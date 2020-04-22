using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class SaveManager
{
    // Start is called before the first frame update
   
    public static void SaveAvatarStats(AvatarManager mainAvatar)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/avatar.sav", FileMode.Create);
        AvatarStats data = new AvatarStats(mainAvatar);

        bf.Serialize(stream, data);
        stream.Close();

       
    }

   
    public static int[] LoadAvatarStats ()
    {
        if (File.Exists(Application.persistentDataPath + "/avatar.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/avatar.sav", FileMode.Open);

            AvatarStats data = bf.Deserialize(stream) as AvatarStats;

            stream.Close();

            return data.stats;
        }

        else
        {
            Debug.Log("Nah bro");
            return null;
        }
      
    }

    public static void SaveFeelings(GameController mainGame)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/feelings.sav", FileMode.Create);
        DiagnosisStats data = new DiagnosisStats(mainGame);

        bf.Serialize(stream, data);
        Debug.Log("Saved");
        stream.Close();
    }

    public static List<String> LoadDiagnosisStats ()
    {

        string filepath = Application.persistentDataPath + "/feelings.sav";
        if (File.Exists(filepath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(filepath, FileMode.Open);
            DiagnosisStats data = bf.Deserialize(stream) as DiagnosisStats;

            stream.Close();
            return data.statsList;
        }
        
        else 
        { 
            Debug.Log("No file here"); 
            return null; 
        }
    }
    //TODO: write load function
       
}

[Serializable]
public class AvatarStats
{
    public int[] stats;

    public AvatarStats(AvatarManager mainAvatar)
    {
        stats = new int[5];
        stats[0] = mainAvatar.Boredom;
        stats[1] = mainAvatar.Sleep;
        stats[2] = mainAvatar.Hunger;
        stats[3] = mainAvatar.lastUsedHour;
        stats[4] = mainAvatar.catNumber;    
    }
}


[Serializable]
public class DiagnosisStats
{

    public List<string> statsList;

    public DiagnosisStats(GameController mainGame)
    {
        //  int statSize = mainGame.Feelings.Count;

        statsList = new List<string>();

        if (mainGame.Feelings != null)
        {
            foreach (string str in mainGame.Feelings)
            {
                statsList.Add(str);
            }
        }

        else
        { 
                statsList.Add("cat");
               
        }
    }
      
}
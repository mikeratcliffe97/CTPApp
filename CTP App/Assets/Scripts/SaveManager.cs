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
       
}

[Serializable]
public class AvatarStats
{
    public int[] stats;

    public AvatarStats(AvatarManager mainAvatar)
    {
        stats = new int[4];
        stats[0] = mainAvatar.Boredom;
        stats[1] = mainAvatar.Sleep;
        stats[2] = mainAvatar.Hunger;
        stats[3] = System.DateTime.Now.Hour;
    }
}
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHandler
{
    public static string path = Application.persistentDataPath + "/PlayerOutfit.json"; //To enable saving on different operating systems (Mac, Windows, ...)

    public static PlayerOutfit ReadPlayerOutfitData()
    {
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);

            PlayerOutfit newPlayerOutfit = JsonUtility.FromJson<PlayerOutfit>(jsonString);

            return newPlayerOutfit;
        }
        else
        {
            Debug.Log("File not found");
            return null;
        }
    }

    public static void WritePlayerOutfitData(PlayerOutfit playerOutfit)
    {
        string pPartsInJSON = JsonUtility.ToJson(playerOutfit);

        File.WriteAllText(path, pPartsInJSON);

        Debug.Log("File Written");
    }
}

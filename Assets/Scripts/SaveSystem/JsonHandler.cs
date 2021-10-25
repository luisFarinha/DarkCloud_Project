using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class JsonHandler
{
    //Chosen file paths to enable saving on different operating systems (Mac, Windows, ...)
    public static string playerOutfitPath = Application.persistentDataPath + Constants.PLAYER_OUTFIT_FILE_PATH;
    public static string leaderboardPath = Application.persistentDataPath + Constants.LEADERBOARD_FILE_PATH;

    //PlayerOutfit--------------------------------------------------------------------------------
    //Reads PlayerOutfit's data
    public static PlayerOutfit ReadPlayerOutfitData()
    {
        if (File.Exists(playerOutfitPath))
        {
            string jsonString = File.ReadAllText(playerOutfitPath);

            PlayerOutfit newPlayerOutfit = JsonUtility.FromJson<PlayerOutfit>(jsonString);

            return newPlayerOutfit;
        }
        else
        {
            Debug.Log("Player File not found");
            return null;
        }
    }
    
    //Writes PlayerOutfit's data
    public static void WritePlayerOutfitData(PlayerOutfit playerOutfit)
    {
        string pPartsInJSON = JsonUtility.ToJson(playerOutfit);

        File.WriteAllText(playerOutfitPath, pPartsInJSON);

        Debug.Log("Player File Written");
    }
    
    //Checks if PlayerOutfit's data exists, if not creates a new blank PlayerOutfit file
    public static void CheckPlayerFileExistence(PlayerOutfit playerOutfit)
    {
        if (!File.Exists(playerOutfitPath))
        {
            WritePlayerOutfitData(playerOutfit);
            
            Debug.Log("No Previous Player File");
        }
    }

    //Leaderboard--------------------------------------------------------------------------------
    //Reads Leaderboard's data
    public static Leaderboard ReadLeaderboardData()
    {
        if (File.Exists(leaderboardPath))
        {
            string jsonString = File.ReadAllText(leaderboardPath);

            Leaderboard newLeaderboard = JsonUtility.FromJson<Leaderboard>(jsonString);

            return newLeaderboard;
        }
        else
        {
            Debug.Log("Leaderboard File not found");
            return null;
        }
    }

    //Writes Leaderboard's data
    public static void WriteLeaderboardData(Leaderboard leaderboard)
    {
        string lPartsInJSON = JsonUtility.ToJson(leaderboard);

        File.WriteAllText(leaderboardPath, lPartsInJSON);

        Debug.Log("Leaderboard File Written");
    }

    //Checks if Leaderboard's data exists, if not creates a new blank Leaderboard file
    public static void CheckLeaderboardFileExistence(Leaderboard leaderboard)
    {
        if (!File.Exists(leaderboardPath))
        {
            WriteLeaderboardData(leaderboard);

            Debug.Log("No Previous Leaderboard File");
        }
    }


}

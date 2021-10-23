using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataHandler : MonoBehaviour
{
    //Player Outfit Components
    private PlayerOutfit playerOutfit;
    private OutfitChanger[] outfitChangerScripts;
    private InputField nameInputField;

    //Leaderboard Components
    private Leaderboard leaderboard;
    private GameObject table;
    private GameObject[] rows;
    [Header("Leaderboard Row")]
    public GameObject row;

    void Awake()
    {
        JsonHandler.CheckPlayerFileExistence(new PlayerOutfit());
        JsonHandler.CheckLeaderboardFileExistence(new Leaderboard());

        outfitChangerScripts = GameObject.FindWithTag("PlayerOutfitsPanel").GetComponentsInChildren<OutfitChanger>();
        nameInputField = GameObject.FindWithTag("NameInputField").GetComponent<InputField>();
        table = GameObject.FindWithTag("LeaderboardTable");
        try { rows = GameObject.FindGameObjectsWithTag("Row"); } catch (Exception) { };
        
        LoadPlayerOutfitData();
        LoadLeaderboardData();
    }

    public void LoadPlayerOutfitData()
    {
        playerOutfit = JsonHandler.ReadPlayerOutfitData();

        if (playerOutfit != null)
        {
            foreach (OutfitChanger outfitChanger in outfitChangerScripts)
            {
                switch (outfitChanger.bodyPartString)
                {
                    case "head": outfitChanger.currentOption = playerOutfit.head; break;
                    case "shoulders": outfitChanger.currentOption = playerOutfit.shoulders; break;
                    case "torso": outfitChanger.currentOption = playerOutfit.torso; break;
                    case "arms": outfitChanger.currentOption = playerOutfit.arms; break;
                    case "legs": outfitChanger.currentOption = playerOutfit.legs; break;
                    case "cape": outfitChanger.currentOption = playerOutfit.cape; break;
                    case "sword": outfitChanger.currentOption = playerOutfit.sword; break;
                }
            }

            nameInputField.text = playerOutfit.name;
        }
        else
        {
            Debug.Log("On load, Player data is null");
        }

    }

    public void SavePlayerOutfitData()
    {
        if (playerOutfit != null)
        {
            foreach (OutfitChanger outfitChanger in outfitChangerScripts)
            {
                switch (outfitChanger.bodyPartString)
                {
                    case "head": playerOutfit.head = outfitChanger.currentOption; break;
                    case "shoulders": playerOutfit.shoulders = outfitChanger.currentOption; break;
                    case "torso": playerOutfit.torso = outfitChanger.currentOption; break;
                    case "arms": playerOutfit.arms = outfitChanger.currentOption; break;
                    case "legs": playerOutfit.legs = outfitChanger.currentOption; break;
                    case "cape": playerOutfit.cape = outfitChanger.currentOption; break;
                    case "sword": playerOutfit.sword = outfitChanger.currentOption; break;
                }
            }

            playerOutfit.name = nameInputField.text;
        }
        else
        {
            Debug.Log("On save, Player data is null");
        }

        JsonHandler.WritePlayerOutfitData(playerOutfit);
    }

    public void LoadLeaderboardData()
    {
        leaderboard = JsonHandler.ReadLeaderboardData();

        if (leaderboard != null)
        {
            foreach (Submission submission in leaderboard.submission)
            {
                GameObject newRow = Instantiate(row) as GameObject;
                newRow.transform.SetParent(table.transform);
                newRow.transform.localScale = new Vector2(1, 1);
                Row rowScript = newRow.GetComponent<Row>();

                rowScript.placeTxt.text = submission.place;
                rowScript.nameTxt.text = submission.name;
                rowScript.timeAliveTxt.text = submission.time;
                rowScript.scoreTxt.text = submission.score;
            }
        }
        else
        {
            Debug.Log("On load, Leaderboard data is null");
        }
    }

    public void SaveLeaderboardData()
    {
        leaderboard = new Leaderboard();

        rows = GameObject.FindGameObjectsWithTag("Row");

        Submission[] submissions = new Submission[rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            Row rowScript = rows[i].GetComponent<Row>();
            Debug.Log(rowScript.scoreTxt.text);

            Submission submiss = new Submission();

            submiss.place = rowScript.placeTxt.text;
            submiss.name = rowScript.nameTxt.text;
            submiss.time = rowScript.timeAliveTxt.text;
            submiss.score = rowScript.scoreTxt.text;

            submissions[i] = submiss;
        }

        leaderboard.submission = submissions;

        JsonHandler.WriteLeaderboardData(leaderboard);
    }
}

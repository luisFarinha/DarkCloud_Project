using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DataHandler : MonoBehaviour // Manages the reading and writing of data with the help of the JsonHandler class
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
        // checks if player outfit and leaderboard files exist and if they dont't creates new ones
        JsonHandler.CheckPlayerFileExistence(new PlayerOutfit());
        JsonHandler.CheckLeaderboardFileExistence(new Leaderboard());

        outfitChangerScripts = GameObject.FindWithTag(Constants.PLAYER_OUTFIT_PANEL).GetComponentsInChildren<OutfitChanger>();
        nameInputField = GameObject.FindWithTag(Constants.NAME_INPUT_FIELD).GetComponent<InputField>();
        table = GameObject.FindWithTag(Constants.LEADERBOARD_TABLE);
        try { rows = GameObject.FindGameObjectsWithTag(Constants.ROW); } catch (Exception) { };
        
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
                    case Constants.HEAD_STRING: outfitChanger.currentOption = playerOutfit.head; break;
                    case Constants.SHOULDERS_STRING: outfitChanger.currentOption = playerOutfit.shoulders; break;
                    case Constants.TORSO_STRING: outfitChanger.currentOption = playerOutfit.torso; break;
                    case Constants.ARMS_STRING: outfitChanger.currentOption = playerOutfit.arms; break;
                    case Constants.LEGS_STRING: outfitChanger.currentOption = playerOutfit.legs; break;
                    case Constants.CAPE_STRING: outfitChanger.currentOption = playerOutfit.cape; break;
                    case Constants.SWORD_STRING: outfitChanger.currentOption = playerOutfit.sword; break;
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
                    case Constants.HEAD_STRING: playerOutfit.head = outfitChanger.currentOption; break;
                    case Constants.SHOULDERS_STRING: playerOutfit.shoulders = outfitChanger.currentOption; break;
                    case Constants.TORSO_STRING: playerOutfit.torso = outfitChanger.currentOption; break;
                    case Constants.ARMS_STRING: playerOutfit.arms = outfitChanger.currentOption; break;
                    case Constants.LEGS_STRING: playerOutfit.legs = outfitChanger.currentOption; break;
                    case Constants.CAPE_STRING: playerOutfit.cape = outfitChanger.currentOption; break;
                    case Constants.SWORD_STRING: playerOutfit.sword = outfitChanger.currentOption; break;
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
                newRow.transform.position = new Vector3(table.transform.position.x, table.transform.position.y, table.transform.position.z - 1);
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

    //Saving Leaderboard Data
    public void SaveLeaderboardData()
    {
        leaderboard = new Leaderboard();

        rows = GameObject.FindGameObjectsWithTag(Constants.ROW);

        Submission[] submissions = new Submission[rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            Row rowScript = rows[i].GetComponent<Row>();
            Debug.Log(rowScript.scoreTxt.text);

            Submission submiss = new Submission
            {
                place = rowScript.placeTxt.text,
                name = rowScript.nameTxt.text,
                time = rowScript.timeAliveTxt.text,
                score = rowScript.scoreTxt.text
            };

            submissions[i] = submiss;
        }

        leaderboard.submission = submissions;

        JsonHandler.WriteLeaderboardData(leaderboard);
    }
}

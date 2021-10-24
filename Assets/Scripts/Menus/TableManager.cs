using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TableManager : MonoBehaviour
{
    private GameObject[] rows;
    private DataHandler dataHandler;

    private InputField nameInputField;
    private Text timeTxt;
    private Text scoreTxt;

    private Text resultTxt;

    [Header("table row")]
    public GameObject row;

    // Start is called before the first frame update
    void Start()
    {
        dataHandler = GameObject.FindWithTag("DataHandler").GetComponent<DataHandler>();
        SortByScore();

        try { rows = GameObject.FindGameObjectsWithTag("Rows"); } catch (Exception) { };
        try { nameInputField = GameObject.FindWithTag("NameInputField").GetComponent<InputField>(); ; } catch (Exception) { };
        try { timeTxt = GameObject.FindWithTag("TimeText").GetComponent<Text>(); } catch (Exception) { };
        try { scoreTxt = GameObject.FindWithTag("ScoreText").GetComponent<Text>(); } catch (Exception) { };
        try { resultTxt = GameObject.FindWithTag("ResultText").GetComponent<Text>(); } catch (Exception) { }; 
    }

    public void CreateRow()
    {
        GameObject newRow = Instantiate(row) as GameObject;
        newRow.transform.SetParent(transform);
        newRow.transform.localScale = new Vector2(1, 1);
        Row rowScript = newRow.GetComponent<Row>();

        rowScript.placeTxt.text = "-1";
        rowScript.nameTxt.text = nameInputField.text;
        rowScript.timeAliveTxt.text = timeTxt.text;
        rowScript.scoreTxt.text = scoreTxt.text;

        SortByScore();

        try
        {
            resultTxt.text = nameInputField.text + " dodged " + scoreTxt.text + " ball(s) in " + timeTxt.text + " minutes!";
        }
        catch (Exception) { }

        dataHandler.SaveLeaderboardData();
    }

    public void SortByScore() 
    {
        rows = GameObject.FindGameObjectsWithTag("Row");

        int[] scoresOrdered = new int[rows.Length];

        for (int i = 0; i < rows.Length; i++)
        {
            Row rowScript = rows[i].GetComponent<Row>();
            
            scoresOrdered[i] = int.Parse(rowScript.scoreTxt.text);
        }

        Array.Sort(scoresOrdered); //sort scores ascending
        Array.Reverse(scoresOrdered); //reverse the order of the array
        scoresOrdered = scoresOrdered.Distinct().ToArray(); // remove duplicated values
        int count = 0; //Used to place submissions
        for (int i = 0; i < scoresOrdered.Length; i++)
        {
            int alignCount = 0; //Used to place same score submissions in different places
            for (int j = 0; j < rows.Length; j++)
            {
                int rowScore = int.Parse(rows[j].GetComponent<Row>().scoreTxt.text);

                if (scoresOrdered[i] == rowScore)
                {
                    rows[j].transform.SetSiblingIndex(i + alignCount);
                    rows[j].GetComponent<Row>().placeTxt.text = (i + alignCount + 1).ToString();
                    count++;
                    alignCount++;
                }
            }
        }
    }
}

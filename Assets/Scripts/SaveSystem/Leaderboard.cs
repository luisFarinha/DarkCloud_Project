using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leaderboard
{
    public Submission[] submission;
}

[System.Serializable]
public class Submission
{
    private int place;
    private string name;
    private string time;
    private int score;
}

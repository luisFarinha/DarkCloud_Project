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
    public string place;
    public string name;
    public string time;
    public string score;
}

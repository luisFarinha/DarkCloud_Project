using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Leaderboard // leaderboard with an array of submissions serializable to json
{
    public Submission[] submission;
}

[System.Serializable]
public class Submission // submisson with the necessary atributes serializables to json
{
    public string place;
    public string name;
    public string time;
    public string score;
}

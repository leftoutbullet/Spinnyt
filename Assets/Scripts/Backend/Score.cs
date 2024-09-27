using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Score
{
    public string _id;
    public float timer;
    public string level;
    public string device;


    public string Stringify()
    {
        return JsonUtility.ToJson(this);
    }

    public static Score Parse(string json)
    {
        return JsonUtility.FromJson<Score>(json);
    }
}
[System.Serializable]
public class ScoreDataList
{
    public Score[] scores;
}
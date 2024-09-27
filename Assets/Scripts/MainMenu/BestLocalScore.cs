using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestLocalScore : MonoBehaviour
{
    public TextMeshProUGUI localBestText;

    void Start()
    {
        ShowLocalBestScore();
    }

    public void ShowLocalBestScore()
    {
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        if (highScore != float.MaxValue)
        {
            localBestText.text = FormatTime(highScore); // Format the time before displaying
        }
        else
        {
            localBestText.text = "No local best score yet!";
        }
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60F);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60F);
        int milliseconds = Mathf.FloorToInt((timeInSeconds * 1000F) % 1000F);
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

}

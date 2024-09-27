using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;  // Reference to the TextMeshPro component
    public float timeElapsed = 0f;
    //public  float time
    private float timeForNextEvent = 20f;
    private bool gameStarted = false;
    public AudioSource audio;

    public void setGameStartedtoTrue()
    {
        audio.Play();
        gameStarted = true;
    }

    void Update()
    {
        if (gameStarted)
        {
            StartGame();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed % 60F);
        int milliseconds = Mathf.FloorToInt((timeElapsed * 100F) % 100F);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void StartGame()
    {
        timeElapsed += Time.deltaTime;  // Increment the timer
        StaticData.timerScore = timeElapsed;
        UpdateTimerDisplay();

        // Check if 20 seconds have passed
        if (timeElapsed >= timeForNextEvent)
        {
            EventManager.Every20Seconds();
            timeForNextEvent += 20f; // Set the next 20-second mark
        }
    }

    public void StopTimer()
    {
        gameStarted = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyUpdate : MonoBehaviour
{
    public GameObject enemySpawner;
    private Timer timer;
    private SpawnEnemies difficulty;
    public PianoFlicker pianoFlicker; // Reference to the PianoFlicker
    float nextFlickerTime = 40;

    void Start()
    {
        timer = GetComponent<Timer>();
        difficulty = enemySpawner.GetComponent<SpawnEnemies>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTimer();
    }

    void CheckForTimer()
    {
        if (timer.timeElapsed > 15)
        {
            difficulty.difficulty = Difficulty.Easy;
        }
        if (timer.timeElapsed > 25)
        {
            difficulty.difficulty = Difficulty.Medium;
        }

        // Start flickering at 40 seconds and every 15 seconds afterward
        if (timer.timeElapsed >= nextFlickerTime)
        {
            pianoFlicker.StartFlickering();
            nextFlickerTime += 15; // Schedule the next flicker
        }
    }
}

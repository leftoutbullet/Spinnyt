using CarterGames.Assets.AudioManager;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; // If you plan to reload the scene or load another

public class PlayerDeathHandler : MonoBehaviour
{
    

    void OnEnable()
    {
        EventManager.OnPlayerDeath += HandlePlayerDeath;
    }

    void OnDisable()
    {
        EventManager.OnPlayerDeath -= HandlePlayerDeath;
    }

    void HandlePlayerDeath()
    {
        // Implement your game over logic here
        AudioManager.instance.Play("HeartHit", volume:0.5f);

        // Stop enemy spawning
        SpawnEnemies spawnEnemies = FindObjectOfType<SpawnEnemies>();
        if (spawnEnemies != null)
        {
            spawnEnemies.StopSpawning();
        }

        // Destroy all remaining enemies
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemy);
        }

        // Destroy all remaining projectiles
        foreach (Projectile projectile in FindObjectsOfType<Projectile>())
        {
            Destroy(projectile.gameObject);
        }

        // Show Game Over UI
        GameObject gameOverUI = GameObject.Find("GameOverUI");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
        }

        ScoreSavingEndpoint scoreSavingEndpoint = FindObjectOfType<ScoreSavingEndpoint>();


        // Stop the timer
        Timer timer = FindObjectOfType<Timer>();
        if (timer != null)
        {
            scoreSavingEndpoint.setTimerVariable(timer.timeElapsed);
            timer.StopTimer();
        }

        // Slow down time
        //Time.timeScale = 0.5f;

        // Save Score to the backend
        scoreSavingEndpoint.SaveScore();

        // Save Score locally if it's the best
        CheckAndSaveHighScore(timer.timeElapsed);

        // Small pause
        StartCoroutine("smallPause");

        // Disable player controls if necessary
        // For example, disable the player's movement script
        /*
        PlayerMovement playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        */

        // Optionally, transition to a Game Over scene
        // SceneManager.LoadScene("GameOverScene");
    }

    IEnumerator smallPause()
    {
        yield return new WaitForSeconds(1);
        ToScore();
    }

    public void ToScore()
    {
        StaticData.challengeName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Score");

    }

    public void CheckAndSaveHighScore(float newScore)
    {
        // Get the current high score from PlayerPrefs (default to 0 if no high score is saved)
        float highScore = PlayerPrefs.GetFloat("HighScore", 0);
        
        // Check if the new score is higher than the current high score
        if (newScore > highScore)
        {
            // Save the new high score to PlayerPrefs
            PlayerPrefs.SetFloat("HighScore", newScore);
            PlayerPrefs.Save(); // Ensure the data is saved

            
        }
        else
        {
            
        }
    }
}

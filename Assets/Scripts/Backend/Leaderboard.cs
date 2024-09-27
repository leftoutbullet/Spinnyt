using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "https://spinnytbackend-leftoutbullet.onrender.com/score";

    [SerializeField] private TextMeshProUGUI timerText1;
    [SerializeField] private TextMeshProUGUI timerText2;
    [SerializeField] private TextMeshProUGUI timerText3;

    private void Awake()
    {
        ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

    }
    public void ActivateLeaderboard()
    {
        StartCoroutine(ShowLeaderboard());
    }


    private IEnumerator ShowLeaderboard()
    {
        UnityWebRequest request = UnityWebRequest.Get($"{authenticationEndpoint}/top");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Received highest timers:");
            string json = request.downloadHandler.text;

            // Parse JSON array manually and remove any unwanted characters like quotes or spaces
            ScoreDataList scoreDataList = JsonUtility.FromJson<ScoreDataList>("{\"scores\":" + json + "}");


            if (scoreDataList.scores.Length >= 3)
            {
                // Show top 3 times formatted as "MM:SS:MS"
                timerText1.text = ConvertToTimeFormat(scoreDataList.scores[0].timer.ToString()) + " minutes";
                timerText2.text = ConvertToTimeFormat(scoreDataList.scores[1].timer.ToString()) + " minutes";
                timerText3.text = ConvertToTimeFormat(scoreDataList.scores[2].timer.ToString()) + " minutes";
            }
            else
            {
                Debug.LogWarning("Received less than 3 timer values.");
            }
        }
        else
        {
            Debug.Log("Unable to connect to the server");
        }
    }

    // Helper function to convert seconds to "MM:SS:MS" format
    private string ConvertToTimeFormat(string secondsStr)
    {
        if (float.TryParse(secondsStr, out float totalSeconds))
        {
            int minutes = Mathf.FloorToInt(totalSeconds / 60); // Extract minutes
            int seconds = Mathf.FloorToInt(totalSeconds % 60); // Extract seconds
            int milliseconds = Mathf.FloorToInt((totalSeconds * 1000) % 1000); // Extract milliseconds

            // Format as "MM:SS:MS"
            return $"{minutes:00}:{seconds:00}:{milliseconds:000}";
        }
        else
        {
            Debug.LogError($"Failed to parse timer value: {secondsStr}");
            return "00:00:000"; // Fallback format
        }
    }


}

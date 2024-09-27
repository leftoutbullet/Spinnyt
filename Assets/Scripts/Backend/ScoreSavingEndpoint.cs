using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreSavingEndpoint : MonoBehaviour
{
    [SerializeField] private string authenticationEndpoint = "https://spinnytbackend-leftoutbullet.onrender.com/score";

    //[SerializeField] private TextMeshProUGUI placement;
    [SerializeField] private float timer;
    [SerializeField] private string level;
    [SerializeField] private string device = "khalil";

    private void Awake()
    {
        level = SceneManager.GetActiveScene().name;
        ServicePointManager.ServerCertificateValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

    }

    public void setTimerVariable(float newtimer)
    {
        timer = newtimer;
    }


    public void SaveScore()
    {
        StartCoroutine(saveScoreBackend());
    }


    public IEnumerator saveScoreBackend()
    {
        //following text adds new entries to the table

        UnityWebRequest request = UnityWebRequest.Get($"{authenticationEndpoint}?rTimer={timer}&rLevel={level}&rDevice={device}");
        var handler = request.SendWebRequest();

        Debug.Log($"Sending request to: {authenticationEndpoint}?rTimer={timer}&rLevel={level}&rDevice={device}");

        float startTime = 0.0f;
        while (!handler.isDone)
        {
            startTime += Time.deltaTime;
            if (startTime > 10)
            {
                break;
            }
            yield return null;
        }

        


        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(request.downloadHandler.text);
        }
        else
        {
            Debug.Log("Unable to connect to the server");
        }

    }

}



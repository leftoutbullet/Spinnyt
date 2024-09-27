using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TMP_Text countdownDisplay;
    public GameObject timer;
    private void Start()
    {
        StartCoroutine("CountdownToStart");
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime>0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);

            countdownTime--;
            //SoundManager.PlaySound(SoundType.COUNTDOWN);
        }
        countdownDisplay.GetComponent<AudioSource>().Stop();
        countdownDisplay.text = "BEGIN!";
        AudioManager.instance.Play("Begin");
        

        timer.GetComponent<Timer>().setGameStartedtoTrue();

        yield return new WaitForSeconds(1f);

        countdownDisplay.gameObject.SetActive(false);
    }
}

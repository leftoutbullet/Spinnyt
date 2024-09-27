using CarterGames.Assets.AudioManager;
using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class Count2Target : MonoBehaviour
{
    public float countDuration = 1;  // Duration to count to the target value
    TMP_Text numberText;
    float currentValue = 0, targetValue = 0;
    Coroutine _C2T;
    [SerializeField] private GameObject backtomenu;

    void Awake()
    {
        numberText = GetComponent<TMP_Text>();
    }

    void Start()
    {
        targetValue = float.Parse(numberText.text);  // Get initial target value from the text
        SetTarget(targetValue);
    }

    IEnumerator CountTo(float targetValue)
    {
        var rate = Mathf.Abs(targetValue - currentValue) / countDuration;
        while (currentValue != targetValue)
        {
            currentValue = Mathf.MoveTowards(currentValue, targetValue, rate * Time.deltaTime);

            // Convert the currentValue into minutes, seconds, and milliseconds
            string timeFormatted = FormatTime(currentValue);
            numberText.text = timeFormatted;

            yield return null;
            
        }
        backtomenu.SetActive(true);
    }

    // Method to format time as MM:SS:MS
    string FormatTime(float value)
    {
        int minutes = Mathf.FloorToInt(value / 60f);        // Get the number of minutes
        int seconds = Mathf.FloorToInt(value % 60f);        // Get the number of seconds
        int milliseconds = Mathf.FloorToInt((value * 1000) % 1000);  // Get the milliseconds

        // Format the time as MM:SS:MS (e.g. 01:45:123)
        return string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    public void SetTarget(float target)
    {
        targetValue = target;
        if (_C2T != null)
        {
            StopCoroutine(_C2T);
            
        }
        _C2T = StartCoroutine(CountTo(targetValue));
    }
}

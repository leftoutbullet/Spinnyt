using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private TMP_Text title;
    void Start()
    {
        timer.text = StaticData.timerScore.ToString();
        title.text = StaticData.challengeName.ToString();
    }

    
}

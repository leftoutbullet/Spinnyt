using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToScore : MonoBehaviour
{
    
    public void ButtonToScore()
    {
        StaticData.challengeName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Score");
        
    }
}

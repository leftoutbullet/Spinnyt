using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnlocking : MonoBehaviour
{
    [SerializeField] private GameObject starLocked;
    [SerializeField] private GameObject starUnlocked;

    void Start()
    {
        
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 1)
        {
            
            UnlockStar();
        }
    }

    void UnlockStar()
    {
         starLocked.SetActive(false);
         starUnlocked.SetActive(true);
        
    }
}

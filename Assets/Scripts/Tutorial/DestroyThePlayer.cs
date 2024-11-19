using CarterGames.Assets.AudioManager;
using MaskTransitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyThePlayer : MonoBehaviour
{
    [SerializeField]private GameObject bombParticleEffect;
    bool bomb = false;

    //kill player
    [SerializeField] private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= 0 && bomb == false)
        {
            
            DoTheBomb();
        }    
    }

    private void DoTheBomb()
    {
        bombParticleEffect.SetActive(true); 
        AudioManager.instance.Play("Bomb", 0.5f);
        bomb = true;
        Destroy(player);
        EventManager.PlayerDied();
        Destroy(gameObject);
        if (PlayerPrefs.GetInt("TutorialCompleted", 0) == 0)
        {
            
            PassTutorialCompletionData.TutorialJustCompleted = true;
            CompleteTutorial();
        }

        //CompleteTutorial();
        StartCoroutine(endTutorialWait());
        
        TransitionManager.Instance.LoadLevel("MainMenu");
        
    }

    private IEnumerator endTutorialWait()
    {
        yield return new WaitForSeconds(1f);
        
    }

    void CompleteTutorial()
    {
        
        PlayerPrefs.SetInt("TutorialCompleted", 1);
        PlayerPrefs.Save(); 

        
    }
}

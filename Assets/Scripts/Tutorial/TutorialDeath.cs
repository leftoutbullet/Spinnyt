using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialDeath : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject _player;
    FloatingText floatingText;

    void OnEnable()
    {
        EventManager.OnPlayerDeath += HandleTutorialDeath;
    }

    void OnDisable()
    {
        EventManager.OnPlayerDeath -= HandleTutorialDeath;
    }
    private void Awake()
    {
        floatingText = gameObject.GetComponent<FloatingText>();
    }


    void HandleTutorialDeath()
    {

        // change text
        gameObject.GetComponent<FloatingText>().StopAllCoroutines();
        textComponent.text = "Oh man, come on, it's not that hard";

        StartCoroutine(WaitABit(2.5f));

        // respawn Player
        //_player.GetComponent<CharacterInstancing>().InstantiateCharacter();

        // change text back to the previous index
        

    }

    private IEnumerator WaitABit(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _player.GetComponent<CharacterInstancing>().InstantiateCharacter();
        textComponent.text = "";
        floatingText.StartCoroutine(floatingText.TypeLine());
    }

}

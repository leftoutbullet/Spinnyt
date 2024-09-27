using Coffee.UIEffects;
using System.Collections;
using System.Collections.Generic;
using MaskTransitions;
using UnityEngine;
using CarterGames.Assets.AudioManager;

public class ConfirmSelection : MonoBehaviour
{
    private SphereSelection sphereSelection;
    private CharacterSelect characterSelect;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject sphere;
    [SerializeField] private GameObject backgroundPanel;

    private void Start()
    {
        sphereSelection = sphere.GetComponent<SphereSelection>();
        characterSelect = character.GetComponent<CharacterSelect>();
    }
    

    public void ConfirmWardrobe()
    {
        PlayerPrefs.SetInt("selectedSphere", sphereSelection.selectedSphere);
        PlayerPrefs.SetInt("selectedCharacter", characterSelect.selectedCharacter);
        Debug.Log("selectedCharacter : " + PlayerPrefs.GetInt("selectedCharacter"));
        AudioManager.instance.Play("Success"); 
        TransitionManager.Instance.LoadLevel("MainMenu");
    }

    /*public void GetWardrobe()
    {
        Debug.Log("selectedSphere : " + PlayerPrefs.GetInt("selectedSphere"));
        Debug.Log("selectedCharacter : " + PlayerPrefs.GetInt("selectedCharacter"));
    }*/
}

using CarterGames.Assets.AudioManager;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    private List<GameObject> models;
    public int selectedCharacter = 0;
    [SerializeField] private float rotateSpeed;

    [SerializeField] private GameObject[] ticks;
    public int selectedTick = 0;

    private void Start()
    {
        models = new List<GameObject>();
        foreach (Transform t in transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }
        selectedTick = PlayerPrefs.GetInt("selectedCharacter");
        selectedCharacter = selectedTick;
        ticks[selectedTick].SetActive(true);
        models[selectedCharacter].SetActive(true);
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            Select(1);
        }   */
        gameObject.transform.Rotate(0f, rotateSpeed * Time.timeScale, 0f);
    }


    public void Select(int index)
    {
        AudioManager.instance.Play("PickCharacter");
        if (index == selectedCharacter)
        {
            return;
        }
        if (index < 0 || index >= models.Count)
        {
            return;
        }
        models[selectedCharacter].SetActive(false);
        ticks[selectedTick].SetActive(false);
        selectedCharacter = index;
        selectedTick = index;
        models[selectedCharacter].SetActive(true);
        ticks[selectedTick].SetActive(true);

        Debug.Log(selectedCharacter);



    }

}



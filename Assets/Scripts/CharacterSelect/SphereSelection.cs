using CarterGames.Assets.AudioManager;
using System.Collections.Generic;
using UnityEngine;

public class SphereSelection : MonoBehaviour
{
    private List<GameObject> models;
    public int selectedSphere = 0;
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
        selectedTick = PlayerPrefs.GetInt("selectedSphere");
        selectedSphere = selectedTick;
        ticks[selectedTick].SetActive(true);
        models[selectedSphere].SetActive(true);
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
        if (index == selectedSphere)
        {
            return;
        }
        if (index < 0 || index >= models.Count)
        {
            return;
        }
        models[selectedSphere].SetActive(false);
        ticks[selectedTick].SetActive(false);
        selectedSphere = index;
        selectedTick = index;
        models[selectedSphere].SetActive(true);
        ticks[selectedTick].SetActive(true);

    }

}



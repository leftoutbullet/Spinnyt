using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoFlicker : MonoBehaviour
{
    public GameObject leftPiano;
    public GameObject leftPianoActive;
    public GameObject rightPiano;
    public GameObject rightPianoActive;
    public GameObject frontPiano;
    public GameObject frontPianoActive;
    public GameObject circleRightSpawnPoint;
    public GameObject circleLeftSpawnPoint;
    public GameObject circleFrontSpawnPoint;

    public GameObject circlePrefab; // Assign the circle prefab here

    public float flickerDuration = 2f;
    public float flickerInterval = 0.2f;

    private GameObject[] pianos;
    private GameObject[] pianosActive;
    private GameObject[] circleSpawnPoints;
    private bool isFlickering = false;
    private bool hasFlickered = false;

    void Start()
    {
        pianos = new GameObject[] { leftPiano, rightPiano, frontPiano };
        pianosActive = new GameObject[] { leftPianoActive, rightPianoActive, frontPianoActive };
        circleSpawnPoints = new GameObject[] { circleLeftSpawnPoint, circleRightSpawnPoint, circleFrontSpawnPoint };

        // Ensure all piano sprites are inactive at the start
        DeactivateAllPianos();
    }

    public void StartFlickering()
    {
        // Only start flickering if it hasn't already started and hasn't flickered before
        if (!isFlickering && !hasFlickered)
        {
            StartCoroutine(FlickerPianos());
        }
    }

    private IEnumerator FlickerPianos()
    {
        isFlickering = true;
        float elapsedTime = 0f;

        while (elapsedTime < flickerDuration)
        {
            // Randomly activate one of the pianos
            int randomIndex = Random.Range(0, pianos.Length);
            pianos[randomIndex].SetActive(true);

            yield return new WaitForSeconds(flickerInterval);

            // Deactivate all pianos
            DeactivateAllPianos();

            elapsedTime += flickerInterval;
        }

        // After flickering, activate one random piano and its corresponding active state
        int selectedIndex = Random.Range(0, pianosActive.Length);
        pianosActive[selectedIndex].SetActive(true);

        // Mark the flickering as completed
        isFlickering = false;
        hasFlickered = true;

        StartCoroutine(lastTileBeforeReset(pianosActive[selectedIndex]));   

        // Here you can add the logic to spawn the object from the selected side
        SpawnCircleAttack(circleSpawnPoints[selectedIndex].transform.position);
    }

    private IEnumerator lastTileBeforeReset(GameObject activeTile) 
    {
        yield return new WaitForSeconds(2f);
        activeTile.SetActive(false);
        hasFlickered = false;
    }

    private void DeactivateAllPianos()
    {
        foreach (var piano in pianos)
        {
            piano.SetActive(false);
        }

        foreach (var pianoActive in pianosActive)
        {
            pianoActive.SetActive(false);
        }
    }

    private void SpawnCircleAttack(Vector3 pianoPosition)
    {
        // Instantiate the circle prefab at the center
        GameObject circle = Instantiate(circlePrefab, new Vector3(0, 1.23f, 0), Quaternion.identity);

        // Adjust the position to ensure the circle is looking directly at the active piano
        circle.GetComponent<CircleAttack>().SetLookAt(pianoPosition);

        // Optionally rotate the circle 180 degrees on Y-axis if it faces the wrong direction
        //circle.transform.Rotate(0, 180, 0);
    }

}

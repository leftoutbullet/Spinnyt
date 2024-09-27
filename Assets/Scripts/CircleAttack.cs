using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAttack : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 1.24f, 0); // The center point
    public float shrinkSpeed = 1f; // Speed at which the circle shrinks

    private Vector3 initialScale;

    void Start()
    {
        // Store the initial scale of the circle
        //initialScale = transform.localScale;
    }

    void Update()
    {
        // Shrink the circle over time
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSpeed * Time.deltaTime);

        // Destroy the circle when it is fully shrunk
        if (transform.localScale.magnitude <= 0.01f)
        {
            Destroy(gameObject);
        }
    }

    // Method to set the circle's rotation to look at the active piano
    public void SetLookAt(Vector3 pianoPosition)
    {
        transform.LookAt(pianoPosition);

        // If needed, adjust orientation based on the setup of your prefab
        transform.Rotate(0, 90f, 0); // Adjust this value based on your needs
    }


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Detected with: " + other.gameObject.name);

        if (other.CompareTag("Sphere"))
        {
            Debug.Log("Sphere Trigger Detected");
            other.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (other.CompareTag("Heart"))
        {
            Debug.Log("Heart Trigger Detected");
            EventManager.PlayerDied();
            GameObject player = other.transform.root.gameObject;
            Destroy(player);
            Destroy(gameObject);
        }
    }
}

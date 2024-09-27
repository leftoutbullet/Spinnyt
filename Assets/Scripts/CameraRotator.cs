using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationSpeed = 720f;  // Speed of the camera rotation

    void OnEnable()
    {
        EventManager.OnEvery20Seconds += RotateCamera;
    }

    void OnDisable()
    {
        EventManager.OnEvery20Seconds -= RotateCamera;
    }

    void RotateCamera()
    {
        StartCoroutine(RotateOverTime());
    }

    IEnumerator RotateOverTime()
    {
        float rotationAmount = 0f;
        while (rotationAmount < 360f)
        {
            float rotationStep = rotationSpeed * Time.deltaTime;
            transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
            rotationAmount += rotationStep;
            yield return null;
        }
    }
}

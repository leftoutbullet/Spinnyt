using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 20, 0);
    public Vector3 lookAtTarget = Vector3.zero;

    void OnEnable()
    {
        EventManager.OnEvery20Seconds += MoveCamera;
    }

    void OnDisable()
    {
        EventManager.OnEvery20Seconds -= MoveCamera;
    }

    void MoveCamera()
    {
        StartCoroutine(MoveAndLookAtTarget());
    }

    IEnumerator MoveAndLookAtTarget()
    {
        // Optional: Smooth transition
        float transitionDuration = 1f;  // Duration of the transition
        float elapsedTime = 0f;

        Vector3 startingPosition = transform.position;

        while (elapsedTime < transitionDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / transitionDuration);
            transform.LookAt(lookAtTarget);  // Keep the camera focused on (0, 0, 0)
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the camera ends up exactly at the target position and looks at the target
        transform.position = targetPosition;
        transform.LookAt(lookAtTarget);
    }
}

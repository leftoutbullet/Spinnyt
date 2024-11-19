using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AdjustSpawnPoints : MonoBehaviour
{
    public Transform[] LeftSideSpawnPoints;
    public Transform[] RightSideSpawnPoints;
    public Transform[] FrontSideSpawnPoints;

    public float moveInterval = 30f;
    public float stepSize = 4f;

    private float leftMaxX = -5f;
    private float rightMaxX = 5f;
    private float frontMaxZ = -5f;

    private void Start()
    {
        InvokeRepeating(nameof(MoveSpawnPoints), moveInterval, moveInterval);
    }

    private void MoveSpawnPoints()
    {
        // Move Left Side Spawn Points
        foreach (var point in LeftSideSpawnPoints)
        {
            if (point.position.x + stepSize < leftMaxX)
            {
                point.position += new Vector3(stepSize, 0, 0);
            }
            else
            {
                point.position = new Vector3(leftMaxX, point.position.y, point.position.z);
            }
        }

        // Move Right Side Spawn Points
        foreach (var point in RightSideSpawnPoints)
        {
            if (point.position.x - stepSize > rightMaxX)
            {
                point.position -= new Vector3(stepSize, 0, 0);
            }
            else
            {
                point.position = new Vector3(rightMaxX, point.position.y, point.position.z);
            }
        }

        // Move Front Side Spawn Points
        foreach (var point in FrontSideSpawnPoints)
        {
            if (point.position.z + stepSize < frontMaxZ)
            {
                point.position += new Vector3(0, 0, stepSize);
            }
            else
            {
                point.position = new Vector3(point.position.x, point.position.y, frontMaxZ);
            }
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Set the initial position
        transform.position = new Vector3(1.1174197123153818e-9f, 0.10999999940395355f, 0.0f);

        // Set the initial rotation using the provided quaternion values
        transform.rotation = new Quaternion(-0.5593928694725037f, -0.0791153535246849f, -0.11554721742868424f, 0.816987931728363f);

        // Set the initial scale
        transform.localScale = new Vector3(2.493799924850464f, 2.493799924850464f, 2.493799924850464f);
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate around the Y-axis
        transform.Rotate(Vector3.up, Time.deltaTime * 30f, Space.World);
    }
}

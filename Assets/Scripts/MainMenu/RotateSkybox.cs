using UnityEngine;

public class RotateSkybox : MonoBehaviour
{
    public float speed;
    

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", speed * Time.time);
    }
}

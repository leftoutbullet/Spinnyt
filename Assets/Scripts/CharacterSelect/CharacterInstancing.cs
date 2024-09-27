using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInstancing : MonoBehaviour
{
    
    [SerializeField] private GameObject[] hearts;
    [SerializeField] private GameObject[] spheres;

    private GameObject instantiatedHeart;
    private GameObject instantiatedSphere;
    
    void Start()
    {

        InstantiateCharacter();
    }

    public void InstantiateCharacter()
    {
        int selectedHeartIndex = PlayerPrefs.GetInt("selectedCharacter");
        int selectedSphereIndex = PlayerPrefs.GetInt("selectedSphere");

        if (selectedHeartIndex == 0)
        {
            instantiatedHeart = Instantiate(hearts[0], transform.position, Quaternion.identity);
            instantiatedHeart.transform.parent = gameObject.transform;
            instantiatedHeart.transform.localScale = new Vector3(10f, 10f, 10f);
            instantiatedHeart.transform.localPosition = new Vector3(0f,-1.04f,0f);
        }

        else if (selectedHeartIndex == 1 || selectedHeartIndex ==2)
        {
            instantiatedHeart = Instantiate(hearts[selectedHeartIndex], transform.position, Quaternion.Euler(-90, 0, 0));
            instantiatedHeart.transform.parent = gameObject.transform;
            instantiatedHeart.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        }
        else
        {
            instantiatedHeart = Instantiate(hearts[selectedHeartIndex], transform.position, Quaternion.identity);
            instantiatedHeart.transform.parent = gameObject.transform;
        }

        instantiatedSphere = Instantiate(spheres[selectedSphereIndex], transform.position, Quaternion.identity);
        instantiatedSphere.transform.parent = gameObject.transform;


        
        
    }
    
}

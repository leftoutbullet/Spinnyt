using MaskTransitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    public GameObject levels;
    public GameObject wardrobe;
    public GameObject tutorialButton;
    public Animator myAnimator;
    private Animator levelsAnim;
    public GameObject logo;
    private void Start()
    {
        levelsAnim = levels.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
                logo.GetComponent<RectTransform>().Rotate(0, 0, 0.3f);

        if (Input.anyKeyDown)
        {
            myAnimator.SetTrigger("GameStart");
            gameObject.GetComponent<AudioSource>().Play();
            StartCoroutine(WaitForSlide()); 
            //Destroy(gameObject);
            levels.SetActive(true);
            wardrobe.SetActive(true);
            tutorialButton.SetActive(true);
        }
    }

    private IEnumerator WaitForSlide()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        levelsAnim.enabled=false;
    }

    

}

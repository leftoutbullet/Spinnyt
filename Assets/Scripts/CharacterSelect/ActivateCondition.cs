using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCondition : MonoBehaviour
{
    // Start is called before the first frame update
    public void PopUpCondition()
    {
        foreach (Transform t in transform)
        {
            if (t.gameObject.name == "AnimatedPopUp")
            {
                t.gameObject.SetActive(true);
                AudioManager.instance.Play("ErrorPick", volume: 0.6f);
                StartCoroutine(WaitForCondition(t.gameObject));
            }
        }
    }

    private IEnumerator WaitForCondition(GameObject t)
    {
        yield return new WaitForSeconds(1.5f);


        Animator anim = t.GetComponent<Animator>();

            
            anim.SetBool("Dead", true);


        yield return new WaitForSeconds(1f);
        
         t.SetActive(false);
    }

}

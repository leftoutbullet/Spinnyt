using MaskTransitions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayLevel1()
    {
        TransitionManager.Instance.LoadLevel("Vinyl");
    }

    public void GoToWardrobe()
    {
        TransitionManager.Instance.LoadLevel("CharacterSelect");
    }

    public void GoToTutorial()
    {
        TransitionManager.Instance.LoadLevel("Tutorial");
    }
}

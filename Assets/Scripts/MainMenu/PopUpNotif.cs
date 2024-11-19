using UnityEngine;

public class PopUpNotif : MonoBehaviour
{
    public GameObject notification;
    void Start()
    {
        if (PassTutorialCompletionData.TutorialJustCompleted)
        {
            PassTutorialCompletionData.TutorialJustCompleted = false; // Reset the flag
            
            UnlockNewCosmetic();
        }
    }

    private void UnlockNewCosmetic()
    {
        
        notification.SetActive(true);
    }


}

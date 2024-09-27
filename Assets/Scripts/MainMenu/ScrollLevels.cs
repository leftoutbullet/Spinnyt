using System.Collections;
using UnityEngine;

public class ScrollLevels : MonoBehaviour
{
    private RectTransform levelsPanel;  // Reference to the RectTransform of the Levels parent panel
    public float scrollDuration = 0.5f;  // Duration of the scroll animation

    private Vector2 level1Position;
    private Vector2 level2Position;
    private Vector2 leaderboard1Position;

    public GameObject leaderboard1;

    void Start()
    {
        levelsPanel = GetComponent<RectTransform>();
        // Store the initial positions of Level1 and Level2
        level1Position = levelsPanel.anchoredPosition;
        level2Position = new Vector2(-1600, 0); // Assuming Level2 is to the right of Level1
        leaderboard1Position = new Vector2(0, 720); 
    }

    public void ScrollToLevel2()
    {
        StartCoroutine(ScrollToPosition(level2Position));
        level1Position = levelsPanel.anchoredPosition;
    }

    public void ScrollToLevel1()
    {
        StartCoroutine(ScrollToPosition(level1Position));
    }

    public void ScrollToLeaderboard1()
    {
        StartCoroutine(ScrollToPosition(leaderboard1Position));
        leaderboard1.GetComponent<Leaderboard>().ActivateLeaderboard();
    }

    public void ScrollToLevel1fromLeaderboard()
    {
        StartCoroutine(ScrollToPosition(new Vector2(0, 0)));

    }

    private IEnumerator ScrollToPosition(Vector2 targetPosition)
    {
        Vector2 startPosition = levelsPanel.anchoredPosition;
        
        float elapsedTime = 0f;

        


        while (elapsedTime < scrollDuration)
        {
            levelsPanel.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsedTime / scrollDuration);
            
            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        levelsPanel.anchoredPosition = targetPosition;
        

    }
}

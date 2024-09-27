using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnPlayerHit;
    public static event Action OnEvery20Seconds;
    public static event Action OnPlayerDeath;

    public static void PlayerHit()
    {
        OnPlayerHit?.Invoke();
    }

    public static void Every20Seconds()
    {
        OnEvery20Seconds?.Invoke();
    }

    public static void PlayerDied()
    {
        OnPlayerDeath?.Invoke();
    }
}

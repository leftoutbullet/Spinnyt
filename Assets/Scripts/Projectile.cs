using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnEnable()
    {
        EventManager.OnPlayerHit += DestroyProjectile;
    }

    void OnDisable()
    {
        EventManager.OnPlayerHit -= DestroyProjectile;
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            BreakableWindow breakableWindow = other.GetComponent<BreakableWindow>();
            if (breakableWindow != null)
            {
                if (!breakableWindow.isBroken)
                {
                    breakableWindow.breakWindow();
                }
                
            }
            Destroy(other.gameObject);
            AudioManager.instance.Play("GlassBreaking", volume: 0.5f);
            EventManager.PlayerHit();
        }
        else if (other.CompareTag("Heart"))
        {
            EventManager.PlayerDied();
            Destroy(other.gameObject); // Destroy the heart GameObject
            Destroy(gameObject); // Destroy the projectile
            
        }
        else if (other.CompareTag("Vinyl"))
        {
            EventManager.PlayerHit();
        }
    }
}

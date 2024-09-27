using CarterGames.Assets.AudioManager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;  // Reference to the projectile prefab
    private Transform projectileSpawnPoint; // The point from where the projectile is spawned
    public float attackInterval = 2f;  // Interval between attacks 
    public float projectileSpeed = 10f;  // Speed of the projectile
    private Transform player;  // Reference to the player
    private Animator animator;  // Reference to the enemy's animator

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        projectileSpawnPoint = gameObject.transform.Find("SpawnPoint");
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        StartCoroutine(LaunchProjectile());
    }

    IEnumerator LaunchProjectile()
    {
        // Wait until the attack animation reaches the point where the projectile should be launched
        yield return new WaitForSeconds(0.5f);

        // Play attack sound
        AudioManager.instance.Play("Laser", volume:0.5f);
        // Instantiate and launch the projectile
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
        Vector3 direction = (player.position - projectileSpawnPoint.position).normalized;
        projectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;
    }

    public void Die()
    {
        animator.SetTrigger("Die");
        // Destroy the enemy after the disappear animation has finished
        Destroy(gameObject, 1f);  // Assuming the disappear animation is 1 second long
    }
}

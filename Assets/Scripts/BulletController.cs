using System;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField]
    private int MaxHits = 3;
    private int hitCount = 0;

    private const string EnemyTag = "Enemy";


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EnemyTag))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }

            hitCount++;

            if (hitCount >= MaxHits)
            {
                Destroy(gameObject);
            }
        }
    }
}

internal class EnemyHealth
{
    internal void TakeDamage(int v)
    {
        throw new NotImplementedException();
    }
}
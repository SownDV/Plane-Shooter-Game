using UnityEngine;

public class BulletImpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            ShipHealth shipHealth = other.GetComponent<ShipHealth>();
            shipHealth.TakeDamage(1);
            gameObject.SetActive(false);
        }
    }
    
}

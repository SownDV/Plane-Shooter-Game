using UnityEngine;

public class PlayerCollisionDamage : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ShipHealth health = GetComponent<ShipHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
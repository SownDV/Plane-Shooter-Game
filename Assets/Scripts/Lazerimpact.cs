using UnityEngine;

public class Lazerimpact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShipHealth shipHealth = other.GetComponent<ShipHealth>();
            shipHealth.TakeDamage(1);
            gameObject.SetActive(false);
        }
    }
}

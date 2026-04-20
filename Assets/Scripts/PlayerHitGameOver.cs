using UnityEngine;

public class PlayerHitGameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu chạm vào vật có Tag là "Enemy"
        
        if (other.CompareTag("Enemy"))
        {
            // Gọi hàm GameOver từ GameManager
            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver();
            }
        }
    }
}
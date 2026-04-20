using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    [Header("Settings")]
    public int maxHealth = 3;
    private int currentHealth;
    
    public bool isPlayer; 

    [Header("UI (Only for Player)")]
    public GameObject gameOverPanel; 

    void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // --- PHẦN BỔ SUNG ÂM THANH ---
        if (AudioManager.Instance != null)
        {
            if (isPlayer)
            {
                // Nếu người chơi chết, phát tiếng nổ. 
                // Nếu đây là mạng cuối cùng, phát thêm tiếng Game Over.
                AudioManager.Instance.PlaySFX(AudioManager.Instance.explosionSound);
                
                if (GameManager.Instance != null && GameManager.Instance.playerLives <= 1)
                {
                    AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOverSound);
                }
            }
            else
            {
                // Kẻ địch chết thì phát tiếng nổ bình thường
                AudioManager.Instance.PlaySFX(AudioManager.Instance.explosionSound);
            }
        }
        // ----------------------------

        if (isPlayer)
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.ReduceLife();

                if (GameManager.Instance.playerLives > 0)
                {
                    currentHealth = maxHealth; 
                }
                else
                {
                    GameManager.Instance.GameOver(); 
                    
                    if (PoolManager.Instance != null)
                        PoolManager.Instance.Return(gameObject);
                    else
                        gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddEnemyDropCoins();
            }

            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
            }

            if (EnemySpawner.Instance != null)
            {
                EnemySpawner.Instance.Destroy(gameObject);
            }
            else
            {
                gameObject.SetActive(false);
            }

            Debug.Log("Enemy Destroyed! +10 Coins");
        }
    }
}
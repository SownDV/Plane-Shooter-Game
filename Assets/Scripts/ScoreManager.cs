using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public int score = 0;
    public int level = 1; // Bắt đầu từ Level  (đạn cơ bản)
    public int killsToLevelUp = 10; // Đặt mốc 10 mạng

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score >= level * killsToLevelUp)
        {
            level++;
            UpgradePlayer();
        }
        
        
    }

    void UpgradePlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var controller = player.GetComponent<ShipController>();
            if (controller != null)
            {
                controller.Level = level;
                // Gọi hàm đổi đạn ngay lập tức
                controller.UpdateBulletLevel(); 
                Debug.Log("Level Up! Cấp độ hiện tại: " + level);
            }
        }
    }
}
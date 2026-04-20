using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    // Biến tĩnh để giữ nhân vật được chọn từ Scene Select
    public static GameObject SelectedPlayerPrefab;

    [Header("UI Panels")]
    public GameObject UISettingPanel;
    public GameObject NewGameDialogPanel;
    public GameObject VictoryPanel;

    [Header("In-Game Stats UI")]
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI coinText;

    [Header("Gameplay Variables")]
    public int playerLives = 3;
    public int totalCoins = 0;
    [HideInInspector] public bool isGameOver = false;

    [Header("Spawn Settings")]
    public Transform spawnPoint; // Vị trí xuất hiện của người chơi

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        // Ẩn các Panel
        if (UISettingPanel != null) UISettingPanel.SetActive(false);
        if (NewGameDialogPanel != null) NewGameDialogPanel.SetActive(false);
        if (VictoryPanel != null) VictoryPanel.SetActive(false);
        
        Time.timeScale = 1f;
        isGameOver = false;

        // Sinh ra nhân vật đã chọn
        SpawnPlayer();
        UpdateStatsUI();
    }

    void SpawnPlayer()
    {
        if (SelectedPlayerPrefab != null && spawnPoint != null)
        {
            Instantiate(SelectedPlayerPrefab, spawnPoint.position, Quaternion.identity);
        }
        else if (SelectedPlayerPrefab == null)
        {
            Debug.LogWarning("Chưa chọn nhân vật! Hãy quay lại Scene Select.");
        }
    }

    public void AddEnemyDropCoins()
    {
        if (isGameOver) return;
        totalCoins += 10; 
        UpdateStatsUI();
    }

    public void ReduceLife()
    {
        if (isGameOver) return;
        playerLives--;
        UpdateStatsUI();
        if (playerLives <= 0) GameOver();
    }

    void UpdateStatsUI()
    {
        if (livesText != null) livesText.text = playerLives.ToString();
        if (coinText != null) coinText.text = totalCoins.ToString();
    }

    public void GameOver()
{
    if (isGameOver) return;
    isGameOver = true;

    // 1. PHÁT ÂM THANH GAME OVER
    if (AudioManager.Instance != null)
    {
        // Phát tiếng hụt hẫng/thua cuộc
        AudioManager.Instance.PlaySFX(AudioManager.Instance.gameOverSound);

        // Dừng nhạc nền để tạo không khí nhấn mạnh việc kết thúc
        if (AudioManager.Instance.musicSource != null)
        {
            AudioManager.Instance.musicSource.Stop();
        }
    }

    // 2. HIỆN UI (Sử dụng Panel bạn đã gán)
    if (NewGameDialogPanel != null) 
    {
        NewGameDialogPanel.SetActive(true);
    }

    // 3. DỪNG THỜI GIAN
    Time.timeScale = 0f;
}

    public void Victory()
{
    if (isGameOver) return;
    isGameOver = true;

    // 1. Hiện bảng Victory
    if (VictoryPanel != null) 
    {
        VictoryPanel.SetActive(true);
    }

    // 2. PHÁT ÂM THANH CHIẾN THẮNG
    if (AudioManager.Instance != null)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.victorySound);
        
        // Tùy chọn: Tắt nhạc nền để tiếng thắng cuộc nghe rõ hơn
        if (AudioManager.Instance.musicSource != null)
        {
            AudioManager.Instance.musicSource.Stop();
        }
    }

    // 3. Dừng thời gian (Nên để sau cùng để đảm bảo các lệnh trên đã chạy)
    Time.timeScale = 0f;
}

    public void ResetCurrentScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu"); // Đổi đúng tên Scene Menu của bạn
    }
}
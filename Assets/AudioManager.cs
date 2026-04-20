using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource musicSource; // Dùng để phát nhạc nền (Loop)
    public AudioSource sfxSource;   // Dùng để phát hiệu ứng âm thanh (Bắn, nổ...)

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip shootSound;
    public AudioClip explosionSound;
    public AudioClip collectCoinSound;
    public AudioClip victorySound;
    public AudioClip gameOverSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ âm thanh không bị ngắt khi đổi Scene
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(backgroundMusic);
    }

    // Hàm phát nhạc nền
    public void PlayMusic(AudioClip clip)
    {
        if (clip == null) return;
        musicSource.clip = clip;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Hàm phát hiệu ứng âm thanh (SFX)
    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }
}
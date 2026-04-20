using UnityEngine;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private Slider musicSlider; // Kéo Slider nhạc nền vào đây

    private void Start()
    {
        // Kiểm tra xem đã gán Slider chưa
        if (musicSlider != null)
        {
            // Load lại giá trị âm lượng đã lưu, mặc định là 0.5 (50%)
            float savedVolume = PlayerPrefs.GetFloat("BackgroundVolume", 0.5f);
            musicSlider.value = savedVolume;

            // Áp dụng âm lượng ngay khi bắt đầu
            SetMusicVolume(savedVolume);

            // Đăng ký sự kiện khi kéo thanh trượt
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
        }
    }

    public void SetMusicVolume(float value)
    {
        if (AudioManager.Instance != null && AudioManager.Instance.musicSource != null)
        {
            // Chỉnh âm lượng của máy phát nhạc nền
            AudioManager.Instance.musicSource.volume = value;

            // Lưu lại để lần sau mở game vẫn giữ mức này
            PlayerPrefs.SetFloat("BackgroundVolume", value);
        }
    }
}
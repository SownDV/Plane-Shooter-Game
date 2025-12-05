using UnityEngine;

public class BtnSetting : MonoBehaviour
{
    public GameObject settingPanel;

    void Start()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(false);
        }
    }

    public void ToggleSettings()
    {
        bool isPanelActive = !settingPanel.activeSelf;
        settingPanel.SetActive(isPanelActive);

        if (isPanelActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void CloseSettings()
    {
        settingPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

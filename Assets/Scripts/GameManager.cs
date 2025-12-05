using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject UISettingPanel;

    public GameObject NewGameDialogPanel;

    void Start()
    {
        if (UISettingPanel != null)
        {
            UISettingPanel.SetActive(false);
        }
        if (NewGameDialogPanel != null)
        {
            NewGameDialogPanel.SetActive(false);
        }
        Time.timeScale = 1f;

    }

    public void ToggleSettings()
    {
        if (UISettingPanel == null) return;

        bool isPanelActive = !UISettingPanel.activeSelf;
        UISettingPanel.SetActive(isPanelActive);

        Time.timeScale = isPanelActive ? 0f : 1f;
    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void ResetCurrentScene()
    {
        if (NewGameDialogPanel != null)
        {
            NewGameDialogPanel.SetActive(false);
        }

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CloseNewGameDialog()
    {
        if (NewGameDialogPanel != null)
        {
            NewGameDialogPanel.SetActive(false);
        }
    }
}

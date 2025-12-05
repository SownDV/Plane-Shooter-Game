using UnityEngine;

public class BtnReturn : MonoBehaviour
{
    public GameObject returnPanel;

    void Start()
    {
        if (returnPanel != null)
        {
            returnPanel.SetActive(false);
        }
    }

    public void ToggleReturn()
    {
        bool isPanelActive = !returnPanel.activeSelf;
        returnPanel.SetActive(isPanelActive);

        if (isPanelActive)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }


    public void CloseReturn()
    {
        returnPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnHome : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("Menu");
    }
}

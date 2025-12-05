using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnYesReset : MonoBehaviour
{
    public void ResetCurrentScene()
    {
        Time.timeScale = 1f;

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        SceneManager.LoadScene(currentSceneIndex);
    }
}

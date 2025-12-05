using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGameBtn : MonoBehaviour
{

    public Button btn_gameplay;

    void Start()
    {
        btn_gameplay.onClick.AddListener(OnPlayGameButtonClicked);
    }
    private void OnPlayGameButtonClicked()
    {
        SceneManager.LoadScene("Level 1");
    }
}

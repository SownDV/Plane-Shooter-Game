using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnSelectCharater : MonoBehaviour
{
    public Button btn_selectCharacter;

    void Start()
    {
        btn_selectCharacter.onClick.AddListener(OnPlayGameButtonClicked);
    }
    private void OnPlayGameButtonClicked()
    {
        SceneManager.LoadScene("Select Charater");
    }

}

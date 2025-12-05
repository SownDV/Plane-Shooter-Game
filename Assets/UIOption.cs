using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIOption : MonoBehaviour
{

    public GameObject gameSettingUI;

    public void ShowOptionsUI()
    {
        gameSettingUI.SetActive(true);
    }

    public void HideOptionsUI()
    {
        gameSettingUI.SetActive(false);
    }
}

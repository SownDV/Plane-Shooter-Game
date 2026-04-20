using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Kéo các Prefab Player vào đây trong Inspector

    public void SelectCharacter(int index)
    {
        // Lưu Prefab đã chọn vào GameManager tĩnh
        GameManager.SelectedPlayerPrefab = playerPrefabs[index];
        
        // Chuyển sang Scene chơi game
        SceneManager.LoadScene("Level 1"); 
    }
}
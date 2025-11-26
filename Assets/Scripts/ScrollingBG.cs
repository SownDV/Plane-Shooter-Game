using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed;
    [SerializeField]
    private Renderer bg_Renderer;

    void Update()
    {
        bg_Renderer.material.mainTextureOffset += new Vector2(0, Time.deltaTime * speed);
    }
}

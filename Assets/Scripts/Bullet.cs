using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 5;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }
}

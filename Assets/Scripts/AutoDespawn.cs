using UnityEngine;

public class AutoDespawn : MonoBehaviour
{
    public float Lifetime = 2;
    private float m_CurrentTimer = 0;

    void OnEnable()
    {
        m_CurrentTimer = 0;
    }
    // Update is called once per frame
    void Update()
    {
        m_CurrentTimer += Time.deltaTime;
        if (m_CurrentTimer >= Lifetime)
        {
            PoolManager.Instance.Return(gameObject);
        }
    }
}

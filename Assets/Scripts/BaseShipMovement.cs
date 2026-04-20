using UnityEngine;
using UnityEngine.Rendering.Universal;

public abstract class BaseShipMovement : MonoBehaviour
{
    [Header("Base Movement Settings")]
    public string Id;
    
    protected ShipController ShipController;
    void Awake()
    {
        ShipController = GetComponentInParent<ShipController>();
    }
    protected Transform target;

    public abstract void OnUpdate();

    // Hàm để gán mục tiêu cho AI (Ví dụ từ ShipController hoặc Spawner)
    public virtual void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
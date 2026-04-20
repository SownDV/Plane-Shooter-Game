using UnityEngine;
using System.Collections.Generic;

public class ShipController : MonoBehaviour
{
    public int Level;
    // Movement
    // Skills
    // Heatlth
    public BaseShipMovement Movement;
    public ShipHealth Health;
    public ShipSkills Skills;
    public ShipInput Input;
    public ShipMovementManager ShipMovementManager;
    public List<GameObject> shooterPatterns; // Kéo các Pattern 1, 2, 3 vào đây


    public AutoShooting AutoShooting;


    void Start()
    {
        Input?.Initialize(this);
        Skills?.Initialize(this);
        AutoShooting?.Initialize(this);
        // Movement = GetComponent<BaseShipMovement>();
        // UpdateBulletLevel();
    }
    void Update()
    {
        Movement?.OnUpdate();
        Skills?.OnUpdate();
        Input?.OnUpdate();
        AutoShooting?.OnUpdate();
    }

public void UpdateBulletLevel()
{
    if (shooterPatterns == null || shooterPatterns.Count == 0) return;

    // Đảm bảo Level tối thiểu là 1 trước khi tính toán
    if (Level < 1) Level = 1;

    // Tính toán Index: Level 1 -> Index 0 | Level 2 -> Index 1 | Level 3 -> Index 2
    int index = Level - 1;

    // Giới hạn Index để không bao giờ vượt quá số lượng Pattern bạn có
    index = Mathf.Clamp(index, 0, shooterPatterns.Count - 1);

    Debug.Log("Đang kích hoạt Pattern tại Index: " + index + " ứng với Level: " + Level);

    // Tắt tất cả các pattern
    foreach (var pattern in shooterPatterns)
    {
        if (pattern != null) pattern.SetActive(false);
    }


    // Bật đúng pattern theo index
    if (shooterPatterns[index] != null)
    {
        shooterPatterns[index].SetActive(true);
    }
}
}

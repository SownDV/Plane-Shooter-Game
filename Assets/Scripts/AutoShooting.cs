using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    private ShipController Controller;

    // Tốc độ bắn (Thời gian chờ giữa các lần bắn), có thể điều chỉnh trong Inspector
    public float FireRate = 1.0f;

    // Thời điểm bắn tiếp theo
    private float nextFireTime;

    // Hàm này được ShipController gọi để thiết lập liên kết
    public void Initialize(ShipController controller)
    {
        Controller = controller;
        // Đặt thời điểm bắn đầu tiên ngay khi khởi tạo
        nextFireTime = Time.time + FireRate;
    }

    // Hàm này được ShipController gọi mỗi khung hình (thay thế Update thông thường)
    public void OnUpdate()
    {
        // Kiểm tra xem đã đến lúc bắn chưa
        if (Time.time >= nextFireTime)
        {
            // Bắn đạn thường (Giả sử kỹ năng 0 là bắn thường - Normal Attack Skill)
            Controller.Skills.CastSkill(0);

            // Thiết lập thời điểm bắn tiếp theo
            nextFireTime = Time.time + FireRate;
        }

        // (Không cần kiểm tra Input.GetKey/GetKeyDown nào ở đây)
    }
}

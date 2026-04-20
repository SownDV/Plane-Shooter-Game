using UnityEngine;

public class BossMovement : BaseShipMovement
{
    public float moveSpeed = 5f;
    public float stopY = 0f; // Vị trí giữa màn hình theo trục Y

    public override void OnUpdate()
    {
        // Nếu vị trí Y hiện tại vẫn cao hơn điểm dừng
        if (transform.position.y > stopY)
        {
            // Di chuyển xuống dưới
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        else
        {
            // Đảm bảo nó dừng chính xác tại stopY
            Vector3 pos = transform.position;
            pos.y = stopY;
            transform.position = pos;
        }
    }
}
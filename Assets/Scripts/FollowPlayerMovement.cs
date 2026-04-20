using UnityEngine;

public class FollowPlayerMovement : BaseShipMovement
{
    public Transform player;
    public float speed = 6f;
    public float stopDistance = 1.5f;
    public float rotateSpeed = 5f;

    public float delayBeforeMove = 0.5f;

    private float timer = 0f;
    private bool canMove = false;

    void Start()
    {
        // Tự tìm player
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null)
                player = p.transform;
        }
    }

    public override void OnUpdate()
    {
        if (player == null) return;

        // Đếm thời gian
        // if (!canMove)
        // {
        //     timer += Time.deltaTime;

        //     if (timer >= delayBeforeMove)
        //     {
        //         canMove = true;
        //     }
        //     return; // chưa đủ 0.5s thì không di chuyển
        // }

        MoveToPlayer();
      //  RotateToPlayer();
    }

    void MoveToPlayer()
    {
        float distance = Vector3.Distance(ShipController.transform.position, player.position);

        if (distance > stopDistance)
        {
            Vector3 direction = (player.position - ShipController.transform.position).normalized;
            ShipController.transform.position += direction * speed * Time.deltaTime;
        }
    }


    void RotateToPlayer()
    {
        Vector3 direction = player.position - ShipController.transform.position;
        direction.y = 0;

        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotateSpeed * Time.deltaTime
            );
        }
    }
}
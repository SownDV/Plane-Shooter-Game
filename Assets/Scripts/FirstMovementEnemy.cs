using System.Collections;
using UnityEngine;

public class FirstMovementEnemy : BaseShipMovement
{
    private bool isReachTarget = false;
    public float movementspeed = 5f;
    private Coroutine switchPlanCoroutine; // Lưu Coroutine để quản lý

    public override void SetTarget(Transform newTarget)
    {
        base.SetTarget(newTarget);
        isReachTarget = false;
        
        // Nếu Enemy được tái sử dụng từ Pool, ta nên dừng các Coroutine cũ
        if (switchPlanCoroutine != null)
        {
            StopCoroutine(switchPlanCoroutine);
        }
    }

    public override void OnUpdate()
    {
        if (isReachTarget || target == null)
            return;

        // Tính toán hướng và di chuyển tới target đầu tiên
        var direction = target.position - ShipController.transform.position;
        ShipController.transform.position += direction.normalized * movementspeed * Time.deltaTime;

        // Kiểm tra nếu đã đến gần target
        if (Vector2.Distance(ShipController.transform.position, target.position) < 0.5f)
        {
            isReachTarget = true;
            // Bắt đầu kế hoạch chuyển đổi di chuyển
            switchPlanCoroutine = StartCoroutine(SwitchPlan());
        }
    }

    IEnumerator SwitchPlan()
    {
        Debug.Log("Waiting for 2s...");
        yield return new WaitForSeconds(2f);

        // Kiểm tra xem ShipController và Manager có tồn tại không trước khi gọi dòng 42
        if (ShipController != null && ShipController.ShipMovementManager != null)
        {
            Debug.Log("Switching to: Run And Follow");
            ShipController.ShipMovementManager.SwitchMovement("Run And Follow");
        }

        yield return new WaitForSeconds(2f);

        if (ShipController != null && ShipController.ShipMovementManager != null)
        {
            Debug.Log("Switching back to: First Movement Enemy");
            ShipController.ShipMovementManager.SwitchMovement("First Movement Enemy");
            isReachTarget = false;
        }
    }

    // Quan trọng: Dừng mọi hành động khi Enemy bị biến mất (Return to Pool)
    private void OnDisable()
    {
        if (switchPlanCoroutine != null)
        {
            StopCoroutine(switchPlanCoroutine);
            switchPlanCoroutine = null;
        }
        isReachTarget = false;
    }
}
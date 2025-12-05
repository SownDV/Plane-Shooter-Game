using UnityEngine;

public class ShipInput : MonoBehaviour
{
    private ShipController Controller;
    public void Initialize(ShipController controller)
    {
        Controller = controller;
    }
    public void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Controller.Skills.CastSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Controller.Skills.CastSkill(1);
        }
    }
}

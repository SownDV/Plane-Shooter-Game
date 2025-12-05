using UnityEngine;

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


    void Start()
    {
        Input?.Initialize(this);
        Skills?.Initialize(this);
    }
    void Update()
    {
        Movement?.OnUpdate();
        Skills?.OnUpdate();
        Input?.OnUpdate();
    }
}

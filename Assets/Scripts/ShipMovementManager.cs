using System.Collections.Generic;
using UnityEngine;

public class ShipMovementManager : MonoBehaviour
{
    public List<BaseShipMovement> ListMovementTypes = new();
    private ShipController shipController;

    void Start()
    {
        shipController = GetComponent<ShipController>();
    }

    public void SwitchMovement(string id)
    {
        foreach (var shipMovement in ListMovementTypes)
        {
            if (shipMovement.Id == id)
            {
                shipController.Movement = shipMovement;
            }
        }
    }
}
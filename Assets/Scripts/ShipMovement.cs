using UnityEngine;

public class ShipMovement : BaseShipMovement
{
    public float Speed = 5f;
    private Vector3 _minBounds;
    private Vector3 _maxBounds;
    private const float Padding = 0.5f;

    public void Start()
    {
        Camera mainCamera = Camera.main;
        float zDistance = 10.0f;

        _minBounds = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, zDistance));
        _maxBounds = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, zDistance));

        _minBounds.x += Padding;
        _minBounds.y += Padding;
        _maxBounds.x -= Padding;
        _maxBounds.y -= Padding;
    }

    public override void OnUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical) * Speed * Time.deltaTime;
        transform.position += movement;

        float clampedX = Mathf.Clamp(transform.position.x, _minBounds.x, _maxBounds.x);
        float clampedY = Mathf.Clamp(transform.position.y, _minBounds.y, _maxBounds.y);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
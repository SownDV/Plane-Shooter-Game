using UnityEngine;

public class PatrollShipMovement : BaseShipMovement
{
  public Transform A, B;
  public float Speed;
  private bool MveB = true;
  public override void OnUpdate()
  {
    if (MveB)
    {
      transform.position = Vector3.MoveTowards(transform.position, B.position, Speed * Time.deltaTime);
      if (Vector2.Distance(transform.position, B.position) < 0.1f)
      {
        MveB = false;
      }
    }
    else
    {
      transform.position = Vector3.MoveTowards(transform.position, A.position, Speed * Time.deltaTime);
      if (Vector2.Distance(transform.position, A.position) < 0.1f)
      {
        MveB = true;
      }
    }
  }
}
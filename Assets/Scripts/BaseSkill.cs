using UnityEngine;

public abstract class BaseSkill : MonoBehaviour
{
  public int SkillId;
  public float Cooldown;
  public ShipController Owner;
  public bool CanCast => !m_IsCooldowning;
  private float m_CurrentCooldown;
  private bool m_IsCooldowning;
  public virtual void Cast()
  {
    m_IsCooldowning = true;
    m_CurrentCooldown = 0;
  }
  public virtual void OnUpdate()
  {
    if (m_IsCooldowning == false) return;
    m_CurrentCooldown += Time.deltaTime;
    if (m_CurrentCooldown >= Cooldown)
    {
      m_IsCooldowning = false;
    }
  }
}
/*
skill co cooldown
skill chay ntn

*/
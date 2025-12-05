using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  manage skills in this entity
/// </summary>
public class ShipSkills : MonoBehaviour
{
    public List<BaseSkill> m_Skills = new List<BaseSkill>();

    public void Initialize(ShipController controller)
    {
        foreach (var skill in m_Skills)
        {
            skill.Owner = controller;
        }
    }


    public void CastSkill(int id)
    {
        var skill = m_Skills.Find(x => x.SkillId == id);
        if (skill == null) return;
        if (skill.CanCast)
        {
            skill.Cast();
        }
    }

    public void OnUpdate()
    {
        foreach (var skill in m_Skills)
        {
            skill.OnUpdate();
        }
    }
}
/*
skill co cooldown
skill chay ntn

*/
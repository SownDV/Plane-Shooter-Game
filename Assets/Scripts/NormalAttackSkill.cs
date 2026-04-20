using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletPattern
{
    public Transform[] hitPoints;
}
public class NormalAttackSkill : BaseSkill
{
    public GameObject m_BulletPrefab;
    public List<BulletPattern> m_Patterns;

    public override void Cast()
    {
        base.Cast();
        // spawn bullet
        int targetPatternInde = Owner.Level - 1;
        if (targetPatternInde >= m_Patterns.Count)
        {
            targetPatternInde = m_Patterns.Count - 1;
        }
        SpawnBullet(m_Patterns[targetPatternInde]); // because of level start at 1
    }

    void SpawnBullet(BulletPattern patern)
    {

        foreach (var point in patern.hitPoints)
        {
            var bullet = PoolManager.Instance.Rent(m_BulletPrefab, point.position);
            bullet.transform.rotation = point.rotation;
        }
    }
}

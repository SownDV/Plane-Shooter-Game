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
        SpawnBullet(m_Patterns[Owner.Level]);
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

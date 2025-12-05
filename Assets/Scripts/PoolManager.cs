using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public Dictionary<GameObject, List<GameObject>> pool = new Dictionary<GameObject, List<GameObject>>();
    void Awake()
    {
        Instance = this;
    }

    public GameObject Rent(GameObject prefab, Vector2 pos = default)
    {
        if (pool.ContainsKey(prefab) == false)
        {
            pool.Add(prefab, new List<GameObject>());
        }

        var active = pool[prefab].Find(t => !t.activeSelf);
        if (active == null)
        {
            active = Instantiate(prefab);
            pool[prefab].Add(active);
            active.transform.position = pos;
        }
        else
        {
            active.transform.position = pos;
        }
        active.SetActive(true);
        return active;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}

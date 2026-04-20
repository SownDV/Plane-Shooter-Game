using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    public Dictionary<GameObject, List<GameObject>> pool = new Dictionary<GameObject, List<GameObject>>(); // 1(on) 2(off) 3(off) 4(on)
    void Awake()
    {
        Instance = this;
    }

    public GameObject Rent(GameObject prefab, Vector2 pos = default)
{
    if (!pool.ContainsKey(prefab))
    {
        pool.Add(prefab, new List<GameObject>());
    }

    // Tìm object đang tắt
    var active = pool[prefab].Find(t => t != null && !t.activeSelf);

    if (active == null)
    {
        active = Instantiate(prefab);
        pool[prefab].Add(active);
    }

    active.transform.position = pos; // Gán vị trí cho cả con mới lẫn con cũ
    active.SetActive(true);
    return active;
}

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
    }
}

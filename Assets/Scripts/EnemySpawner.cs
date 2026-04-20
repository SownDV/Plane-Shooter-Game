using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; set; }

    public Transform topSpawnerPoint;
    public List<Transform> ListSpawnerPoint;
    public List<WaveEnemy> Waves;
    public int CurrentWave = 0;
    public int MaxEnemyInSameTime = 3;
    private int CurentEnemyInSameTime = 0;

    // Biến để kiểm tra đã hoàn thành việc sinh quái chưa
    private bool isAllWavesSpawned = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (Waves != null && Waves.Count > 0)
        {
            StartCoroutine(SpawnAllWaves());
        }
    }

    private void Update()
    {
        // KIỂM TRA ĐIỀU KIỆN CHIẾN THẮNG
        // Nếu đã sinh hết quái VÀ trên màn hình không còn con quái nào
        if (isAllWavesSpawned && CurentEnemyInSameTime <= 0)
        {
            if (GameManager.Instance != null && !GameManager.Instance.isGameOver)
            {
                isAllWavesSpawned = false; // Đặt về false để không gọi Victory liên tục nhiều lần
                GameManager.Instance.Victory();
            }
        }
    }

    private IEnumerator SpawnAllWaves()
    {
        while (CurrentWave < Waves.Count)
        {
            Debug.Log("Start Wave: " + CurrentWave);
            
            foreach (var enemy in Waves[CurrentWave].Enemies)
            {
                while (CurentEnemyInSameTime >= MaxEnemyInSameTime)
                {
                    yield return null;
                }
                yield return new WaitForSeconds(enemy.TimeSpawn);
            
                if (PoolManager.Instance != null && enemy.Prefab != null)
                {
                    // Lưu ý: ListSpawnerPoint.Count thay vì Capacity
                    var rdPoint = ListSpawnerPoint[Random.Range(0, ListSpawnerPoint.Count)];
                    var pos = rdPoint.position;
                    var shipObj = PoolManager.Instance.Rent(enemy.Prefab, topSpawnerPoint.position);
                    var ship = shipObj.GetComponent<ShipController>();

                    if (ship != null && ship.Movement != null) 
                    {
                        var movemnt = ship.Movement.GetComponent<FirstMovementEnemy>();
                        if (movemnt != null)
                        {
                            ship.transform.position = topSpawnerPoint.position;
                            movemnt.SetTarget(rdPoint);
                        }
                        else
                        {
                            ship.transform.position = rdPoint.position;
                        }
                    }
                    else
                    {
                        shipObj.transform.position = rdPoint.position;
                    }
                }
                CurentEnemyInSameTime++;       
            }

            Debug.Log("End Wave: " + CurrentWave);
            CurrentWave++;

            if (CurrentWave < Waves.Count)
            {
                yield return new WaitForSeconds(3f);
            }
        }

        Debug.Log("All Waves Completed!");
        // Đánh dấu đã sinh xong toàn bộ quái của tất cả các Wave
        isAllWavesSpawned = true; 
    }

    public void Destroy(GameObject ship)
    {
        PoolManager.Instance.Return(ship);
        CurentEnemyInSameTime--;

        // Đảm bảo số lượng không bao giờ âm để tránh lỗi logic
        if (CurentEnemyInSameTime < 0) CurentEnemyInSameTime = 0;
    }
}

[System.Serializable]
public class WaveEnemy
{
    public List<EnemyData> Enemies;
}

[System.Serializable]
public class EnemyData
{
    public GameObject Prefab;
    public float TimeSpawn;
}
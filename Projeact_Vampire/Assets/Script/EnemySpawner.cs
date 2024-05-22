using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab của kẻ địch
    public Transform[] spawnPoints; // Các vị trí spawn (empty object)
    public Transform playerTransform; // Transform của người chơi
    public float initialSpawnTime = 2f; // Thời gian ban đầu giữa các lần spawn
    public float spawnTimeDecreaseRate = 0.1f; // Tốc độ giảm thời gian giữa các lần spawn
    public float minSpawnTime = 0.5f; // Thời gian spawn tối thiểu

    private float currentSpawnTime;

    void Start()
    {
        currentSpawnTime = initialSpawnTime;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(currentSpawnTime);

            // Chọn vị trí spawn ngẫu nhiên
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Spawn kẻ địch
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // Gán mục tiêu cho kẻ địch
            BasicEnemy enemyScript = enemy.GetComponent<BasicEnemy>();

            if (enemyScript != null)
            {
                enemyScript.targetDestination = playerTransform;
            }
            else
            {
                Debug.LogError("Prefab không có component BasicEnemy");
            }

            // Giảm thời gian spawn nếu chưa đạt đến giới hạn tối thiểu
            if (currentSpawnTime > minSpawnTime)
            {
                currentSpawnTime -= spawnTimeDecreaseRate;
            }
        }
    }
}

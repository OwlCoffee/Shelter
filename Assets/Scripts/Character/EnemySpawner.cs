using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;

    public Transform[] spawnPoints;

    private List<Enemy> enemies = new List<Enemy>();
    private int spawnCount;

    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count <= 0)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnEnemy();
            }
        }
    }

    private void SpawnEnemy()
    {
        //Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Vector3 pos;
        pos.x = Random.Range(0, 100);
        pos.y = 0.0f;
        pos.z = Random.Range(0, 100);

        Enemy enemy = Instantiate(enemyPrefab, pos, Quaternion.Euler(Vector3.zero));
        enemies.Add(enemy);
        //enemy.SetSpeed(Random.Range(2, 7));

        enemy.onDeath += () => enemy.tracePlayer.isStopped = true;
        enemy.onDeath += () => enemy.enemyAnimator.SetTrigger("Die");
        enemy.onDeath += () => enemies.Remove(enemy);
        enemy.onDeath += () => Destroy(enemy.gameObject, 5.0f);
    }
}

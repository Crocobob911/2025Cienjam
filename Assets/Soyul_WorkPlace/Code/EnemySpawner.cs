using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    private float spawnTimer = 0f;
    [SerializeField] private float timeBetweenSpawns;

    private float time = 0f;

    private void Update()
    {
        if (spawnTimer >= timeBetweenSpawns)
        {
            spawnTimer = 0;
            SpawnEnemy(Random.Range(-3, 4));
        }
        
        spawnTimer += Time.deltaTime;
        time += Time.deltaTime;

        timeBetweenSpawns = time <= 1f ? 1f : 1f / Mathf.Log(time, 2);
    }

    private void SpawnEnemy(int lane)
    {
        var enemyObj = EnemyPoolManager.Instance.Pool.Get();
        enemyObj.transform.position = new Vector2(10f, lane * 3f);
    }
}
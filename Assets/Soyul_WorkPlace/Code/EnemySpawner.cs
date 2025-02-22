using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    private int difficulty;

    [SerializeField] private GameObject[] enemy_list;

    private void Awake()
    {
        difficulty = 3;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemyIter());
    }

    IEnumerator SpawnEnemyIter()
    {
        while (true)
        {
            SpawnEnemy(enemy_list[Random.Range(0, difficulty)], Random.Range(-1, 2));
            yield return new WaitForSeconds(2f);
        }
    }

    private void SpawnEnemy(GameObject enemy, int lane)
    {
        GameObject temp = Instantiate(enemy);
        if (lane == -1) { temp.transform.position = new Vector2(10f, -3.5f); }
        if (lane == 0) { temp.transform.position = new Vector2(10f, 0f); }
        if (lane == 1) { temp.transform.position = new Vector2(10f, 3.5f); }
    }
}
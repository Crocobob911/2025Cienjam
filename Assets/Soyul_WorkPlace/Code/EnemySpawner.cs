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
            SpawnEnemy(enemy_list[Random.Range(0, difficulty)], Random.Range(-3, 4));
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SpawnEnemy(GameObject enemy, int lane)
    {
        GameObject temp = Instantiate(enemy);
        temp.transform.position = new Vector2(10f, lane * 3f);
    }
}
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AmbientSpawner : MonoBehaviour
{
    private int difficulty;

    [SerializeField] private GameObject[] ambient_list;

    private void Awake()
    {
        difficulty = 2;
    }

    private void Start()
    {
        StartCoroutine(SpawnAmbientIter());
    }

    IEnumerator SpawnAmbientIter()
    {
        while (true)
        {
            SpawnAmbient(ambient_list[Random.Range(0, difficulty)]);
            yield return new WaitForSeconds(0.25f);
        }
    }

    private void SpawnAmbient(GameObject ambient)
    {
        GameObject temp = Instantiate(ambient);
        temp.transform.position = new Vector2(10f, Random.Range(-9f, 9f));
    }
}
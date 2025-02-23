using UnityEngine;

public class AmbientSpawner : MonoBehaviour
{
    private float spawnTimer = 0;
    [SerializeField] private float timeBetweenSpawn = 0.5f;

    private void Update()
    {
        if (spawnTimer >= timeBetweenSpawn)
        {
            spawnTimer = 0;
            SpawnAmbient();
        }
        spawnTimer += Time.deltaTime;
    }

    private void SpawnAmbient()
    {
        var ambientObj = AmbientPoolManager.Instance.Pool.Get();
        ambientObj.transform.position = new Vector2(10f,Random.Range(-9f,9f));
    }
}
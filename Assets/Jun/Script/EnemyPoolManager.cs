using UnityEngine;
using UnityEngine.Pool;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab_list;
    
    public static EnemyPoolManager Instance;
    
    public IObjectPool<GameObject> Pool;

    [SerializeField] private int defaultCapacity;
    [SerializeField] private int maxCapacity;

    private void Awake()
    {
        if(Instance == null)    Instance = this;
        else Destroy(gameObject);
        
        Init();
    }

    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            false, defaultCapacity, maxCapacity);
    }
    
    private GameObject CreatePooledItem()
    {
        GameObject poolObj = Instantiate(enemyPrefab_list[Random.Range(0, enemyPrefab_list.Length)], transform);
        poolObj.GetComponent<Enemy>().Pool = Pool;
        return poolObj;
    }

    private void OnTakeFromPool(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    private void OnReturnedToPool(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
}

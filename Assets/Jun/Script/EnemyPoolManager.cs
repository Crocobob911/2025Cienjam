using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class EnemyPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab_list;
    
    public static EnemyPoolManager Instance;
    
    public IObjectPool<GameObject> Pool;

    [SerializeField] private int initSize;
    [SerializeField] private int maxSize;

    private void Awake()
    {
        if(Instance == null)    Instance = this;
        else Destroy(gameObject);
        
        Init();
    }

    private void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            false, initSize, maxSize);
        
        for (int i = 0; i < initSize; i++)
        {
            var obj = CreatePooledItem();
            obj.SetActive(false);
            Pool.Release(obj);
        }
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

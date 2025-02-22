using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

public class AmbientPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ambientPrefab_list;
    
    public static AmbientPoolManager Instance;
    
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
            true, defaultCapacity, maxCapacity);
    }
    
    private GameObject CreatePooledItem()
    {
        GameObject poolObj = Instantiate(ambientPrefab_list[Random.Range(0, ambientPrefab_list.Length)], transform);
        poolObj.GetComponent<Ambient>().Pool = Pool;
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

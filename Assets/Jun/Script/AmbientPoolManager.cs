using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class AmbientPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ambientPrefab_list;
    
    public static AmbientPoolManager Instance;

    public IObjectPool<GameObject> Pool { get; set; }

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
        Pool = new ObjectPool<GameObject>(CreatePooledItem, OnGet, OnRelease, OnDestroyPoolObject,
            true, initSize, maxSize);

        for (int i = 0; i < initSize; i++)
        {
            var obj = CreatePooledItem();
            obj.SetActive(false);
            Pool.Release(obj);
        }
    }
    
    private GameObject CreatePooledItem()
    {
        GameObject poolObj = Instantiate(ambientPrefab_list[Random.Range(0, ambientPrefab_list.Length)], transform);
        poolObj.GetComponent<Ambient>().Pool = Pool;
        return poolObj;
    }

    private void OnGet(GameObject poolGo)
    {
        poolGo.SetActive(true);
    }

    private void OnRelease(GameObject poolGo)
    {
        poolGo.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject poolGo)
    {
        Destroy(poolGo);
    }
}

using System;
using UnityEngine;
using UnityEngine.Pool;

public class BubbleProjectilePoolManager : MonoBehaviour
{
    public static BubbleProjectilePoolManager INSTANCE;

    [SerializeField] private GameObject bubblePrefab;
    public IObjectPool<GameObject> Pool { get; set; }

    [SerializeField] private int defaultCapacity = 1;
    [SerializeField] private int maxCapacity = 5000;

    private void Awake() {
        if(INSTANCE == null)    INSTANCE = this;
        else Destroy(this.gameObject);
        
        Init();
    }

    private void Start() {
        for (int i = 0; i < maxCapacity; i++) {
            CreateBubble().SetActive(false);
        }
    }

    private void Init() {
        Pool = new ObjectPool<GameObject>(CreateBubble, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            true, defaultCapacity, maxCapacity);
    }

    private GameObject CreateBubble() {
        GameObject bubblePoolObj = Instantiate(bubblePrefab, transform, true);
        bubblePoolObj.GetComponent<BubbleProjectile>().Pool = Pool;
        return bubblePoolObj;
    }
    
    private void OnTakeFromPool(GameObject poolGo) {
        poolGo.SetActive(true);
    }
    
    private void OnReturnedToPool(GameObject poolGo){
        poolGo.SetActive(false);
    }
    
    private void OnDestroyPoolObject(GameObject poolGo) {
        Destroy(poolGo);
    }
}

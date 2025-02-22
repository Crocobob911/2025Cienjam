using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;

public class BubbleProjectilePoolManager : MonoBehaviour
{
    public static BubbleProjectilePoolManager INSTANCE;

    [SerializeField] private GameObject bubblePrefab;
    public IObjectPool<GameObject> Pool { get; set; }

    [SerializeField] private int initSize = 1000;
    [SerializeField] private int maxSize = 5000;

    private void Awake() {
        if(INSTANCE == null)    INSTANCE = this;
        else Destroy(gameObject);
        
        Init();
    }

    private void Init() {
        Pool = new ObjectPool<GameObject>(CreateBubble, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            true, initSize, maxSize);
        
        for (int i = 0; i < initSize; i++)
        {
            var obj = CreateBubble();
            obj.SetActive(false);
            Pool.Release(obj);
        }
    }

    private GameObject CreateBubble() {
        GameObject bubblePoolObj = Instantiate(bubblePrefab, transform, true);
        bubblePoolObj.GetComponent<Bubble>().Pool = Pool;
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

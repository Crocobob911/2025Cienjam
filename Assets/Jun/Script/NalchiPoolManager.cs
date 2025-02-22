using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Pool;

public class NalchiPoolManager : MonoBehaviour {
    public static NalchiPoolManager INSTANCE;

    [SerializeField] private GameObject nalchiPrefab;
    public IObjectPool<GameObject> Pool { get; set; }

    [SerializeField] private int defaultCapacity = 1;
    [SerializeField] private int maxCapacity = 200;

    private void Awake() {
        if(INSTANCE == null)    INSTANCE = this;
        else Destroy(this.gameObject);
        
        Init();
    }

    private void Init() {
        Pool = new ObjectPool<GameObject>(CreateNalchi, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, 
            true, defaultCapacity, maxCapacity);
    }

    private GameObject CreateNalchi() {
        GameObject nalchiPoolObj = Instantiate(nalchiPrefab, transform.GetChild(0), true);
        nalchiPoolObj.GetComponent<Nalchi>().Pool = Pool;
        return nalchiPoolObj;
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

using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class NalchiGang : MonoBehaviour
{
    public static NalchiGang INSTANCE;

    private int fishCount = 0;
    
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private List<Nalchi> nalchiList;
    [SerializeField] private GameObject gangCenter;
    
    private void Awake() {
        if(INSTANCE == null)    INSTANCE = this;
        else Destroy(gameObject);
    }
    
    private void Start() {
        AddNalchies(1);
    }

    void Update()
    {
        gangCenter.transform.position = transform.position + new Vector3(10f, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
    }

    private void Jump() {
        SoundManager.instance.PlaySFX(0);
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);       
        
        foreach (var nalchi in nalchiList) {
            nalchi.Jump(jumpForce);
            nalchi.GatherToCenter();
        }
    }

    private void AddNalchi() {
        SoundManager.instance.PlaySFX(1);
        var nalchiObj = NalchiPoolManager.INSTANCE.Pool.Get();
        nalchiList.Add(nalchiObj.GetComponent<Nalchi>());
        nalchiObj.transform.position = gangCenter.transform.position;
    }

    public void AddNalchies(int count) {
        ChangeFishCount(count);
        
        for (int i = 0; i < count; i++) {
            AddNalchi();
        }

        foreach (var nalchi in nalchiList) {
            nalchi.GatherToCenter();
        }
    }

    private void ChangeFishCount(int count)
    {
        fishCount += count;

        if (fishCount <= 0)
        {
            GameManager.INSTANCE.GameOver();
        }
    }

    public void RemoveNalchi(Nalchi nalchi) {
        SoundManager.instance.PlaySFX(2);
        ChangeFishCount(-1);
        nalchiList.Remove(nalchi);
    }
}
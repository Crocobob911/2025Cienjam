using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class NalchiGang : MonoBehaviour
{
    
    [SerializeField] private int nalchiCount = 0;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private List<Nalchi> nalchiList;
    [SerializeField] private GameObject gangCenter;

    private void Start() {
        AddNalchies(1);
    }

    void Update()
    {
        gangCenter.transform.position = transform.position + new Vector3(10f, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            AddNalchies(1);
        }
    }

    private void Jump() {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);       
        
        foreach (var nalchi in nalchiList) {
            nalchi.Jump(jumpForce);
            nalchi.GatherToCenter();
        }
    }

    private void AddNalchi() {
        var nalchiObj = NalchiPoolManager.INSTANCE.Pool.Get();
        nalchiList.Add(nalchiObj.GetComponent<Nalchi>());
        nalchiObj.transform.position = gangCenter.transform.position;
    }

    public void AddNalchies(int count) {
        nalchiCount += count;
        for (int i = 0; i < count; i++) {
            AddNalchi();
        }

        foreach (var nalchi in nalchiList) {
            nalchi.GatherToCenter();
        }
    }
}
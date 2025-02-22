using UnityEngine;
using UnityEngine.Pool;

public class Nalchi : MonoBehaviour {
    
    public IObjectPool<GameObject> Pool { get; set; }
    
    [SerializeField] private GameObject gangCenter;
    [SerializeField] private Rigidbody2D rb;
    
    private void Awake() {
        gangCenter = gameObject.transform.parent.gameObject;
    }

    private void OnEnable() {
        SetRandomPositionOnEnable();
    }

    public void GatherToCenter() {
        var dir = -transform.localPosition;
        rb.AddForce(dir, ForceMode2D.Impulse);
    }

    private void SetRandomPositionOnEnable() {
        var randVec = Random.insideUnitCircle;
        rb.AddForce(randVec);
    }

    public void Jump(float jumpForce) {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);     
    }
}

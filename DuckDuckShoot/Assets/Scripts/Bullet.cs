using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 20f;
    private Rigidbody2D _rigidbody;
    private Vector3 _mousePos;
    
    // public GameObject impactEffect;

    // Use this for initialization
    void Start ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _mousePos =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = _mousePos - transform.position;
        Vector3 rotation = transform.position - _mousePos;
        _rigidbody.velocity = new Vector2(direction.x, direction.y).normalized * speed;
        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

    }
    
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("BulletCollider"))
        {
            Destroy(gameObject);
        }
        
        else if (hitInfo.gameObject.CompareTag("Duck"))
        {
            Destroy(hitInfo.gameObject);
            Destroy(gameObject);
        }
        
    }
	
}
using UnityEngine;

public class Duck : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("DuckCollider"))
        {
            Destroy(gameObject);
        }
        
    }
}

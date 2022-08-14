using UnityEngine;

public class PathFollower : MonoBehaviour {
    public GameObject[] target;  
    public float speed;  
    private int _current;  
    void Update() {  
        if (transform.position != target[_current].transform.position) {  
            Vector3 pos = Vector3.MoveTowards(transform.position, target[_current].transform.position, speed * Time.deltaTime);  
            GetComponent < Rigidbody2D > ().MovePosition(pos);  
        } else _current = (_current + 1) % target.Length;  
    }  
}

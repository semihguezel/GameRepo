using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject duckLeft;
    public GameObject duckRight;
    public GameObject startPosLeft;
    public GameObject startPosRight;
    public float spawnTime;
    public float spawnTimeRandom;
    //Private Variables
    private float _spawnTimer;
    
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start () 
    {
        ResetSpawnTimer();
    }
    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0.0f)
        {
            Instantiate(duckLeft, startPosLeft.transform.position, Quaternion.identity);
            Instantiate(duckRight, startPosRight.transform.position, new Quaternion(0, 180, 0, 0));
            ResetSpawnTimer();
        }
    }
    
    void ResetSpawnTimer()
    {
        _spawnTimer = (float)(spawnTime + Random.Range(0, spawnTimeRandom*100)/100.0);
    }

}

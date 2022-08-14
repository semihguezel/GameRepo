using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyPathing0 : MonoBehaviour
{    
    //configuration parameters
    WaveConfig waveConfig;
    List<Transform> waypoints;
    private int _waypointIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[_waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MovementEnemy();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void MovementEnemy()
    {
        if (_waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[_waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetEnemySpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if(transform.position.x == targetPosition.x)
            {
                _waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    } 
}

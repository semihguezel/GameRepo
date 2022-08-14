using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave config")]
public class WaveConfig : ScriptableObject
{
    //configuration parameters
    [SerializeField] private GameObject EnemyPrefabs;
    [SerializeField] private GameObject PathPrefabs;
    [SerializeField] private float timeBetweenSpawns = 0.5f;
    [SerializeField] private float SpawnRandomFactor = 0.3f;
    [SerializeField] private int numberOfEnemies = 5;
    [SerializeField] private float enemySpeed = 2f;

    public GameObject GetEnemyPrefabs()
    {
        return EnemyPrefabs;
    }

    public List<Transform>  GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();
        
        foreach (Transform child in PathPrefabs.transform)
        {
            waveWaypoints.Add(child);
        }
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return SpawnRandomFactor;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    
    public float GetEnemySpeed()
    {
        return enemySpeed;
    }

}

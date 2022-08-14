using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //config params
    [SerializeField] private List<WaveConfig> waveConfigs; // store wave configs as a list

    private int _startingWave = 0;
    [SerializeField] private bool looping = false;
   
    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllEnemies());
            
        } while (looping);


    }

    private IEnumerator SpawnAllEnemies()
    {
        for (int waveIndex = _startingWave; waveIndex< waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
           var newEnemy =Instantiate(waveConfig.GetEnemyPrefabs(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
           newEnemy.GetComponent<EnemyPathing0>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    WaveConfigSO currentWave;
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
        Debug.Log(waveConfigs);
    }

    IEnumerator SpawnEnemyWaves() {
        do {
            foreach (WaveConfigSO wave in waveConfigs) {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++) {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        }
        while (isLooping);
        
    }

    public WaveConfigSO GetCurrentWave() {
        return currentWave;
    }
}

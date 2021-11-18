using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float tableHeight;
    private float enemyHeight;
    private float spawnSections;
    [SerializeField] GameObject[] enemyPrefab;
    [SerializeField] GameObject enemyWavePrefab;

    float spawnTime = 5.0f;
    float spawnRate = 3f;
    [SerializeField] float spaceBetween = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        tableHeight = GetComponent<Collider>().bounds.size.y;
        enemyHeight = enemyPrefab[0].GetComponent<CapsuleCollider>().height * enemyPrefab[0].GetComponent<Transform>().localScale.y;
        spawnSections = tableHeight / (enemyHeight * 2);

        InvokeRepeating("SpawnNormalEnemy", spawnTime, spawnRate);
        InvokeRepeating("SpawnWaveEnemy", 7, 15);
    }

    private Vector3 SetInSpace()
    {
        float spawnPosition = Random.Range( -spawnSections, spawnSections);
        Vector3 spawnPos = new Vector3(transform.position.x, spawnPosition, transform.position.z);
        return spawnPos;
    }

    private void SpawnNormalEnemy()
    {
        int enemyToSpawn = Random.Range(0, enemyPrefab.Length);
        Instantiate(enemyPrefab[enemyToSpawn], SetInSpace(), enemyPrefab[0].transform.rotation);
    }

    private void SpawnWaveEnemy()
    {
        StartCoroutine(WaveSpacer(SetInSpace()));
    }

    public void StopSpawning() => CancelInvoke();

    IEnumerator WaveSpacer(Vector3 spawnPos)
    {
        int count = 0;
        while (count < 4)
        {
            GameObject temp = enemyWavePrefab;
            Instantiate(temp, spawnPos, enemyWavePrefab.transform.rotation);
            count++;
            yield return new WaitForSeconds(spaceBetween);
        }
        GameObject.Find("Game Manager").GetComponent<WaveObserver>().HasWaveEnemiesSpawn = true;
    }
}

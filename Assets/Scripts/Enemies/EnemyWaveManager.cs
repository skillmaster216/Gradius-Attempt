using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    [SerializeField] float distanceBetween = 0.2f;
    [SerializeField] List<GameObject> wave = new List<GameObject>();
    List<GameObject> enemies = new List<GameObject>();

    float countUp = 0;

    void Start()
    {
        SpawnEnemy();
    }

    private void FixedUpdate()
    {
        if (wave.Count > 0)
        {
            SpawnEnemy();
        }
        FollowMovement();
    }

    public void SpawnEnemy()
    {
        if (enemies.Count == 0)
        {
            GameObject leader = Instantiate(wave[0], transform.position, transform.rotation, transform);
            if (!leader.GetComponent<WaveEnemy>())
                leader.AddComponent<WaveEnemy>();
            CheckComponents(leader);
            enemies.Add(leader);
            wave.RemoveAt(0);
        }
        Tracker trackT = enemies[enemies.Count - 1].GetComponent<Tracker>();
        if (countUp == 0)
            trackT.ClearTrackerList();
        countUp += Time.deltaTime;
        if (countUp >= distanceBetween)
        {
            GameObject temp = Instantiate(wave[0], trackT.trackList[0].pos, trackT.trackList[0].rot, transform);
            CheckComponents(temp);
            enemies.Add(temp);
            wave.RemoveAt(0);
            temp.GetComponent<Tracker>().ClearTrackerList();
            countUp = 0;
        }
    }
    

    private void CheckComponents(GameObject enemy)
    {
        if (!enemy.GetComponent<Tracker>())
            enemy.AddComponent<Tracker>();
        if (!enemy.GetComponent<Rigidbody>())
        {
            enemy.AddComponent<Rigidbody>();
            enemy.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    private void FollowMovement()
    {
        if(enemies.Count > 1)
        {
            for( int i = 1; i < enemies.Count; i++)
            {
                Tracker trakT = wave[i - 1].GetComponent<Tracker>();
                wave[i].transform.position = trakT.trackList[0].pos;
                wave[i].transform.rotation = trakT.trackList[0].rot;
                trakT.trackList.RemoveAt(0);
            }
        }
    }
}

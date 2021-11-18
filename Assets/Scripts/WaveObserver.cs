using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObserver : MonoBehaviour
{
    [SerializeField]
    private GameObject powerUp;
    private bool _hasWaveEnemiesSpawn = false;
    public bool HasWaveEnemiesSpawn { 
        get { return _hasWaveEnemiesSpawn; }
        set { _hasWaveEnemiesSpawn = value;  }
    }

    private Vector3 lastPos;


    // Update is called once per frame
    void LateUpdate()
    {
        if (_hasWaveEnemiesSpawn && CountEnemies() == 1)
            lastPos = GameObject.FindWithTag("Enemy_Wave").transform.position;
        else if( _hasWaveEnemiesSpawn && CountEnemies() == 0)
        {
            Instantiate(powerUp, lastPos, powerUp.transform.rotation);
            _hasWaveEnemiesSpawn = false;
        }
            

    }


    private int CountEnemies()
    {
        GameObject[] Current = GameObject.FindGameObjectsWithTag("Enemy_Wave");
        return Current.Length;
    }
}

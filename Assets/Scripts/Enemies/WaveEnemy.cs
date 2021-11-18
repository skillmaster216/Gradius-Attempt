using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemy : Enemy
{

    [SerializeField]
    private float frequency = 5;
    [SerializeField]
    private float magnitude = 1;

    Vector3 pos;
    private void Start()
    {
        speed = 10;
        _points = 3;
        pos = transform.position;
    }

    public override int points
    {
        get
        {
            return _points;
        }
    }

    public override void Movement()
    {
        pos -= (transform.up * Time.deltaTime * speed);
        transform.position = pos + (transform.right * Mathf.Sin(Time.time * frequency) * magnitude);
    }

    private void Update()
    {
        Movement();
    }

}

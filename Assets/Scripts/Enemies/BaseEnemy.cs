using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemy : Enemy
{
    //INHERITANCE
    private void Start()
    {
        speed = 15;
        _points = 5;
    }

    public override int points {
        get 
        {
            return _points;
        }
    } 

    public override void Movement()
    {
        transform.Translate( Vector3.left * Time.deltaTime * speed, Space.World);
    }

    private void Update()
    {
        Movement();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected  float speed;
    protected int _points;   

    public abstract int points { get; }
    public abstract void Movement();

}

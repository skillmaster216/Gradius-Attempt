using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    //variables: movement to simulate, duration of the effect in seconds
    [SerializeField]protected float speed = 0;
    protected float duration;
    [SerializeField] protected float rotationSpeed;

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void Movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
    }
}

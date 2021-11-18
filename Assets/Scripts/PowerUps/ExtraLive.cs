using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLive : PowerUp
{
    private GameManager gameManager;
    private void Start()
    {
        rotationSpeed = 0.5f;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void Update()
    {
        Movement();
        transform.Rotate(Vector3.up * rotationSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.CompareTo("Player") == 0)
        {
            gameManager.UpdateLives(+1);
            Destroy(gameObject);
        }
    }
}

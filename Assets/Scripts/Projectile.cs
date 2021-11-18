using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float speed = 55.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Contains("Enemy"))
        {
            int points;
            points = other.gameObject.GetComponent < Enemy > ().points;
            GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateScore(points);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}

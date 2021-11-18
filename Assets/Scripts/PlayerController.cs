using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private readonly float speed = 20.0f;
    [SerializeField] private GameObject projectilePrefab;
    private float fireRate = 0.6f;
    private bool _fireRateCd = false;
    private float horizontalInput;
    private float verticalInput;

    //bounds
    private readonly float yBound = 10;
    private readonly float xBound = 22;

    // Start position
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }


    private void LateUpdate()
    {
        if (!GameObject.Find("Game Manager").GetComponent<GameManager>().isGameOver) 
        {

            //Player Movement
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right, Space.World);
            transform.Translate(verticalInput * speed * Time.deltaTime * Vector3.up, Space.World);

            //Player shoot
            if (Input.GetKey(KeyCode.Space))
            {
                //Debug.Log("Pew Pew.");
                if (!_fireRateCd) StartCoroutine(Shooting());
            }

            //keep inbound approach 1
            Vector3 viewpos = transform.position;
            viewpos.x = Mathf.Clamp(viewpos.x, -xBound, xBound);
            viewpos.y = Mathf.Clamp(viewpos.y, -yBound, yBound);
            transform.position = viewpos;

        }
    }

    IEnumerator Shooting()
    {
        _fireRateCd = true;
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        yield return new WaitForSeconds(fireRate);
        _fireRateCd = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Enemy"))
        {
            GameObject.Find("Game Manager").GetComponent<GameManager>().UpdateLives(-1);
            Destroy(other.gameObject);
            ResetPosition();
            StartCoroutine("InvulnerabilityTime");
        }
    }

    private void ResetPosition()
    {
        transform.position = startPosition;

    }

    IEnumerator InvulnerabilityTime()
    {
        gameObject.GetComponent<CapsuleCollider>().isTrigger = false;
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<CapsuleCollider>().isTrigger = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float asteroidSpeed = 5f;
    public float rotationSpeed = 10f;
    void Start()
    {
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);
        float randomZ = Random.Range(0f, 1f);
  
        rb = GetComponent<Rigidbody>();
        rb.angularDrag = 0f;
        rb.angularVelocity = new Vector3(randomX, randomY, randomZ);
    }

    void Update()
    {
        rb.MovePosition(transform.position + Vector3.forward * -asteroidSpeed * Time.fixedDeltaTime);

    }
}

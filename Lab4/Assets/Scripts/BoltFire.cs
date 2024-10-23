using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltController : MonoBehaviour
{
    public float boltSpeed = 10f;
    void Update()
    {
        transform.Translate(Vector3.forward * boltSpeed * Time.deltaTime); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

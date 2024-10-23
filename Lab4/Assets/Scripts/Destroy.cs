using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bolt"))
        {
            Destroy(other.gameObject);
        }else if(other.CompareTag("Plant"))
        {
            Destroy(other.gameObject);//!! Components should be hung on the object's parent object
        }
    }
}

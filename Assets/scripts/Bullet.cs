using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10;
    public float lifetime = 3f; // Destroy bullet after 3 seconds

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
       
        

        // Optional: Destroy if hitting walls
        if (hitInfo.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
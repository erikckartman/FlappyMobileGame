using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private Rigidbody rb;

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Metheor"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
            GameScore.score += 15;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameScore.score += 50;
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(5f, 0f, 0f);
    }
}

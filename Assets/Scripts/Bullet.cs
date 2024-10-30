using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Patron : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private GameObject blowup;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket"))
        {
            GameScore.score += 50;
            Destroy(other.gameObject);
            Instantiate(blowup, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Metheor"))
        {
            GameScore.score += 15;
            Destroy(other.gameObject);
            Instantiate(blowup, other.gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(5f, 0f, 0f);
        Destroy(gameObject, 5f);
    }
}

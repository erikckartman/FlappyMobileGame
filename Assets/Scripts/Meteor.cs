using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
public class Meteor : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private Transform player;

    [SerializeField] private GameObject rocket;
    private Vector3 spawnRocket;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.velocity = new Vector3(-10f, 0f, 0f);
        InvokeRepeating("Rockets", 0f, 1f);
        Destroy(gameObject, 3f);
    }

    private void Rockets()
    {
        if(transform.position.x > player.position.x)
        {
            GameObject rocketClone = Instantiate(rocket, transform.position, Quaternion.identity);

            rocketClone.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            Vector3 direction = (player.position - rocketClone.transform.position).normalized;

            rocketClone.GetComponent<Rigidbody>().velocity = direction * 3f;

            Quaternion rotation = Quaternion.LookRotation(direction);
            rocketClone.transform.rotation = rotation * Quaternion.Euler(90f, 0f, 0f);

            Destroy(rocketClone, 5f);
        }
    }
}

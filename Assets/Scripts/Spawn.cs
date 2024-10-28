using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject meteor;
    private Vector3 spawnMeteor;
    private float meteorX;
    private float meteorY;

    [SerializeField] private GameObject rocket;
    private Vector3 spawnRocket;
    private float rocketX;
    private float rocketY;

    [SerializeField] private Transform player;

    private void Start()
    {
        InvokeRepeating("Spawning", 0f, 3f);
        InvokeRepeating("Rockets", 0f, 2f);
    }

    private void Spawning()
    {
        meteorY = Random.Range(-4f, 4f);
        
        spawnMeteor = new Vector3(12f, meteorY, 0f);

        GameObject meteorClone = Instantiate(meteor, spawnMeteor, Quaternion.identity);
    }

    private void Rockets()
    {
        rocketX = Random.Range(-9f, 9f);
        rocketY = Random.Range(-5f, 5f);

        spawnRocket = new Vector3(rocketX, rocketY, player.position.z + 50f);
        GameObject rocketClone = Instantiate(rocket, spawnRocket, Quaternion.identity);

        Vector3 direction = (player.position - rocketClone.transform.position).normalized;

        rocketClone.GetComponent<Rigidbody>().velocity = direction * 15f;

        Quaternion rotation = Quaternion.LookRotation(direction);
        rocketClone.transform.rotation = rotation * Quaternion.Euler(90f, 0f, 0f);

        Destroy(rocketClone, 5f);
    }

    private IEnumerator SpawnPlanes()
    {
        while (true)
        {
            Spawning();
            yield return new WaitForSeconds(3f);
        }
    }
    private IEnumerator SpawnRockets()
    {
        while (true)
        {
            Rockets();
            yield return new WaitForSeconds(2f);
        }
    }
}

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

    public Renderer spriteRenderer;

    private void Start()
    {
        InvokeRepeating("Spawning", 0f, 3f);
        InvokeRepeating("Rockets", 0f, 3f);
    }

    private void Update()
    {
        float offset = Time.time * 0.1f;
        spriteRenderer.material.mainTextureOffset = new Vector2(offset, 0);
    }

    private void Spawning()
    {
        meteorY = Random.Range(-4f, 4f);
        
        spawnMeteor = new Vector3(12f, meteorY, 0f);

        GameObject meteorClone = Instantiate(meteor, spawnMeteor, Quaternion.Euler(-120f, 0f, 90f));
    }

    private void Rockets()
    {
        rocketX = Random.Range(-10f, 10f);
        rocketY = Random.Range(-10f, 10f);

        spawnRocket = new Vector3(player.position.x + rocketX, player.position.x + rocketY, player.position.z + 50f);
        GameObject rocketClone = Instantiate(rocket, spawnRocket, Quaternion.identity);

        Vector3 direction = (player.position - rocketClone.transform.position).normalized;

        rocketClone.GetComponent<Rigidbody>().velocity = direction * 15f;
        float rockz = Random.Range(1f, 360f);
        Quaternion rotation = Quaternion.LookRotation(direction);
        rocketClone.transform.rotation = rotation * Quaternion.Euler(180f, 180f, rockz);

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

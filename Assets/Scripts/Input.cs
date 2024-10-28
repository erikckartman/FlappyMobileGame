using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInput : MonoBehaviour
{
    [SerializeField] private Controls joystick;
    private float speed = 2f;
    [SerializeField] private Transform shoot;
    [SerializeField] private GameObject bullet;
    private bool canShoot = true;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Metheor"))
        {
            Destroy(collider.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocket")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float horizontal = joystick.Horizontal();
        float vertical = joystick.Vertical();
        float airFactor = 0f;

        if(horizontal == 0)
        {
            airFactor = 0;
        }
        else
        {
            airFactor = -0.5f;
        }

        rb.velocity= new Vector3(horizontal * speed + airFactor, vertical * speed, 0f);
        
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(bullet, shoot.transform.position, Quaternion.Euler(0f, 0f, 90f));
            StartCoroutine(WaitForShoot());
        }
    }

    private IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}

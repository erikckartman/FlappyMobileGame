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

        Vector3 direction = new Vector3(horizontal, vertical, 0f);
        transform.position += direction * speed * Time.deltaTime;
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

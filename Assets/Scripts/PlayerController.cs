using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float minMovementSpeed = 1f;
    [SerializeField] private float movementSpeed = 0.4f;
    [SerializeField] private float turnSpeed = 50f;
    [SerializeField] private AudioSource boostSound;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;
    [SerializeField] private GameObject bulletSpawn2;
    [SerializeField] private bool hasShooted;

    private void Update()
    {
        Turn();
        Thrust();
        Shoot();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        transform.Rotate(-pitch, yaw, roll);
    }

    void Thrust()
    {
        if (Input.GetButton("Thrust"))
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime ;
            boostSound.volume = 0.3f;
        }
        else
        {
            boostSound.volume = 0.1f;
        }
        transform.position += transform.forward * minMovementSpeed * Time.deltaTime;
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Shoot") && !hasShooted)
        {
            Vector3 bulletDir = (bulletSpawn2.transform.position - bulletSpawn.transform.position).normalized;
            Instantiate(bullet, bulletSpawn.transform.position, Quaternion.LookRotation(bulletDir, Vector3.up));
            hasShooted = true;
            StartCoroutine(RestartShoot());
        }
    }

    private IEnumerator RestartShoot()
    {
        yield return new WaitForSeconds(0.3f);
        hasShooted = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float minMovementSpeed = 1f;
    public float movementSpeed = 0.4f;
    public float turnSpeed = 50f;
    public AudioSource boostSound;

    private void Update()
    {
        Turn();
        Thrust();
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");

        transform.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            boostSound.volume = 0.3f;
        }
        else
        {
            boostSound.volume = 0.1f;
        }
        transform.position += transform.forward * minMovementSpeed * Time.deltaTime;
    }
}

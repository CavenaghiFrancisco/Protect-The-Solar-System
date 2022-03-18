using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;

    public float maxSpeed = 2f;
    public float minSpeed = 0.1f;

    public float lookRateSpeed = 90f;
    private Vector2 lookInput, screenCenter, mouseDistance;

    public GameObject trail;
    public GameObject trail2;

    float smooth = 5.0f;

    private float rollInput;
    public float rollSpeed = 90f, rollAcceleration = 3.5f;

    void Start()
    {
        screenCenter.x = Screen.width * 0.5f;
        screenCenter.y = Screen.height * 0.5f;
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;

        lookInput.x = Input.mousePosition.x;
        lookInput.y = Input.mousePosition.y;

        mouseDistance.x = (lookInput.x - screenCenter.x) / screenCenter.y;
        mouseDistance.y = (lookInput.y - screenCenter.y) / screenCenter.y;

        mouseDistance = Vector2.ClampMagnitude(mouseDistance, 1f);

        rollInput = Mathf.Lerp(rollInput, Input.GetAxisRaw("Roll"), rollAcceleration * Time.deltaTime);

        transform.Rotate(mouseDistance.y * lookRateSpeed * Time.deltaTime * -1, mouseDistance.x * lookRateSpeed * Time.deltaTime, rollInput * rollSpeed * Time.deltaTime, Space.Self);


        if (Input.GetButton("Fire1"))
        {
            if (speed < maxSpeed)
            {
                trail.SetActive(true);
                speed += 0.1f * Time.deltaTime;
            }
        }
        else
        {
            if (speed > minSpeed)
            {
                speed -= 0.1f * Time.deltaTime;
            }
        }
    }
}

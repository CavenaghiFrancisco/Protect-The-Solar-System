using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, speed * Time.deltaTime);
    }
}

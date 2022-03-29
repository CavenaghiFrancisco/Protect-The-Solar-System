using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTraslation : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float traslationSpeed;

    void Update()
    {
        transform.RotateAround(target.transform.position, target.transform.up, traslationSpeed * Time.deltaTime);
    }
}

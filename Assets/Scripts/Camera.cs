using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float distanceDamp = 0.1f;

    public Vector3 velocity = Vector3.one;

    private void LateUpdate()
    {
        SmoothFollow();
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * offset);
        Vector3 curPos = Vector3.SmoothDamp(transform.position, toPos, ref velocity, distanceDamp);
        transform.position = curPos;

        transform.LookAt(target, target.up);
    }
}

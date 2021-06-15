using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    void FixedUpdate()
    {
        Vector3 targetPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpd);
        transform.position = smoothPos;

        transform.LookAt(target);
    }
}

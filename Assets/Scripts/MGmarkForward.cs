using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGmarkForward : MonoBehaviour
{
    public float moveSpd;

    void FixedUpdate()
    {
        gameObject.transform.Translate(Vector3.forward * moveSpd * Time.deltaTime);

    }
}

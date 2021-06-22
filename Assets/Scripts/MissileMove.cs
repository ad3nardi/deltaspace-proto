using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    public float mizSpd;
    public Transform mizTarget;

    private void FixedUpdate()
    {
        transform.Translate(transform.forward * mizSpd * Time.deltaTime);
        transform.LookAt(mizTarget);
        if(Vector3.Distance(mizTarget.position, transform.position) <= 0.5f)
        {
            Destroy(gameObject);
        }
    }
}

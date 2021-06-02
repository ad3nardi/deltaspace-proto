using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mgRound : MonoBehaviour
{
    public float lifetime;
    public float mgRoundSpd;
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * mgRoundSpd * Time.deltaTime);
    }
}

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
    void Update()
    {
        transform.Translate(transform.forward * mgRoundSpd * Time.deltaTime);
    }
}

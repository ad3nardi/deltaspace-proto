using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public enum ToggleType {bomber, striker, hunter}
    public ToggleType enemType;
    public GameObject hunterTarget;
    public GameObject weapon;
    public GameObject enemRnd;
    public GameObject bomb;
    public bool isHunting;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    private void Start()
    {
        if(enemType == ToggleType.hunter)
        hunterTarget = GameObject.Find("Player");
    }

    void Update()
    {

        Vector3 targetPos = hunterTarget.transform.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpd);
        transform.position = smoothPos;
        transform.Translate(smoothPos);

        transform.LookAt(hunterTarget.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
}

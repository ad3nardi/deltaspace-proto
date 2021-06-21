using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public enum ToggleType {bomber, striker, hunter}
    public ToggleType enemType;
    public GameObject hunterTarget;
    public float smoothSpd = 0.125f;
    public Vector3 offset;
    public float bomberSpd;
    public float strikerSpd;
    private void Start()
    {
        if(enemType == ToggleType.hunter)
        hunterTarget = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(enemType == ToggleType.bomber)
        {
            transform.Translate(transform.forward * bomberSpd);
        }
        if (enemType == ToggleType.striker)
        {
            transform.Translate(transform.forward * strikerSpd);
        }
        if (enemType == ToggleType.hunter)
        {
            Vector3 targetPos = hunterTarget.transform.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpd);
            transform.position = smoothPos;
            transform.LookAt(hunterTarget.transform);

            }
        }
    }



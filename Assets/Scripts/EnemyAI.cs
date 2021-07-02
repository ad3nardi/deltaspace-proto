using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    //Enemy type is set through a toggle menu in the inspector to be one of three types
    public enum ToggleType {bomber, striker, hunter}
    public ToggleType enemType;
    //The hunter target will be the player to gain access to the player's position
    public GameObject hunterTarget;
    public float smoothSpd = 0.125f;
    //The offset means the hunter will not be directly ontop of the player when follwoing
    public Vector3 offset;

    //Variable speeds of the enemy types adds personality and a dynamic to the enemies
    public float bomberSpd;
    public float strikerSpd;

    private void Start()
    {
        //keeping the hunter target null if not a hunter allows other enemy types to completely ignore the variable
        if(enemType == ToggleType.hunter)
        hunterTarget = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {
        if(enemType == ToggleType.bomber)
        {
            //For simplicty of having movement, the bomber moves forward multipled by its speed multiplier
            transform.Translate(transform.forward * bomberSpd);
        }
        if (enemType == ToggleType.striker)
        {
            //For simplicty of having movement, the striker moves forward multipled by its speed multiplier
            transform.Translate(transform.forward * strikerSpd);
        }
        if (enemType == ToggleType.hunter)
        {
            //The hunter's following pattern follows that similar to the camera, ensuring it alsways faces the player
            //       having an offset ensure the hunter is never directly on the player and can be adjusted in the inspector
            //       allowing constant adjustments to be made
            Vector3 targetPos = hunterTarget.transform.position + offset;
            Vector3 smoothPos = Vector3.Lerp(transform.position, targetPos, smoothSpd);
            transform.position = smoothPos;
            transform.LookAt(hunterTarget.transform);

            }
        }
    }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int gameScore;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Scpre Up");
            GameObject.Find("Score").GetComponent<Text>().text = (++gameScore).ToString();
        }
    }
}

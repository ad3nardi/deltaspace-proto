using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUp();
            StartCoroutine(DestorySegment());
        }
    }
    private IEnumerator DestorySegment()
    {
        yield return new WaitForSeconds(2);
        Destroy(transform.parent.gameObject);
    }
}

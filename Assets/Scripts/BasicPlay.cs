using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlay : MonoBehaviour
{
    public AudioSource aS;
    public void PlaySound()
    {
        aS.Play();
    }
    
}

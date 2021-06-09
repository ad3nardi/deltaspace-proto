using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP_UI : MonoBehaviour
{
    public Slider HPbar;
    public void SetMaxHealth(int health)
    {
        HPbar.maxValue = health;
        HPbar.value = health;
    }
    public void SetHealth(int health)
    {
        HPbar.value = health;
    }
}

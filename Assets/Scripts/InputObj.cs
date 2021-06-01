using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputObj : MonoBehaviour
{
    public Inputs control;
    void Init(Inputs c)
    {
        control = c;
    }
    public virtual void GetInputs(InputList inputs) { }
    public virtual void Tick(InputList inputs, float delta) { }
    public virtual void FixedTick(float delta) { }
}

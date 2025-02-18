using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{

    public bool isComplete { get; protected set; }

    protected float startTime;

    float time => Time.time - startTime;
   public virtual void Enter() { }
   

    public virtual void Do() { }

    public virtual void FixedDo() { }

    public virtual void Exit() { }


}

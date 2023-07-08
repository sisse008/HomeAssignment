using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command 
{
    protected float actionTime;

    public Command(float actionTime)
    {
        this.actionTime = actionTime;
    }
    public virtual IEnumerator Execute(Robot r)
    {
        yield return null;
    }
    
}

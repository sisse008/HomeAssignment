using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ScriptableObject
{
    protected float actionTime;

    public void DestroyCommand()
    {
        Destroy(this);
    }
    public virtual IEnumerator Execute(Robot r)
    {
        yield return null;
    }
    
}

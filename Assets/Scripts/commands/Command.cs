using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum CommandType
{
    COLOR,
    ROTATE,
    MOVE
}

[System.Serializable]
public abstract class Command : ScriptableObject
{
    [SerializeField]protected float actionTime;
    public CommandType type { get; protected set; }

    public bool permitDestroy = true;


    public void OnSavedAsAsset()
    {
        permitDestroy = false;
    }

    public virtual Command Copy()
    {
        return ScriptableObject.CreateInstance<Command>();
    }

    public void DestroyCommand()
    {
        if(permitDestroy)
            Destroy(this);
    }
    public virtual IEnumerator Execute(Robot r)
    {
        yield return null;
    }
    
}

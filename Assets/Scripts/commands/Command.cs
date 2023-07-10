using System;
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

    public Action OnSavedAsAsset;

    private void OnEnable()
    {
        OnSavedAsAsset += () => isAsset = true;
    }
    private void OnDisable()
    {
        OnSavedAsAsset -= () => isAsset = true;
    }


    [HideInInspector]public bool isAsset = false;


    public virtual Command Copy()
    {
        return ScriptableObject.CreateInstance<Command>();
    }

    public void DestroyCommand()
    {
        if(!isAsset)
            Destroy(this);
    }
    public virtual IEnumerator Execute(Robot r)
    {
        yield return null;
    }
    
}

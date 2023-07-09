using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RotateCommand : Command
{
    [SerializeField] Quaternion newRotation;

    void Init(Quaternion newRotation) 
    {
        this.newRotation = newRotation;
    }

    public override Command Copy()
    {
        return New(newRotation, actionTime);
    }

    public static RotateCommand New(Quaternion newRotation, float actionTime)
    {
        RotateCommand instance = ScriptableObject.CreateInstance<RotateCommand>();
        instance.Init(newRotation);
        instance.actionTime = actionTime;
        instance.type = CommandType.ROTATE;
        return instance;
    }

    public override IEnumerator Execute(Robot r)
    {
        float time = 0;
        Quaternion currentRot = r.transform.rotation;
        if(currentRot == newRotation)
            yield break;
        while (time < actionTime)
        {
            time += Time.deltaTime ;
            r.transform.rotation = Quaternion.Lerp(currentRot, newRotation, time/actionTime);
            yield return null;
        }
    }
}

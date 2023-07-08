using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateCommand : Command
{
    Quaternion newRotation;

    public RotateCommand(Quaternion newRotation, float actionTime) :base(actionTime)
    {
        this.newRotation = newRotation;
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

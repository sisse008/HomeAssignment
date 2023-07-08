using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    Vector3 delta;

    public MoveCommand(Vector3 delta, float actionTime) :base(actionTime)
    {
        this.delta = delta;
    }

    Vector3 destination;
    public override IEnumerator Execute(Robot r)
    {
        float time = 0;
        Vector3 currentPosition = r.transform.position;
        destination = currentPosition + delta;
        if(currentPosition == destination)
            yield break;
        while (time < actionTime)
        {
            //Debug.Log("move: " + time);
            time += Time.deltaTime;
            r.transform.position = Vector3.Lerp(currentPosition, destination, time/actionTime);
            yield return null;
        }
    }
}

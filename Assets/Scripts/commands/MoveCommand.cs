using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MoveCommand : Command
{
    [SerializeField]Vector3 delta;

    void Init (Vector3 delta) 
    {
        this.delta = delta;
    }

    public override Command Copy()
    {
         return New(delta, actionTime);
    }

    public static MoveCommand New(Vector3 delta, float actionTime)
    {
        MoveCommand instance = ScriptableObject.CreateInstance<MoveCommand>();
        instance.Init(delta);
        instance.actionTime = actionTime;
        instance.type = CommandType.MOVE;
        return instance;
    }

    public override IEnumerator Execute(Robot r)
    {
        float time = 0;
        Vector3 currentPosition = r.transform.position;
        Vector3 destination = currentPosition + delta;
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

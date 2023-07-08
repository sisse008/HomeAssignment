using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class Instruction
{
    public KeyCode key;
    public Command[] commands;

    public IEnumerator ExecuteCommands(Robot r)
    {
        foreach (Command c in commands)
            yield return c.Execute(r);       
    }

}

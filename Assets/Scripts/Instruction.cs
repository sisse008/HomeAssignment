using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Instruction 
{
    public List<Command> commands { get; private set; }

    public static int MaxCommands => 20;
    public static bool inExecution { get; private set; }
    public static Robot currentRobot { get; private set; }

    public Instruction(List<Command> commands)
    {
        this.commands = commands;
    }

    public bool AddCommand(Command command)
    {
        if(commands.Count >= MaxCommands)
            return false;
        commands.Add(command);
        return true;
    }
    public void ExecuteInstruction(Robot r)
    {
        r.StartCoroutine(Execute(r));
    }
    IEnumerator Execute(Robot r)
    {
        currentRobot = r;
        inExecution = true;
        foreach (Command _command in commands)
            yield return _command.Execute(r);
        inExecution = false;
        currentRobot = null;
    }
}

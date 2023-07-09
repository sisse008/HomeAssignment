using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Instruction : ScriptableObject
{
    [SerializeField] List<Command> commands;

    public List<Command> Commands => commands.ToList();

    public static int MaxCommands => 20;
    public static bool inExecution { get; private set; }
    public static Robot currentRobot { get; private set; }

    bool permitDestroy = true;

    public void OnSavedAsAsset()
    {
        permitDestroy = false;
    }

    public void Init(List<Command> commands)
    {
        this.commands = commands;
    }

    public static Instruction New(List<Command> commands)
    {
        Instruction instance = ScriptableObject.CreateInstance<Instruction>();
        instance.Init(commands);
        return instance;
    }

    public Instruction Copy()
    {
        List<Command> _commands = new List<Command>();
        foreach (Command c in Commands)
            _commands.Add(c.Copy());
        
        return New(_commands);
    }
   

    public void DestroyInstruction()
    {
        if (permitDestroy == false)
            return;

        foreach (Command _command in commands)
            _command.DestroyCommand();

        Destroy(this);
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

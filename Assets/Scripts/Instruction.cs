using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEditor;

public class Instruction : ScriptableObject
{
    [SerializeField] List<Command> commands;
    public List<string> commandAssetsGuids;

    public List<Command> Commands => commands.ToList();

    public static int MaxCommands => 20;
    public static bool inExecution { get; private set; }
    public static Robot currentRobot { get; private set; }

    public Action OnSavedAsAsset;

    private void OnEnable()
    {
        OnSavedAsAsset += () => isAsset = true;
    }
    private void OnDisable()
    {
        OnSavedAsAsset -= () => isAsset = true;
    }

    [SerializeField][HideInInspector]bool isAsset; 
    public bool IsAsset => isAsset;

    public void Init(List<Command> commands)
    {
        this.commands = commands;
    }

    public bool FixUnityRefrencingBug() //unity has a bug where it does not serealize and desealize correctly fields in a SO that where set at runtime (and not manually)
    {
        isAsset = true;
        if (commandAssetsGuids.Count != commands.Count)
            return false;
        for (int i = 0; i < commands.Count; i++)
        {
            if (commands[i] != null)
                continue;
            string assetPath = AssetDatabase.GUIDToAssetPath(commandAssetsGuids[i]);
            if (string.IsNullOrEmpty(assetPath))
                return false;
            commands[i] = AssetDatabase.LoadAssetAtPath<Command>(assetPath);
            commands[i].isAsset = true;
        }
        return true;
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
        if (isAsset)
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

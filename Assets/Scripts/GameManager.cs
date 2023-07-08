using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] List<Robot> robots;
    [SerializeField] TextHelper textHelper;
    [SerializeField] InstructionSelection instructionSelection;


    List<Instruction> instructions = new List<Instruction>();

   

    private void OnEnable()
    {
        instructionSelection.OnInstructionButtonRemoved += DeleteInstruction;

        foreach (Robot r in robots)
            r.OnRobotSelected += OnRobotSelected;
    }

    private void OnDisable()
    {
        instructionSelection.OnInstructionButtonRemoved -= DeleteInstruction;

        foreach (Robot r in robots)
            r.OnRobotSelected -= OnRobotSelected;
    }

    
    void OnRobotSelected(Robot r)
    {
        ExecuteInstructionOnRobot(instructionSelection.SelectedInstruction, r);
    }

    public void AddInstruction(Instruction instruction)
    {
        instructions.Add(instruction);
        instructionSelection.AddButton(instruction, "instruction" + instructions.Count.ToString());  
    }

    public void DeleteInstruction(Instruction instruction)
    {
        if(instructions.Contains(instruction))
            instructions.Remove(instruction);
    }

    void ExecuteInstructionOnRobot(Instruction instruction, Robot r)
    {
        if (Instruction.inExecution && Instruction.currentRobot == r)
        {
            textHelper.ShowWaitText();
            return;
        }
        instruction.ExecuteInstruction(r);
    }

}

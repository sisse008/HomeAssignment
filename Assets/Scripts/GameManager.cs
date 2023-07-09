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

    const int MaxNumOfInstructions = 10;
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


    private void OnDestroy()
    {
        foreach (Instruction _instruction in instructions)
        {
            _instruction.DestroyInstruction();
        }
    }

    void OnRobotSelected(Robot r)
    {
        ExecuteInstructionOnRobot(instructionSelection.SelectedInstruction, r);
    }

    public bool AddInstruction(Instruction instruction)
    {
        if(instructions.Count >= MaxNumOfInstructions)
            return false;

        instructions.Add(instruction);
        instructionSelection.AddButton(instruction, "instruction" + instructions.Count.ToString());

        textHelper.SelectRobotText();
        return true;
    }

    public void DeleteInstruction(Instruction instruction)
    {
        if(instructions.Contains(instruction))
            instructions.Remove(instruction);

        instruction.DestroyInstruction();

        if (instructions.Count == 0)
            textHelper.CreateInstructionText();
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

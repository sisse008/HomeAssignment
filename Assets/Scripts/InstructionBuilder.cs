using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InstructionBuilder : MonoBehaviour
{

    [System.Serializable]
    public enum CommandType
    {
        COLOR,
        ROTATION,
        POSITION
    };


    [SerializeField] ColorPickerController colorPickerController;
    [SerializeField] RotationPickerController rotationPickerController;
    [SerializeField] PositionPickerController positionPickerController;
    [SerializeField] InstructionUIBar uiBar;

    Instruction newInstruction; 


    void CreateNewInstruction()
    {
        if (newInstruction == null)
            newInstruction = Instruction.New(new List<Command>());

        uiBar.gameObject.SetActive(true);
    }

    public void SaveNewInstruction()
    {
        GameManager.Instance.AddInstruction(Instruction.New(newInstruction.commands));
        DeleteNewInstruction();
    }

    public void DeleteNewInstruction()
    {
        newInstruction.DestroyInstruction();

        uiBar.ResetUI();
        uiBar.gameObject.SetActive(false);
    }

    public void AddColorCommand()
    {
        CreateNewInstruction();

        Command colorCommand = ColorCommand.New(colorPickerController.SelectedColor, colorPickerController.Length);
        bool success = newInstruction.AddCommand(colorCommand);

        if(success)
            uiBar.AddCommandUI(CommandType.COLOR);
    }

    public void AddRotationCommand()
    {
        CreateNewInstruction();

        Command rotationCommand = RotateCommand.New(rotationPickerController.SelectedQuaternion, rotationPickerController.Length);
        bool success = newInstruction.AddCommand(rotationCommand);

        if (success)
            uiBar.AddCommandUI(CommandType.ROTATION);
    }

    public void AddPositionCommand()
    {
        CreateNewInstruction();

        Command moveCommand = MoveCommand.New(positionPickerController.SelectedMovement, positionPickerController.Length);
        bool success = newInstruction.AddCommand(moveCommand);

        if (success)
            uiBar.AddCommandUI(CommandType.POSITION);
    }
}

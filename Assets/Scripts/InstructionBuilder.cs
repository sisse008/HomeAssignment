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

    private void Start()
    {
        newInstruction = null;
    }

    void CreateNewInstruction()
    {
        if (newInstruction == null)
            newInstruction = new Instruction(new List<Command>());

        uiBar.gameObject.SetActive(true);
    }

    public void SaveNewInstruction()
    {
        GameManager.Instance.AddInstruction(new Instruction(newInstruction.commands));
        DeleteNewInstruction();
    }

    public void DeleteNewInstruction()
    {
        newInstruction = null;

        uiBar.ResetUI();
        uiBar.gameObject.SetActive(false);
    }

    public void AddColorCommand()
    {
        CreateNewInstruction();

        Command colorCommand = new ColorCommand(colorPickerController.selectedColor, colorPickerController.Length);
        newInstruction.AddCommand(colorCommand);

        uiBar.AddCommandUI(CommandType.COLOR);
    }

    public void AddRotationCommand()
    {
        CreateNewInstruction();

        Command rotationCommand = new RotateCommand(rotationPickerController.SelectedQuaternion, rotationPickerController.Length);
        newInstruction.AddCommand(rotationCommand);

        uiBar.AddCommandUI(CommandType.ROTATION);
    }

    public void AddPositionCommand()
    {
        CreateNewInstruction();

        Command moveCommand = new MoveCommand(positionPickerController.SelectedMovement, positionPickerController.Length);
        newInstruction.AddCommand(moveCommand);

        uiBar.AddCommandUI(CommandType.POSITION);
    }
}

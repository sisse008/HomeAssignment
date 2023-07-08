using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionBuilder : MonoBehaviour
{
    public class Instruction
    {
        List<Command> commands;

        public Instruction(List<Command> commands)
        {
            this.commands = commands;
        }
        public void ExecuteInstruction(Robot r)
        {
            CoroutineRunner.RunCoroutine(Execute(r)); 
        }
        IEnumerator Execute(Robot r)
        {
            foreach(Command _command in commands)
                yield return _command.Execute(r);
        }
    }

    [SerializeField] TMPro.TMP_Text textHelper;
    [SerializeField] float commandExecutionTime = 2f;

    [SerializeField] ColorPickerController colorPickerController;
    [SerializeField] RotationPickerController rotationPickerController;
    [SerializeField] PositionPickerController positionPickerController;


    public void ExecuteInstructionOnRobot(Robot r)
    { 
        BuildInstruction().ExecuteInstruction(r);
    }

    Instruction BuildInstruction()
    {
        Command colorCommand = new ColorCommand(colorPickerController.selectedColor, commandExecutionTime);
        Command rotationCommand = new RotateCommand(rotationPickerController.SelectedQuaternion, commandExecutionTime);
        Command moveCommand = new MoveCommand(positionPickerController.SelectedMovement, commandExecutionTime);

        return new Instruction(new List<Command>() { colorCommand, rotationCommand, moveCommand });
    }
}

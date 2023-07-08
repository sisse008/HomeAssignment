using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionBuilder : MonoBehaviour
{
    public class Instruction
    {
        List<Command> commands;
        public static bool inExecution { get; private set; }
        public static Robot currentRobot { get; private set; }

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
            currentRobot = r;
            inExecution = true;
            foreach (Command _command in commands)
                yield return _command.Execute(r);
            inExecution = false;
            currentRobot = null;
        }
    }

    [SerializeField] TextHelper textHelper;

    [SerializeField] ColorPickerController colorPickerController;
    [SerializeField] RotationPickerController rotationPickerController;
    [SerializeField] PositionPickerController positionPickerController;


    public void ExecuteInstructionOnRobot(Robot r)
    {
        if (Instruction.inExecution && Instruction.currentRobot == r)
        {
            textHelper.ShowWaitText();
            return;
        }
        BuildInstruction().ExecuteInstruction(r);
    }

    Instruction BuildInstruction()
    {
        Command colorCommand = new ColorCommand(colorPickerController.selectedColor, colorPickerController.Length);
        Command rotationCommand = new RotateCommand(rotationPickerController.SelectedQuaternion, rotationPickerController.Length);
        Command moveCommand = new MoveCommand(positionPickerController.SelectedMovement, positionPickerController.Length);

        return new Instruction(new List<Command>() { colorCommand, rotationCommand, moveCommand });
    }
}

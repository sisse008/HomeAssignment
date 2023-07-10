using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class InstructionAssetSaver : MonoBehaviour
{
    [SerializeField] string path;
    public void SaveInstructionAsAsset(InstructionButton instructionButton)
    {
        if (instructionButton.instruction.isAsset)
        {
            Debug.LogWarning("This Instruction and it's commands are already saved as assets. Cannot resave. retreating.");
            return;
        }

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        AssetDatabase.Refresh();

        string instructionDataPath = Path.Combine(path , instructionButton.Name);

       
        if (Directory.Exists(instructionDataPath))
        {
            System.Random random = new System.Random();
            instructionDataPath += random.Next().ToString();

            Directory.CreateDirectory(instructionDataPath);
        }
        else
            Directory.CreateDirectory(instructionDataPath);


        string instructionAssetPath = Path.Combine(instructionDataPath, "instruction" + ".asset");
        AssetDatabase.CreateAsset(instructionButton.instruction, instructionAssetPath);

        instructionButton.instruction.OnSavedAsAsset?.Invoke();

        instructionButton.instruction.commandAssetsGuids = new List<string>();

        int num = 1;
        foreach (Command _command in instructionButton.instruction.Commands)
        {
            string type = _command.type == CommandType.COLOR ? "Color" : _command.type == CommandType.ROTATE ? "Rotate" : "Movement";
  
            string commandAssetPath = Path.Combine(instructionDataPath, type + " Command " + (num++).ToString() + ".asset");
            AssetDatabase.CreateAsset(_command, commandAssetPath);

            _command.OnSavedAsAsset?.Invoke();

            instructionButton.instruction.commandAssetsGuids.Add(AssetDatabase.AssetPathToGUID(commandAssetPath));
        }


        AssetDatabase.Refresh();
    }
}

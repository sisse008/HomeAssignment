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
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        AssetDatabase.Refresh();

        string instructionDataPath = Path.Combine(path , instructionButton.Name);

       
        if (Directory.Exists(instructionDataPath))
        {
            System.Random random = new System.Random();
            Directory.CreateDirectory(instructionDataPath+random.ToString());
        }
        else
            Directory.CreateDirectory(instructionDataPath);


        string instructionAssetPath = Path.Combine(instructionDataPath, "instruction" + ".asset");
        AssetDatabase.CreateAsset(instructionButton.instruction, instructionAssetPath);

        instructionButton.instruction.OnSavedAsAsset();

        int num = 1;
        foreach (Command _command in instructionButton.instruction.Commands)
        {
            string type = _command.type == CommandType.COLOR ? "Color" : _command.type == CommandType.ROTATE ? "Rotate" : "Movement";
  
            string commandAssetPath = Path.Combine(instructionDataPath, type + " Command " + (num++).ToString() + ".asset");
            AssetDatabase.CreateAsset(_command, commandAssetPath);

            _command.OnSavedAsAsset();
        }

        AssetDatabase.Refresh();
    }
}

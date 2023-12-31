using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAssetLoader : MonoBehaviour
{
    [SerializeField] List<Instruction> instructionAssets;

    private void Awake()
    {
        foreach (Instruction _instruction in instructionAssets)
            if (_instruction)
                _instruction.FixUnityRefrencingBug();
               
            
              
    }

    private void Start()
    {
        foreach(Instruction _instruction in instructionAssets)
            if(_instruction)
                GameManager.Instance.AddInstruction(_instruction, fromAsset: true);
    }
}

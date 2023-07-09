using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionAssetLoader : MonoBehaviour
{
    [SerializeField] List<Instruction> instructionAssets;

    private void Start()
    {
        foreach(Instruction _instruction in instructionAssets)
            GameManager.Instance.AddInstruction(_instruction, fromAsset: true);
    }
}

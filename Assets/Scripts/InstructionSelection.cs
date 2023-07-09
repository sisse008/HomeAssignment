using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class InstructionSelection : MonoBehaviour
{

    [SerializeField] InstructionButton t_instruction;

    public Action<Instruction> OnInstructionButtonRemoved;

    Instruction selectedInstruction;

    public Instruction SelectedInstruction
    {
        get 
        {
            if(selectedInstruction == null)
                selectedInstruction = Instruction.New(new List<Command>());

            return selectedInstruction;
        }
    }

    private void OnDestroy()
    {
        selectedInstruction.DestroyInstruction();
    }

    public InstructionButton AddButton(Instruction instruction, string name, bool allowSaveAndDeleteButtons)
    {
        InstructionButton b = Instantiate(t_instruction, transform);
        b.gameObject.SetActive(true);

        b.Init(()=> OnInstructionSelected(instruction), name, instruction, !allowSaveAndDeleteButtons);
       
        return b;
    }

    void OnInstructionSelected(Instruction instruction)
    {
        selectedInstruction = instruction;
    }
    public void RemoveInstructionButton(InstructionButton button)
    {
        OnInstructionButtonRemoved.Invoke(button.instruction);
        Destroy(button.gameObject);
    }
}

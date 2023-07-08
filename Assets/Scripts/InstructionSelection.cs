using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionSelection : MonoBehaviour
{

    [SerializeField] InstructionButton t_instruction;

    public Action<Instruction> OnInstructionButtonRemoved;

    Instruction selectedInstruction;
    public Instruction SelectedInstruction => selectedInstruction==null? new Instruction(new List<Command>()) : selectedInstruction;

    Dictionary<InstructionButton, Instruction> instructionButtons = new Dictionary<InstructionButton, Instruction>();

    public MyToggle AddButton(Instruction instruction, string name)
    {
        InstructionButton b = Instantiate(t_instruction, transform);
        b.gameObject.SetActive(true);
        b.toggle.OnClick.AddListener(() => OnInstructionSelected(instruction));
        TMPro.TMP_Text tMP_Text = b.toggle.GetComponentInChildren<TMPro.TMP_Text>();
        tMP_Text.text = name;
        instructionButtons[b] = instruction;
        //set new button as selected instruction
        MyToggle.OnSelected?.Invoke(b.toggle);
        return b.toggle;
    }

    void OnInstructionSelected(Instruction instruction)
    {
        selectedInstruction = instruction;
    }
    public void RemoveInstructionButton(InstructionButton button)
    {
        if (instructionButtons.ContainsKey(button))
        {
            OnInstructionButtonRemoved.Invoke(instructionButtons[button]);
            instructionButtons.Remove(button);
            Destroy(button.gameObject);
        }
    }
}

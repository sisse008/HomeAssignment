using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionSelection : MonoBehaviour
{

    [SerializeField] MyToggle t_instruction;

    Instruction selectedInstruction;
    public Instruction SelectedInstruction => selectedInstruction==null? new Instruction(new List<Command>()) : selectedInstruction;

    public MyToggle AddButton(Instruction instruction, string name)
    {
        MyToggle t = Instantiate(t_instruction, transform);
        t.gameObject.SetActive(true);
        t.OnClick.AddListener(() => OnInstructionSelected(instruction));
        TMPro.TMP_Text tMP_Text = t.GetComponentInChildren<TMPro.TMP_Text>();
        tMP_Text.text = name;
        return t;
    }

    void OnInstructionSelected(Instruction instruction)
    {
        selectedInstruction = instruction;
    }
}

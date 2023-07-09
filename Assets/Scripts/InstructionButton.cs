using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionButton : MonoBehaviour
{
    public MyToggle toggle;
    public TMP_Text text;
    [HideInInspector]public Instruction instruction;
    public string Name => text.text;
}

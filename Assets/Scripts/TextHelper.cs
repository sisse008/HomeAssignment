using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(TMPro.TMP_Text))]
public class TextHelper : MonoBehaviour
{
    TMPro.TMP_Text m_TextMeshPro;
    const string selectRobot = "Select Robot To Execute Instruction"; 
    const string wait = "Please Wait For Instruction To Finish";
    const string createInstruction = "Start Out By Creating a New Instruction";

    private void Awake()
    {
        m_TextMeshPro = GetComponent<TMPro.TMP_Text>();
    }


    private void Start()
    {
        CreateInstructionText();
    }

    public void CreateInstructionText()
    {
        m_TextMeshPro.text = createInstruction;
    }

    public void SelectRobotText()
    {
        m_TextMeshPro.text = selectRobot;
    }

    public void ShowWaitText()
    {
        StartCoroutine(RuntimeTools.DoForXSeconds(2, () => m_TextMeshPro.text = wait, ()=> m_TextMeshPro.text = selectRobot));
    }
}

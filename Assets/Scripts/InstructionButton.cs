using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;

public class InstructionButton : MonoBehaviour
{
    [SerializeField] MyToggle toggle;
    public TMP_Text text;
    [HideInInspector]public Instruction instruction;
    [SerializeField] Button b_saveAsAsset;
    [SerializeField] Button b_deleteAsset;
    public string Name => text.text;

    public void Init(Action OnClick, string name, Instruction instruction, bool removeSaveAssetButtons)
    {
        toggle.OnClick.AddListener(() => OnClick());
        text.text = name;
        this.instruction = instruction;
        MyToggle.OnToggleSelected?.Invoke(toggle); //set new button as selected instruction
        if (removeSaveAssetButtons)
        {
            b_deleteAsset.gameObject.SetActive(false);
            b_saveAsAsset.gameObject.SetActive(false);
        }  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionUIBar : MonoBehaviour
{
    [SerializeField] Image rotationIcon;
    [SerializeField] Image positionIcon;
    [SerializeField] Image colorIcon;

    List<Image> icons = new List<Image>();


    public void ResetUI()
    {
        foreach (Image _icon in icons)
        {
            Destroy(_icon.gameObject);
        }
        icons.Clear();
    }
    public void AddCommandUI(InstructionBuilder.CommandType type)
    {
        if (type == InstructionBuilder.CommandType.COLOR)
        {
            icons.Add(Instantiate(colorIcon, transform));
        }
        if (type == InstructionBuilder.CommandType.POSITION)
        {
            icons.Add(Instantiate(positionIcon, transform));
        }
        if (type == InstructionBuilder.CommandType.ROTATION)
        {
            icons.Add(Instantiate(rotationIcon, transform));
        }
    }


}

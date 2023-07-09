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
    public void AddCommandUI(CommandType type)
    {
        if (type == CommandType.COLOR)
        {
            icons.Add(Instantiate(colorIcon, transform));
        }
        if (type == CommandType.MOVE)
        {
            icons.Add(Instantiate(positionIcon, transform));
        }
        if (type == CommandType.ROTATE)
        {
            icons.Add(Instantiate(rotationIcon, transform));
        }
    }


}

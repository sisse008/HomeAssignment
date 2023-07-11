using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
public class ColorPickerController : MonoBehaviour
{
    [SerializeField] CommandLengthSelector commandLengthSelector;
    [SerializeField] ColorSlider slider;
    public int Length => commandLengthSelector == null ? 2 : commandLengthSelector.SelectedLength;


    public Color SelectedColor => slider.selectedColor;
  

    public void ResetColorPicker()
    {
        slider.ResetSlider();
    }

}

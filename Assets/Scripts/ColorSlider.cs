using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class ColorSlider : MonoBehaviour
{
    [SerializeField] Image sliderImage;
    [SerializeField] Image[] colors;
    Slider slider;

    public Color selectedColor { get; private set; }

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        slider.onValueChanged.AddListener(UpdateHandleColor);
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }

    public void ResetSlider()
    {
        selectedColor = Color.white;
        sliderImage.color = selectedColor;
        slider.value = 0;
    }

    void UpdateHandleColor(float val)
    {
        selectedColor = colors[(int)val].color;
        sliderImage.color = selectedColor;
    }

}

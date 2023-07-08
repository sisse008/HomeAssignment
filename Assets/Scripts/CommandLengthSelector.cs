using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommandLengthSelector : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TMP_Text m_TextMeshPro;
    [SerializeField] int defaultVal = 2;
    public int SelectedLength => slider == null? defaultVal : (int)slider.value;

    private void Start()
    {
        m_TextMeshPro.text = defaultVal.ToString() + "secs";
        slider.value = defaultVal;
    }

    private void OnEnable()
    {
        slider.onValueChanged.AddListener((secs) => m_TextMeshPro.text = ((int)secs).ToString() + "secs");
    }

    private void OnDisable()
    {
        slider.onValueChanged.RemoveAllListeners();
    }
}

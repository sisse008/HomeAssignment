using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTransformText : MonoBehaviour
{

    [SerializeField] protected TMPro.TMP_Text m_xText;
    [SerializeField] protected TMPro.TMP_Text m_yText;
    [SerializeField] protected TMPro.TMP_Text m_zText;

    private void Start()
    {
        UpdateText(Vector3.zero);
    }

    protected virtual void UpdateText(Vector3 transformProperty)
    {
        m_xText.text = "x: " + transformProperty.x.ToString("F1");
        m_yText.text = "y: " + transformProperty.y.ToString("F1");
        m_zText.text = "z: " + transformProperty.z.ToString("F1");
    }
}

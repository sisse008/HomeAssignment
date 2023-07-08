using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// for this to work properly the canvas has to be overlay and constant pixel size
/// </summary>
public class UILineRenderer : MonoBehaviour
{

    public Image lineImage;
    bool needToResetLine;
 

    protected void Start()
    {
        lineImage.enabled = false;
       
    }

    float distance;
    public void DrawLine(RectTransform startRect, RectTransform endRect)
    {

        if (lineImage == null)
            return;

        needToResetLine = true;

        if (lineImage.isActiveAndEnabled == false)
            lineImage.enabled = true;

        Vector3 _startPosition = startRect.position;

        Vector3 _endPosition = endRect.position;

        distance = Vector2.Distance(_startPosition, _endPosition);


        lineImage.rectTransform.sizeDelta = new Vector2(distance, lineImage.rectTransform.sizeDelta.y);
        lineImage.rectTransform.pivot = new Vector2(0, 0.5f);
        lineImage.rectTransform.position = _startPosition;

        lineImage.rectTransform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, _endPosition - _startPosition));

    }

    public void StopDrawing()
    {
        if (needToResetLine)
        {
            lineImage.enabled = false;
            needToResetLine=false;
        }
    }
}

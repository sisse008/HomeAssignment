using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPosition : DisplayTransformText
{

    public void UpdatePositionText(Vector3 newPosition)
    {
        base.UpdateText(newPosition);
    }
}

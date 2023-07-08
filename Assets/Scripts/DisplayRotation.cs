using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayRotation : DisplayTransformText
{
    [SerializeField] RotationPickerController rotationController;

    Vector3 eulerAngles = Vector3.zero;

    private void Update()
    {
        if (eulerAngles != rotationController.SelectedRotation)
        {
            eulerAngles = rotationController.SelectedRotation;
            UpdateText(eulerAngles);
        }
    }
}

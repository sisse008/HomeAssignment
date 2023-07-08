using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(SphereDragRotation))]
public class RotationPickerController : MonoBehaviour
{
    SphereDragRotation sphere;
    public Vector3 SelectedRotation => transform.eulerAngles;

    public Quaternion SelectedQuaternion => Quaternion.Euler(SelectedRotation);

    private void Awake()
    {
        sphere = GetComponent<SphereDragRotation>();
    }

    public void ResetRotationPicker()
    {
        sphere.ResetSphereRotation();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum AxisType
{
    X,Y,Z
}

public class PositionPickerController : MonoBehaviour
{

    [SerializeField] Slider s_X;
    [SerializeField] Slider s_Y;
    [SerializeField] Slider s_Z;

    [SerializeField] DisplayPosition s_DisplayPosition;
    Vector3 newPositionDelta;
    public Vector3 SelectedMovement => newPositionDelta;
    public const float range = 10;

    private void OnEnable()
    {
        s_X.onValueChanged.AddListener((val) => { UpdatePosition(AxisType.X, val); s_DisplayPosition.UpdatePositionText(newPositionDelta); });
        s_Y.onValueChanged.AddListener((val) => { UpdatePosition(AxisType.Y, val); s_DisplayPosition.UpdatePositionText(newPositionDelta); });
        s_Z.onValueChanged.AddListener((val) => { UpdatePosition(AxisType.Z, val); s_DisplayPosition.UpdatePositionText(newPositionDelta); });
    }

    private void OnDisable()
    {
        s_X.onValueChanged.RemoveAllListeners();
        s_Y.onValueChanged.RemoveAllListeners();
        s_Z.onValueChanged.RemoveAllListeners();
    }


    private void Start()
    {
        newPositionDelta = Vector3.zero;
    }

    public void ResetPositionPicker()
    {
        s_X.value = 0f;
        s_Y.value = 0f;
        s_Z.value = 0f;
    }

    public void UpdatePosition(AxisType axis, float val)
    {
        if (axis == AxisType.X)
            newPositionDelta = new Vector3(val*range, newPositionDelta.y, newPositionDelta.z);
        if(axis == AxisType.Y)
            newPositionDelta = new Vector3(newPositionDelta.x, val*range, newPositionDelta.z);
        if (axis == AxisType.Z)
            newPositionDelta = new Vector3(newPositionDelta.x, newPositionDelta.y, val*range);
    }

}

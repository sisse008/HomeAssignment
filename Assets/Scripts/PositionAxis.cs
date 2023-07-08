using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAxis : Draggable
{
    public enum AxisType
    {
        X, Y, Z
    };

    [SerializeField] Transform indicator;
    [SerializeField] AxisType type;
    [SerializeField] Transform max;
    [SerializeField] Transform min;

    Vector3 axisVector;
    Vector3 MidPoint => min.position + axisVector.normalized * axisVector.magnitude / 2;

    private void Start()
    {
        axisVector = (max.position - min.position);
    }

    protected override void Do(Vector3 deltaMousePosition) => UpdateIndicatorPosition(deltaMousePosition);

    Ray ray;
    RaycastHit hit;
    void UpdateIndicatorPosition(Vector3 deltaMousePosition)
    {         
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == gameObject)
            {
                Vector3 hitPoint = hit.point;   
                float projectionScalar = Vector3.Dot(axisVector, hitPoint)/ axisVector.magnitude;

                Vector3 finalPosition = MidPoint + projectionScalar * axisVector.normalized;

                indicator.position = finalPosition;


            }
        }
    }
}

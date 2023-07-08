using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{

    protected bool isDragging = false;
    protected Vector3 previousMousePosition;

    private void OnEnable()
    {
        isDragging = false;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        previousMousePosition = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    protected virtual void Do(Vector3 deltaMousePosition)
    {
        
    }

    protected virtual void Update()
    {
        if(!isDragging)
            return;

        Vector3 deltaMousePosition = Input.mousePosition - previousMousePosition;

        Do(deltaMousePosition);

        previousMousePosition = Input.mousePosition;
    }
}

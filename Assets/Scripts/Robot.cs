using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Robot : MonoBehaviour
{

    public Action<Robot> OnRobotSelected;
    private void OnMouseOver()
    {
        //highlight       
    }

    private void OnMouseDown()
    {
        OnRobotSelected?.Invoke(this);
    }

}

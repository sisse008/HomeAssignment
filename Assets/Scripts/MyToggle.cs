using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class MyToggle : MonoBehaviour, IPointerDownHandler
{
    public static Action<MyToggle> OnToggleSelected;

    [SerializeField] Color selectedColor;
    [SerializeField] Color unSelectedColor;

    public UnityEvent OnClick;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        OnToggleSelected += CheckIfThisToggleSelected;
    }
    private void OnDisable()
    {
        OnToggleSelected -= CheckIfThisToggleSelected;
    }

    void CheckIfThisToggleSelected(MyToggle toggle)
    {
        if (toggle != this)
            UnSelect();
        else
            Select();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnToggleSelected?.Invoke(this);
    }

    void Select()
    { 
        image.color = selectedColor;
        OnClick?.Invoke();
    }
    void UnSelect()
    {
        image.color=unSelectedColor;
    }
 
}

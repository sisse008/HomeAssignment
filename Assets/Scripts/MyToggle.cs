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
    public static Action<MyToggle> OnSelected;

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
        OnSelected += OnToggleSelected;
    }
    private void OnDisable()
    {
        OnSelected -= OnToggleSelected;
    }

    void OnToggleSelected(MyToggle toggle)
    {
        if (toggle != this)
            UnSelect();
        else
            Select();
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnClick?.Invoke();
        OnSelected?.Invoke(this);
    }

    void Select()
    { 
        image.color = selectedColor;
    }
    void UnSelect()
    {
        image.color=unSelectedColor;
    }
 
}

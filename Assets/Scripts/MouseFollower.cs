using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    
    [SerializeField] Hoverable hoverableUISpace;

    public RectTransform rect { get; private set; }

    Image point;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        point = GetComponent<Image>();
    }
    void Start()
    {
        
    }

    Vector2 rectPosition;
    void FollowMousePosition()
    {
        if (point.isActiveAndEnabled == false)
            point.enabled = true;
        rectPosition = hoverableUISpace.HoverRectPosition();

        rect.localPosition = rectPosition;
    }

    private void Update()
    {
        if (hoverableUISpace.IsHoveredOver)
            FollowMousePosition();
        else if (point.isActiveAndEnabled)
            point.enabled = false;
    }

}

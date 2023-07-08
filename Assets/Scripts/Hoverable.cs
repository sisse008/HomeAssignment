using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    RectTransform m_RectTransform;
    protected bool hover = false;

    public bool IsHoveredOver => hover;

    protected virtual void Start()
    {
        hover = false;
       
    }

    protected virtual void Awake()
    {

        m_RectTransform = GetComponent<RectTransform>();    
    }

    public virtual void OnPointerEnter(PointerEventData pointerEventData) => hover = true;

    public virtual void OnPointerExit(PointerEventData pointerEventData) => hover = false;

    public virtual Vector2 HoverRectPosition()
    {

        Vector2 screenPoint = Camera.main.WorldToScreenPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        Vector2 pointInRect;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(m_RectTransform, screenPoint, Camera.main, out pointInRect);

        return pointInRect;
    }

    public Vector2 HoverPosition2()
    {
        Vector2 anchorPos = (Vector2)Input.mousePosition - new Vector2(m_RectTransform.position.x, m_RectTransform.position.y);
        anchorPos = new Vector2(anchorPos.x / m_RectTransform.lossyScale.x, anchorPos.y / m_RectTransform.lossyScale.y);
        return anchorPos;
    }

}

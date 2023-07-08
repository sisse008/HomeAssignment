using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Image))]
public class ColorPickerController : Hoverable, IPointerDownHandler, IChangableLength
{
    [SerializeField] Image indicator;
    [SerializeField] CommandLengthSelector commandLengthSelector;

    public int Length => commandLengthSelector == null ? 2 : commandLengthSelector.SelectedLength;

    Image colorImage;
    Texture2D texture;
    RectTransform rectTransform;

    public Color selectedColor { get; private set; } = Color.white;
    Color hoverColor = Color.white;
  

    bool isColorSelected;

    protected override void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        colorImage = GetComponent<Image>();
        texture = (Texture2D)colorImage.mainTexture; 

        base.Awake();
    }

    protected override void Start()
    {
        isColorSelected = false;
        base.Start();
        
    }
    public override void OnPointerExit(PointerEventData pointerEventData)
    {
        if (isColorSelected == false)
        {
            hoverColor = Color.white;
            indicator.color = hoverColor;
        }
        else
        {
            indicator.color = selectedColor;
        }
        base.OnPointerExit(pointerEventData);
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        isColorSelected = true;
        selectedColor = hoverColor;
    }


    Vector2 rectPosition;
    Vector2Int m_point;
    Vector2Int TextureUVCoordinates()
    {
        rectPosition= HoverRectPosition();
        rectPosition += rectTransform.sizeDelta / 2;
        m_point = new Vector2Int((int)((texture.width * rectPosition.x) / rectTransform.sizeDelta.x), (int)((texture.height * rectPosition.y) / rectTransform.sizeDelta.y));
        return m_point;
    }


    public void Reset()
    {
        isColorSelected = false;
        selectedColor = Color.white;
        indicator.color = selectedColor;
    }

    private void Update()
    {
        if (hover == false)
            return;

        Vector2Int pixelPosition = TextureUVCoordinates();

        hoverColor = texture.GetPixel(pixelPosition.x, pixelPosition.y);

        indicator.color = hoverColor;
    }
}

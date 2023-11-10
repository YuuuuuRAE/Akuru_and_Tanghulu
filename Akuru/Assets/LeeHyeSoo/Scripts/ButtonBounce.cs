using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonBounce : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if(eventData.button == PointerEventData.InputButton.Left)
        {
            rectTransform.localScale = new Vector3(1.2f, 1.2f, 1);
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            rectTransform.localScale = new Vector3(1, 1, 1);
        }

        
    }
}

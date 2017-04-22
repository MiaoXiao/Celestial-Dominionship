using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{
    public Vector2 Position;

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!DragUtility.Instance.IsDragging)
            return;
    }
    //CelestBody Body = null;
}

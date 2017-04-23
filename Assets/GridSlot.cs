using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridSlot : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler
{
    public Vector2 Position;
    public CelestialBody Body = null;
    public Grid mygrid {
        get
        {
            return transform.parent.parent.gameObject.GetComponent<Grid>();
        }
    }

    private void Awake()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hit");
        if (Body == null)
        {
            DragUtility.Instance.LastLocation = this.transform.position;
            DragUtility.Instance.LastParent = this.gameObject;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!DragUtility.Instance.IsDragging)
            return;
    }

    private void OnColliderEnter(Collision collision)
    {
        OnPointerEnter(null);
    }
}

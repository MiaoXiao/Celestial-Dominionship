using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DustBody : RankedBody, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField]
    private Dust DustRef;

    private void Awake()
    {
        CelestRef = DustRef;
    }

    public override void Display()
    {
    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        ToolTipUtility.Instance.ShowToolTip(DustRef);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        ToolTipUtility.Instance.HideToolTip("Celest");
    }
}

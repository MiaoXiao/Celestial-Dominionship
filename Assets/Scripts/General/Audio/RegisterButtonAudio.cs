using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RegisterButtonAudio : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    [SerializeField]
    private AudioInfo ButtonEnter;

    [SerializeField]
    private AudioInfo ButtonClick;

    private Button ButtonRef;

    private void Awake()
    {
        ButtonRef = GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ButtonRef != null && !ButtonRef.interactable)
            return;

        //SoundManager.Instance.PlayAudioSource(ButtonEnter);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (ButtonRef != null && !ButtonRef.interactable)
            return;

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //SoundManager.Instance.PlayAudioSource(ButtonClick);
        }
    }
}

using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    void Awake()
    {
        if (GetComponent<CanvasScaler>() == null)
            throw new Exception("Please attach UIController to Main Canvas");
    }

    //Update UI element
    public void UpdateUI(Text ui, string message)
    {
        ui.text = message;
    }

    public float CanvasScalar
    {
        get
        {
            return GetComponent<CanvasScaler>().scaleFactor;
        }
    }
}

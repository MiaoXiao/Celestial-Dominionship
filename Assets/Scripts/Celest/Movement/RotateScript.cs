﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public float speed;
    public bool isActive;
    public Vector3 direction;

    // Use this for initialization
    void Start()
    {
        StartRotation();
    }

    public void StartRotation()
    {
        isActive = true;
        StartCoroutine("WaitandRotate");
    }

    IEnumerator WaitandRotate()
    {
        while (isActive)
        {
            transform.Rotate(speed * direction * Time.deltaTime);
            yield return null;
        }
    }

}

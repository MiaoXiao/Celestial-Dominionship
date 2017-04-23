using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

    public Transform gameTransform;

    public float speed;
    public bool isActive;
    public Vector3 direction;

    private IEnumerator coroutine;

    // Use this for initialization
    void Start()
    {
        gameTransform = gameObject.transform;
        isActive = false;
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
            gameTransform.Rotate(speed * direction * Time.deltaTime);
            yield return null;
        }
    }

}

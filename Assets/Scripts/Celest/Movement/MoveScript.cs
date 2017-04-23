using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    public Transform gameTransform;

    public float speed;
    public bool isActive;
    public Vector3 direction;

    private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
        gameTransform = gameObject.transform;
        isActive = false;
        StartMovement();
}

    public void StartMovement()
    {
        isActive = true;
        StartCoroutine("WaitandMove");
    }

    IEnumerator WaitandMove()
    {
        while (isActive)
        {
            gameTransform.Translate(speed * direction * Time.deltaTime);
            yield return null;
        }
    }

}

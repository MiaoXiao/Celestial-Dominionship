using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxMovement : MonoBehaviour {

    public int speed;
    public Vector3 direction;

    private Rect ownRect;

	// Use this for initialization
	void Start () {
        ownRect = GetComponent<RectTransform>().rect;
        ownRect.width = GetComponent<Text>().preferredWidth;
        StartCoroutine("WaitAndMove");
    }

    IEnumerator WaitAndMove()
    {
        while (true)
        {
            transform.Translate(speed * direction * Time.deltaTime);
            TestifGone();
            yield return null;
        }
    }

    private void TestifGone()
    {
        //Debug.Log(ownRect.width + " " + GetComponent<Text>().preferredWidth);
        //Debug.Log(transform.position.x + " <? " + -ownRect.width);
        if (transform.position.x < -ownRect.width)
        {
            Destroy(gameObject);
        }
    }
}

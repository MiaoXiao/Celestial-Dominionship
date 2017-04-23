using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoTab : MonoBehaviour {

    public GameObject infotab;
    public int changeLocation = 672;
    public float deltaLocation = 0;
    public int infoStatus = 1;

    public List<string> infolines;
    public Text infoTextBox;
    public int textCurrent = -1;

	// Use this for initialization
	void Start () {
        infotab = gameObject;
        ChangeInfoText();
    }
	
	// Update is called once per frame
	void Update () {
		if (deltaLocation != 0)
        {
            MoveInfoTab();
        }
	}

    public void StartInfoTab()
    {
        if (infoStatus > 0)
        {
            deltaLocation = changeLocation;
            infoStatus *= -1;
        }
        else
        {
            deltaLocation = -changeLocation;
            infoStatus *= -1;
        }
    }

    public void MoveInfoTab()
    {
        float updatePosition = infoStatus * Time.deltaTime * changeLocation;
        gameObject.transform.Translate(updatePosition, 0, 0);
        deltaLocation += updatePosition;

        if (deltaLocation < 0 && infoStatus < 0)
        {
            deltaLocation = 0;
        }
        else if (deltaLocation > 0 && infoStatus > 0)
        {
            deltaLocation = 0;
        }
    }

    public void ChangeInfoText()
    {
        textCurrent++;
        if (textCurrent >= infolines.Count)
        {
            textCurrent = 0;
        }
        infoTextBox.text = infolines[textCurrent];
    }
}

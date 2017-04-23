using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsAlert : MonoBehaviour {

    [SerializeField]
    private List<string> Phrases;

    [SerializeField]
    private List<string> StartPhrases;

    public Text textbox;

    public Vector3 startLocation;
    public int speed;

    [SerializeField]
    float time = 0;

    void Start()
    {
        startLocation = transform.TransformPoint(textbox.transform.localPosition);
        StartCoroutine("WaitAndMove");
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > 5)
        {
            time = 0;
            CallNewsAlert();
        }
    }

    public void CallNewsAlert(/*string planetName, int health*/)
    {
        textbox.transform.position = startLocation;

        string planetName = "Earth";
        int health = Random.Range(1, 5);

        Debug.Log("hi");

        string population = Random.Range(1, 999).ToString() + " ";
        switch (health)
        {
            case 1: population += "thousand";
                break;
            case 2:
                population += "million";
                break;
            case 3:
                population += "billion";
                break;
            case 4:
                population += "trillion";
                break;
            case 5:
                population += "quadrillion";
                break;
        }
        textbox.text = string.Format(StartPhrases[Random.Range(0, StartPhrases.Count)] + Phrases[Random.Range(0, Phrases.Count)], planetName, population);
    }

    IEnumerator WaitAndMove()
    {
        while (true)
        {
            textbox.transform.Translate(speed * Vector3.left * Time.deltaTime);
            yield return null;
        }
    }

}

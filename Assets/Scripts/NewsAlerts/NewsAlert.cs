using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsAlert : MonoBehaviour {

    [SerializeField]
    private List<string> Phrases;

    [SerializeField]
    private List<string> StartPhrases;

    [SerializeField]
    Text textbox;

    [SerializeField]
    float time = 0;

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

}

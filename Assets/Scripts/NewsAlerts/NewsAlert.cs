using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsAlert : MonoBehaviour {

    public List<string> Phrases;

    [SerializeField]
    private List<string> EndPhrases;

    [SerializeField]
    private List<string> StartPhrases;

    public Text lastTextBox;

    public Vector3 startLocation;

    public GameObject textBox;

    void Start()
    {
        startLocation = new Vector3(GetComponent<RectTransform>().rect.x + GetComponent<RectTransform>().rect.width, transform.position.y, transform.position.z);
        //textBox = 
        StartCoroutine("WaitAndSpawn");
    }

    private void CallNewsAlert()
    {
        GameObject temp = Instantiate(textBox, transform);
        temp.transform.position = startLocation;
        temp.GetComponent<Text>().text = Phrases[0];
        Phrases.RemoveAt(0);

        lastTextBox = temp.GetComponent<Text>();
    }


    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            TestifParsed();
            yield return null;
        }
    }

    public void AddNewsAlert(string planetName = "Earth", int health = 1)
    {
        string population = Random.Range(1, 999).ToString() + " ";
        switch (health)
        {
            case 1:
                population += "thousand";
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
        Phrases.Add(string.Format(StartPhrases[Random.Range(0, StartPhrases.Count)] + EndPhrases[Random.Range(0, EndPhrases.Count)], planetName, population) + "     ");
    }

    public void AddNewsAlert()
    {
        Debug.Log("hi");
        string planetName = "Earth"; int health = 1;
        string population = Random.Range(1, 999).ToString() + " ";
        switch (health)
        {
            case 1:
                population += "thousand";
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
        Phrases.Add(string.Format(StartPhrases[Random.Range(0, StartPhrases.Count)] + EndPhrases[Random.Range(0, EndPhrases.Count)], planetName, population) + "     ");
    }

    public void AddCustomNewsAlert(string announcement)
    {
        Phrases.Add(announcement);
    }

    private void TestifParsed()
    {
        if (Phrases.Count == 0) return;
        if (lastTextBox == null) CallNewsAlert();

        //Debug.Log((lastTextBox.transform.position.x + lastTextBox.rectTransform.rect.width) + " <? " + GetComponent<RectTransform>().rect.width);
        if (lastTextBox.transform.position.x + lastTextBox.rectTransform.rect.width < GetComponent<RectTransform>().rect.width)
        {
            CallNewsAlert();
        }
    }

}

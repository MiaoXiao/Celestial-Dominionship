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
    public Vector3 emergyStartLocation;

    public GameObject textBox;
    public GameObject emergyTextBox;

    void Start()
    {
        startLocation = new Vector3(GetComponent<RectTransform>().rect.x + GetComponent<RectTransform>().rect.width, transform.position.y, transform.position.z);
        emergyStartLocation = new Vector3(GetComponent<RectTransform>().rect.width / 2, emergyTextBox.transform.position.y, emergyTextBox.transform.position.z);

        Destroy(GameObject.Find("NewsTextBox"));
        Destroy(GameObject.Find("EmergyNewsTextBox"));

        StartCoroutine("WaitAndSpawn");
    }

    public float i = 0, j = 0;

    private void Update()
    {
        i += Time.deltaTime;
        j += Time.deltaTime;
        if (i > 3)
        {
            AddNewsAlert();
            i = 0;
        }
        if (j > 20)
        {
            AddEmergencyNewsAlert("YOU ARE BEING RETARDED", Color.red);
            j = 0;
        }
    }

    private void CallNewsAlert()
    {
        if (Phrases.Count > 0)
        {
            GameObject temp = Instantiate(textBox, transform);
            temp.transform.position = startLocation;
            temp.GetComponent<Text>().text = Phrases[0];
            Phrases.RemoveAt(0);

            lastTextBox = temp.GetComponent<Text>();
        }
    }


    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            TestifParsed();
            yield return null;
        }
    }

    IEnumerator WaitAndContinueSpawn()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(lastTextBox.gameObject);
        StartCoroutine("WaitAndSpawn");
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

    public void AddEmergencyNewsAlert(string announcement, Color colour)
    {
        StopCoroutine("WaitAndSpawn");
        //Debug.Log(GameObject.FindGameObjectsWithTag("NewsText").Length);
        foreach (GameObject gameobj in GameObject.FindGameObjectsWithTag("NewsText"))
        {
            Destroy(gameobj);
        }

        GameObject temp = Instantiate(emergyTextBox, transform);
        temp.transform.localPosition = emergyStartLocation;

        Text temptext = temp.GetComponent<Text>();
        temptext.text = announcement;
        temptext.color = colour;

        lastTextBox = temptext;

        StartCoroutine("WaitAndContinueSpawn");
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

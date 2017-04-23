using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour{

    public string PlayMenu = "PlayMenu";
    public string InfoMenu = "InformationMenu";

    public void GoToPlay()
    {
        SceneManager.LoadScene("Play");
    }

    public void GoToInfo()
    {
        GameObject.Find("InfoTab").GetComponent<InfoTab>().StartInfoTab();
    }

    public void GoToQuit()
    {
        Application.Quit();
    }

}

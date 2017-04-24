using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameScreen : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.State = new InitGameState();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScene");
    }
}

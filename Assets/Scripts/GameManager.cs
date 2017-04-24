using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum States {Buy, Draw, Init, Switch, Play, Sun}

public class GameManager : Singleton<GameManager>
{
    private GameState _State;
    public CelestialBody tempDust;
    public CelestialBody sun;
    public States currState;
    [SerializeField]
    private Grid Shop;

    public GameState State
    {
        get { return _State; }
        set
        {
            if (value == _State)
                return;
            if (_State != null)
                _State.OnStateExit();

            _State = value;

            _State.OnStateEnter();
        }
    }

    public Player PlayerOne;
    public Player PlayerTwo;

    public Camera Player1Cam;

    private Quaternion rotate1;
    private Quaternion rotate2;

    public Camera Player2Cam;

    [SerializeField]
    private GameObject EndGameScreen = null;
    
    public Player CurrentPlayer { get; private set; }
    
    public Player OppositePlayer { get; private set; }
    
    private GameObject UITabReference;

    private void Awake()
    {
        if (EndGameScreen == null)
            throw new System.Exception("Please attach End Game Screen reference in Game Manager.");

        EndGameScreen.SetActive(false);
    }

    private void Start()
    {
        CurrentPlayer = PlayerOne;
        OppositePlayer = PlayerTwo;
        rotate1 = Player1Cam.transform.rotation;
        rotate2 = Player2Cam.transform.rotation;
        State = new SunState();
        UpdateUI();
        //PopulateShop();
    }

    public void SwitchTurn()
    {
        if (currState.Equals(States.Sun))
        {
            if (CurrentPlayer == PlayerOne)
            {
                CurrentPlayer = PlayerTwo;
                OppositePlayer = PlayerOne;
                Player1Cam.transform.position = new Vector3(0f, 65.9f, 130f);
                Player1Cam.transform.rotation = rotate2;
            }
            else
            {
                CurrentPlayer = PlayerOne;
                OppositePlayer = PlayerTwo;
                Player1Cam.transform.position = new Vector3(0f, 65.9f, -45.8f);
                Player1Cam.transform.rotation = rotate1;
                State = new InitGameState();
            }
        }
        else
        {
            GameManager.Instance.CurrentPlayer.EmptyHand();
            GameManager.Instance.CurrentPlayer.ResetBuys();
            if (CurrentPlayer == PlayerOne)
            {
                CurrentPlayer = PlayerTwo;
                OppositePlayer = PlayerOne;
                Player1Cam.transform.position = new Vector3(0f, 65.9f, 130f);
                Player1Cam.transform.rotation = rotate2;
            }
            else
            {
                CurrentPlayer = PlayerOne;
                OppositePlayer = PlayerTwo;
                Player1Cam.transform.position = new Vector3(0f, 65.9f, -45.8f);
                Player1Cam.transform.rotation = rotate1;
            }
            State = new SwitchPlayerState();
        }
        UpdateUI();
    }

    public void WinGame(Player winner)
    {
        UIController.Instance.UpdateUI(EndGameScreen.transform.FindChild("Title").GetComponent<Text>(), winner.name + " wins!");
    }

    public void PopulateShop()
    {
        //Shop = Instantiate<Grid>(Shop);
        //Shop.ReInitGrid(new Vector2(2, 8));
        //Shop.PopulateGrid(planet, new Vector2(1, 1));
    }
    private void UpdateUI()
    {
        CurrentPlayer.Dust += 0;
        CurrentPlayer.Buys += 0;
        CurrentPlayer.cardDraw += 0;
        CurrentPlayer.UpdateDecksizeUI();
    }


}

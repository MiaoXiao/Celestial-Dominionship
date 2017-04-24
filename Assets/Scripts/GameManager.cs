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
        State = new SunState();
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
            }
            else
            {
                CurrentPlayer = PlayerOne;
                OppositePlayer = PlayerTwo;
                State = new InitGameState();
            }
        }
        else
        {
            State = new SwitchPlayerState();
            if (CurrentPlayer == PlayerOne)
            {
                CurrentPlayer = PlayerTwo;
                OppositePlayer = PlayerOne;
            }
            else
            {
                CurrentPlayer = PlayerOne;
                OppositePlayer = PlayerTwo;
            }
        }
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


}

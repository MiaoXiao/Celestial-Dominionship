using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum States {Buy, Draw, Init, Switch, Play}

public class GameManager : Singleton<GameManager>
{
    private GameState _State;
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

    public Player CurrentPlayer { get; private set; }
    public Player OppositePlayer { get; private set; }
    private GameObject UITabReference;

    private void Start()
    {
        CurrentPlayer = PlayerOne;
        OppositePlayer = PlayerTwo;
        State = new InitGameState();
        //PopulateShop();
    }

    public void SwitchTurn()
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
    public void PopulateShop()
    {
        //Shop = Instantiate<Grid>(Shop);
        //Shop.ReInitGrid(new Vector2(2, 8));
        //Shop.PopulateGrid(planet, new Vector2(1, 1));
    }


}

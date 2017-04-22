using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState _State;
    public GameState State
    {
        get { return _State; }
        set
        {
            if (value == _State)
                return;

            _State.OnStateExit();

            _State = value;

            _State.OnStateEnter();
        }
    }

    private Player PlayerOne;
    private Player PlayerTwo;

    public Player CurrentPlayer { get; private set; }

    private GameObject UITabReference;

    private void Awake()
    {
        CurrentPlayer = PlayerOne;
    }

    public void SwitchTurn()
    {
        if (CurrentPlayer == PlayerOne)
            CurrentPlayer = PlayerTwo;
        else
            CurrentPlayer = PlayerOne;
    }


}

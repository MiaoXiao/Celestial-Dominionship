using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    public override void OnStateEnter()
    {
        Player current_player = GameManager.Instance.CurrentPlayer;
        current_player.Play();
    }

    public override void OnStateExit()
    {
        Player current_player = GameManager.Instance.CurrentPlayer;
        current_player.Play();
        throw new NotImplementedException();
    }
}

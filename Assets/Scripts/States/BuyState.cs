using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyState : GameState
{
    public override void OnStateEnter()
    {
        Player current_player = GameManager.Instance.CurrentPlayer;
        current_player.EmptyHand();
    }

    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
}

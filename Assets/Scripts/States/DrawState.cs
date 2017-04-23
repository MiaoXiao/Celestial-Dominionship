using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : GameState
{
    public override void OnStateEnter()
    {
        Player current_player = GameManager.Instance.CurrentPlayer;
        current_player.Draw(current_player.cardDraw);
    }

    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
}

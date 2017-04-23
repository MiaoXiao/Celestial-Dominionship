﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    public override void OnStateEnter()
    {
        GameManager.Instance.currState = States.Play;
        Player current_player = GameManager.Instance.CurrentPlayer;
        current_player.Play();
    }

    public override void OnStateExit()
    {
        
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : GameState
{
    public override void OnStateEnter()
    {
        Player current_player = GameManager.Instance.CurrentPlayer;
    }

    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
}

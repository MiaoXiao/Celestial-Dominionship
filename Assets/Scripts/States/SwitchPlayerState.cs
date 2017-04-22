using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerState : GameState
{
    public override void OnStateEnter()
    {
        GameManager.Instance.SwitchTurn();
    }

    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
}

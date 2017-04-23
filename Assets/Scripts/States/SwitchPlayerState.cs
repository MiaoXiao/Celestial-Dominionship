using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerState : GameState
{
    public override void OnStateEnter()
    {
        Debug.Log("Switching Sides...");
        GameManager.Instance.currState = States.Switch;
        GameManager.Instance.SwitchTurn();
    }

    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameState
{
    public abstract void OnStateEnter();
    public abstract void OnStateExit();
}

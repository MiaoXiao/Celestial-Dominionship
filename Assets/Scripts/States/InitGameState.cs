using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGameState : GameState
{
    public override void OnStateEnter()
    {
        GameManager.Instance.currState = States.Init;
        Debug.Log(GameManager.Instance.currState);
        Player current_player = GameManager.Instance.CurrentPlayer;
        Player other_player = GameManager.Instance.OppositePlayer;
        for(int x = 0; x < 5; x++)
        {
            //Switch to object pooler
            CelestialBody dust = GameObject.Instantiate<CelestialBody>(GameManager.Instance.tempDust);
            dust.owner = current_player;
            current_player.MainDeck.Add(dust);
            current_player.Discard.PopulateGrid(dust);
        }
        for (int x = 0; x < 5; x++)
        {
            //Switch to object pooler
            CelestialBody dust = GameObject.Instantiate<CelestialBody>(GameManager.Instance.tempDust);
            dust.owner = other_player;
            other_player.MainDeck.Add(dust);
            other_player.Discard.PopulateGrid(dust);
        }
        GameManager.Instance.State = new DrawState();
    }

    public override void OnStateExit()
    {

    }
}

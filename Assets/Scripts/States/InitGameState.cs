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
        for(int x = 0; x < 3; x++)
        {
            //Switch to object pooler
            CelestialBody dust = ObjectPoolerManager.Instance.GetPooler["Copper Dust"].RetrieveCopy().GetComponent<CelestialBody>();
            //CelestialBody dust = GameObject.Instantiate<CelestialBody>(GameManager.Instance.tempDust);
            dust.owner = current_player;
            current_player.DiscardCard(dust);
        }
        for(int x = 0; x < 2; x++)
        {
            CelestialBody meteor = ObjectPoolerManager.Instance.GetPooler["Simple Comet"].RetrieveCopy().GetComponent<CelestialBody>();
            meteor.owner = current_player;
            //current_player.MainDeck.Add(meteor);
            current_player.DiscardCard(meteor);
        }
        for (int x = 0; x < 3; x++)
        {
            //Switch to object pooler
            CelestialBody dust = ObjectPoolerManager.Instance.GetPooler["Copper Dust"].RetrieveCopy().GetComponent<CelestialBody>();
            dust.owner = other_player;
            //other_player.MainDeck.Add(dust);
            other_player.DiscardCard(dust);
        }
        for (int x = 0; x < 2; x++)
        {
            //Switch to object pooler
            CelestialBody meteor = ObjectPoolerManager.Instance.GetPooler["Simple Comet"].RetrieveCopy().GetComponent<CelestialBody>();
            meteor.owner = other_player;
            //other_player.MainDeck.Add(meteor);
            other_player.DiscardCard(meteor);
        }
        current_player.DeckShuffle(ref current_player.MainDeck);
        other_player.DeckShuffle(ref current_player.MainDeck);
        GameManager.Instance.State = new DrawState();
    }

    public override void OnStateExit()
    {

    }
}

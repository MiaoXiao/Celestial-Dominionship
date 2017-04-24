using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunState : GameState
{
    public override void OnStateEnter()
    {
        GameManager.Instance.currState = States.Sun;
        CelestialBody sun1 = ObjectPoolerManager.Instance.GetPooler["Sun"].RetrieveCopy().GetComponent<CelestialBody>();
        CelestialBody sun2 = ObjectPoolerManager.Instance.GetPooler["Sun"].RetrieveCopy().GetComponent<CelestialBody>();
        sun1.owner = GameManager.Instance.CurrentPlayer;
        sun2.owner = GameManager.Instance.OppositePlayer;
        GameManager.Instance.CurrentPlayer.Hand.PopulateGrid(sun1);
        GameManager.Instance.OppositePlayer.Hand.PopulateGrid(sun2);

        GameManager.Instance.NextTurnButton.interactable = false;
    }

    public override void OnStateExit()
    {

    }
}

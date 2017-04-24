using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunState : GameState {
        public override void OnStateEnter()
        {
        GameManager.Instance.currState = States.Sun;
        CelestialBody sun1 = GameObject.Instantiate<CelestialBody>(GameManager.Instance.sun);
        CelestialBody sun2 = GameObject.Instantiate<CelestialBody>(GameManager.Instance.sun);
        sun1.owner = GameManager.Instance.CurrentPlayer;
        sun2.owner = GameManager.Instance.OppositePlayer;
        GameManager.Instance.CurrentPlayer.Hand.PopulateGrid(sun1);
        GameManager.Instance.OppositePlayer.Hand.PopulateGrid(sun2);
    }

        public override void OnStateExit()
        {

        }
    }

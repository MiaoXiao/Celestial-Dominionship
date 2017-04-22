using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : Singleton<Activate> {
    Player CurrentPlayer;

    public void ActivateEffect(Effect eff, int value, Player AffectedPlayer)
    {
        CurrentPlayer = AffectedPlayer;
        switch (eff)
        {
            case Effect.Dust:
                break;
            case Effect.CardDraw:
                break;
            case Effect.Buys:
                break;
            case Effect.GenerateMeteor:
                break;
            case Effect.RotateGrid:
                break;
            case Effect.StarHealth:
                break;
            case Effect.Trash:
                break;
            default:
                break;
        }
    }

    public void Dust(int val)
    {
        CurrentPlayer.Dust += val;
    }
}

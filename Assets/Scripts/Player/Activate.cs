using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : Singleton<Activate> {
    Player CurrentPlayer;

    public void ActivateEffect(Special effect, Player Owner)
    {
        //Check which player is going to recieve the effect
        if (!effect.affectedPlayer)
        {
            if (GameManager.Instance.CurrentPlayer == Owner)
                CurrentPlayer = GameManager.Instance.OppositePlayer;
            else
                CurrentPlayer = Owner;
        }
        else
            CurrentPlayer = Owner;
        Effect eff = effect.currentEffect;

        //Do the effect
        switch (eff)
        {
            case Effect.Dust:
                Dust(effect.value);
                break;
            case Effect.CardDraw:
                break;
            case Effect.Buys:
                Buys(effect.value);
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

    public void Buys(int val)
    {
        CurrentPlayer.buysAvailible += val;
    }
}

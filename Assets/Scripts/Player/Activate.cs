using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : Singleton<Activate>
{
    Player CurrentPlayer;

    public void ActivatePlanetEffect(PlanetSpecial effect, Player Owner)
    {
        //Check which player is going to recieve the effect
        if (!effect.affectsUser)
        {
            if (GameManager.Instance.CurrentPlayer == Owner)
                CurrentPlayer = GameManager.Instance.OppositePlayer;
            else
                CurrentPlayer = Owner;
        }
        else
            CurrentPlayer = Owner;

        //Do the effect
        switch (effect.currentEffect)
        {
            case PlanetEffect.Dust:
                Dust(effect.value);
                break;
            case PlanetEffect.CardDraw:
                break;
            case PlanetEffect.Buys:
                Buys(effect.value);
                break;
            case PlanetEffect.GenerateMeteor:                
                break;
            default:
                break;
        }
    }

    public void ActivateSpecialEffect(Special effect, Player Owner)
    {
        //Check which player is going to recieve the effect
        if (!effect.affectsUser)
        {
            if (GameManager.Instance.CurrentPlayer == Owner)
                CurrentPlayer = GameManager.Instance.OppositePlayer;
            else
                CurrentPlayer = Owner;
        }
        else
            CurrentPlayer = Owner;

        //Do the effect
        switch (effect.currentEffect)
        {
            case Effect.Buys:
                Buys(effect.value);
                break;
            case Effect.CardDraw:
                break;
            case Effect.Dust:
                Dust(effect.value);
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

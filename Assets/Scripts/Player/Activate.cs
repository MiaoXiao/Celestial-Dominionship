using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : Singleton<Activate>
{
    Player CurrentPlayer;

    private void Awake()
    {
        CurrentPlayer = GameManager.Instance.CurrentPlayer;
    }

    public void ActivatePlanetEffect(PlanetSpecial effect, Player Owner)
    {


        //Do the effect
        switch (effect.currentEffect)
        {
            case PlanetEffect.Dust:
                Dust(effect.value);
                break;
            case PlanetEffect.CardDraw:
                CardDraw(effect.value);
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
            case Effect.Trash:
                break;
            default:
                break;
        }
    }

    public void Dust(int val)
    {
        print("increase by " + val);
        if (CurrentPlayer != null)
            CurrentPlayer.Dust += val;
    }

    public void CardDraw(int val)
    {
        if (CurrentPlayer != null)
            CurrentPlayer.cardDraw += val;
    }

    public void Buys(int val)
    {
        if (CurrentPlayer != null)
            CurrentPlayer.Buys += val;
    }
}

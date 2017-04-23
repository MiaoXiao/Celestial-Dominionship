using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Effect { Dust, StarHealth, CardDraw, RotateGrid, Buys, Trash }

[CreateAssetMenu(fileName = "Celest", menuName = "Celest/CreateSpecialObject", order = 2)]
public class Special : Celest
{
    
    [SerializeField]
    public Effect currentEffect; // EFFECT, DUH
    public int value;
    
    public bool affectsUser = true;

    public override string GetDescription()
    {
        string desc = "";
        switch (currentEffect)
        {
            case Effect.Dust:
                desc += "Gain " + value + " Dust.";
                break;
            case Effect.Buys:
                desc += "Gain " + value + " extra Wormholes for this turn only.";
                break;
            case Effect.CardDraw:
                desc += "Gain " + value + " extra Warps for this turn only.";           
                break;
            case Effect.RotateGrid:
                break;
            case Effect.StarHealth:
                break;
            case Effect.Trash:
                desc += "Destroy " + value + " Celestrals in your Home or in your Galaxy.";
                break;
        }

        return desc;
    }
}

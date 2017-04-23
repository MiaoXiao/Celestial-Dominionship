using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DustBody : RankedBody
{
    [SerializeField]
    private Dust DustRef;

    private void OnEnable()
    {
        DustRef = Instantiate(DustRef);
        DustRef.name = DustRef.name.Replace("(Clone)", "").Trim();
    }

    public override Celest GetCelest()
    {
        return DustRef;
    }


    //When the object is hit on the grid
    public override void OnHit(Collider collision)
    {
        MeteorBody meteor_body = collision.gameObject.GetComponent<MeteorBody>();
        if (meteor_body == null)
            return;
    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }
}

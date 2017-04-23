using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CometBody : MeteorBody
{
    private MoveScript Mover = null;

    private bool Primed = false;

    private bool Fired = false;

    public override void OnHit(Collider collision, MeteorBody meteor_body)
    {
        print("COMET ON HIT");

        MeteorRef.piercing--;
        if (MeteorRef.piercing <= -1)
            gameObject.SetActive(false);

    }

    public override void Play()
    {
        if (Fired)
            return;

        if (!Mover.isActive)
        {
            Mover.StartMovement(MeteorRef.projectileSpeed, Vector3.right);
            Fired = true;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (eventData.button == PointerEventData.InputButton.Left && isLocked)
            Play();
    }

    public override Celest GetCelest()
    {
        return MeteorRef;
    }

    // Use this for initialization
    void OnEnable ()
    {
        MeteorRef = Instantiate(MeteorRef);
        MeteorRef.name = MeteorRef.name.Replace("(Clone)", "").Trim();

        Mover = GetComponent<MoveScript>();
        if (Mover == null)
            gameObject.AddComponent<MoveScript>();

    }
}

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

    public override void OnHit(Collider collision)
    {
        MeteorBody meteor_body = collision.gameObject.GetComponent<MeteorBody>();
        if (meteor_body == null)
            return;

        MeteorRef.health--;
        if (MeteorRef.health <= 0)
            gameObject.SetActive(false);

    }

    public override void Play()
    {
        if (Fired)
            return;

        if (!Mover.isActive)
        {
            print("move");
            Mover.StartMovement(MeteorRef.projectileSpeed, Vector3.right);
            Fired = true;
        }
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);

        if (isLocked)
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorBody: DestroyableBody
{
    public Meteor GetMeteor()
    {
        return (Meteor)GetCelest();
    }

    protected void StartDeathTimer(float seconds)
    {
        StartCoroutine("CountDown", seconds);
    }
    
    IEnumerator CountDown(float seconds)
    {
        float curr_time = 0f;
        while (curr_time < seconds)
        {
            curr_time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);

    }
}

﻿using System;
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

    /// <summary>
    /// We need to set this var 
    /// </summary>
    public GridSlot currentSlot
    {
        get
        {
            return transform.parent.parent.GetComponent<GridSlot>();
        }
    }

    /// <summary>
    /// Trigger on hit functions on all celest objects within radius
    /// THIS FUNCTION HAS NOT BEEN TESTED YET.
    /// </summary>
    protected void damageCelestWithinRadius()
    {
        int radius = GetMeteor().radius;
        if (radius <= 1)
            return;

        Grid grid = currentSlot.mygrid;
        Vector2 curr_pos = currentSlot.Position;

        int min_x = Mathf.Clamp((int)curr_pos.x - radius - 1, 0, (int)grid.Dimensions.x - 1);
        int max_x = Mathf.Clamp((int)curr_pos.x + radius - 1, 0, (int)grid.Dimensions.x - 1);
        int min_y = Mathf.Clamp((int)curr_pos.y - radius - 1, 0, (int)grid.Dimensions.y - 1);
        int max_y = Mathf.Clamp((int)curr_pos.y + radius - 1, 0, (int)grid.Dimensions.y - 1);

        for (int i = min_x; i < max_x; ++i)
        {
            for (int j = min_y; j < max_y; ++j)
            {
                Vector2 checking = new Vector2(i, j);
                if (grid.SlotList[checking].Body != null)
                    grid.SlotList[checking].Body.OnHit(gameObject.GetComponent<Collider>(), this);
            }
        }

    }
}

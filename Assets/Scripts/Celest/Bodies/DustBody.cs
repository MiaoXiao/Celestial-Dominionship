﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustBody : RankedBody {

    Dust DustRef;

    public override void Display()
    {
    }

    public override void Play()
    {
        GameManager.Instance.CurrentPlayer.Dust += DustRef.value;
    }

}

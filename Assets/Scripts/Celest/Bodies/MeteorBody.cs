﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MeteorBody: RankedBody
{
    public Meteor GetMeteor()
    {
        return (Meteor)GetCelest();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create AudioInfo", menuName = "Audio/Create AudioInfo", order = 1)]
public class AudioInfo: ScriptableObject
{
    public enum ChannelGroup { FX, UI, Voice, Music };

    public AudioClip Clip;
    public ChannelGroup ChannelGroupId = ChannelGroup.FX;
}

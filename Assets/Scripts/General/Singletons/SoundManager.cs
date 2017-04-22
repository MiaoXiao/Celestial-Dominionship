using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    protected SoundManager() { }

    private Dictionary<AudioInfo.ChannelGroup, AudioChannelGroup> ChannelGroups = new Dictionary<AudioInfo.ChannelGroup, AudioChannelGroup>();

    private void Awake()
    {
        foreach (AudioInfo.ChannelGroup group_id in Enum.GetValues(typeof(AudioInfo.ChannelGroup)))
        {
            GameObject obj = new GameObject();
            GameObject channel_group = Instantiate(obj) as GameObject;
            channel_group.AddComponent<AudioChannelGroup>();
            channel_group.transform.SetParent(transform);
            channel_group.name = group_id.ToString();
            ChannelGroups.Add(group_id, channel_group.GetComponent<AudioChannelGroup>());
            Destroy(obj);
        }
    }

    public void PlayAudioSource(AudioInfo s)
    {
        if (s == null)
        {
            return;
        }

        AudioSource channel = ChannelGroups[s.ChannelGroupId].GetNextAvaliableChannel();
        channel.clip = s.Clip;
        channel.Play();
    }

    public AudioSource PlayAudioSourceLoop(AudioInfo s)
    {
        AudioSource channel = ChannelGroups[s.ChannelGroupId].GetNextAvaliableChannel();
        channel.loop = true;
        channel.clip = s.Clip;
        channel.Play();
        return channel;
    }

    public void StopLooping(AudioSource s)
    {
        s.loop = false;
    }

    public void HaltChannelGroup(AudioInfo.ChannelGroup id)
    {
        ChannelGroups[id].HaltAll();
    }
}
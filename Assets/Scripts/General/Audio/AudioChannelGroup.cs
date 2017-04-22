using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioChannelGroup : MonoBehaviour
{
    private int MinChannels = 5;
    private int MaxChannels = 15;
    private List<AudioSource> Channels = new List<AudioSource>();

    private void Start()
    {
        for (int i = 0; i < MinChannels; ++i)
        {
            CreateAudioSource();
        }
    }

    public AudioSource GetNextAvaliableChannel()
    {
        foreach(AudioSource channel in Channels)
        {
            if (!channel.isPlaying)
                return channel;
        }
        return CreateAudioSource();
    }

    public void SetVolume(float volume)
    {
        foreach(AudioSource channel in Channels)
        {
            channel.volume = volume;
        }
    }

    public void HaltAll()
    {
        foreach (AudioSource channel in Channels)
        {
            channel.Stop();
            channel.loop = false;
        }
    }

    private AudioSource CreateAudioSource()
    {
        AudioSource new_channel = gameObject.AddComponent<AudioSource>();
        new_channel.playOnAwake = false;
        Channels.Add(new_channel);

        if (Channels.Count >= MaxChannels)
            throw new System.Exception("Exceeded maximum audio channels.");

        return new_channel;
    }
}

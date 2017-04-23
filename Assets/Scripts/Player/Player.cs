﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<CelestialBody> CurrentHand = new List<CelestialBody>();
    public List<CelestialBody> MainDeck = new List<CelestialBody>();
    public List<CelestialBody> Discard = new List<CelestialBody>();
    //Grid Field;

    private int _Dust = 0;
    public int Dust
    {
        get
        {
            return _Dust;
        }
        set
        {
            if (value < 0)
                _Dust = 0;
            else
                _Dust = value;
        }
    }
    private int _Buys = 1;
    public int Buys
    {
        get
        {
            return _Buys;
        }
        set
        {
            if (value < 0)
                _Buys = 0;
            else
                _Buys = value;
        }
    }
    private int _cardDraw = 5;
    public int cardDraw
    {
        get
        {
            return _cardDraw;
        }
        set
        {
            if (value < 0)
                _cardDraw = 0;
            else
                _cardDraw = value;
        }
    }

    public delegate void Passives();
    public Passives perTick;

    /// <summary>
    /// Draw specified number of cards into your hand up until your card draw.
    /// Shuffle discard back into Main deck if neccesary
    /// </summary>
    public void Draw(int cards)
    {
        int drawnCards = cards;
        while (drawnCards > 0)
        {
            CurrentHand.Add(MainDeck[0]);
            MainDeck.RemoveAt(0);
            drawnCards--;

            if (MainDeck.Count == 0)
            {
                RemakeDeck();
                if (MainDeck.Count == 0)
                    drawnCards = 0;
            }
        }
    }

    /// <summary>
    /// Put discard pile back into main deck
    /// </summary>
    public void RemakeDeck()
    {
        if (MainDeck.Count != 0)
            return;

        MainDeck = new List<CelestialBody>(Discard);
        DeckShuffle(ref MainDeck);

    }

    /// <summary>
    /// Empty your current hand
    /// </summary>
    public void EmptyHand()
    {
        CurrentHand.Clear();
    }

    /// <summary>
    /// Shuffle a specified deck
    /// </summary>
    /// <param name="list"></param>
    public void DeckShuffle(ref List<CelestialBody> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CelestialBody temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void SetActive()
    {

    }

    public void Play()
    {

    }

    public void Buy()
    {
        // buy stuff

        // shuffle draw pile
        DeckShuffle(ref MainDeck);
    }

}

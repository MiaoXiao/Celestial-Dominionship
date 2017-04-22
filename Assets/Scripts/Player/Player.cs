using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    List<Celest> CurrentHand;
    List<Celest> Deck;
    List<Celest> Discard;
    //Grid Field;

    public int Dust;
    public int buysAvailible;

    public delegate void Passives();
    public Passives passives;

    private void Display()
    {
       
    }

    public void Draw(int bonusCards = 0)
    {
        int drawCards = 5 + bonusCards;
        while (Deck.Count > 0 && drawCards > 0)
        {
            CurrentHand.Add(Deck[0]);
            Deck.RemoveAt(0);
            drawCards--;
        }
    }

    public void EmptyHand()
    {
        CurrentHand.Clear();
    }

    public void DeckShuffle(ref List<Celest> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Celest temp = list[i];
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
        DeckShuffle(ref Deck);
    }

}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    private int score;
    private int mana;
    private int multiplier;
    private List<Card> deck;
    private List<Card> hand;
    private List<Card> graveyard;

    public Player()
    {
        score = 0;
        mana = 0;
        multiplier = 0;
        deck = new List<Card>();
        hand = new List<Card>();
        graveyard = new List<Card>();
    }

    public void draw()
    {
        int nb = (int)Random.Range(0, deck.Count-1);
        hand.Add(deck[nb]);
        deck.Remove(deck[nb]);
    }
}

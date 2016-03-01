using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    private int score;
    private int mana;
    private int multiplier;
    private List<Dice> dices;
    private List<Card> deck;
    private List<Card> hand;
    private List<Card> graveyard;

    public Player()
    {
        score = 0;
        mana = 0;
        multiplier = 1;
        dices = new List<Dice>();
        deck = new List<Card>();
        hand = new List<Card>();
        graveyard = new List<Card>();
    }

    public void Draw()
    {
        int nb = (int)Random.Range(0, deck.Count-0.5f);
        hand.Add(deck[nb]);
        deck.Remove(deck[nb]);
    }

    public void AddMana(int value)
    {
        mana += value;
    }

    public void EndOfTurn()
    {
        multiplier = 1;
        mana = 0;
    }
}

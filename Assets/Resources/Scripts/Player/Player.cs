using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player
{
    private int score;
    private int mana;
    private int multiplier;
    public Dice[] dices;
    private List<Card> deck;
    private List<Card> hand;
    private List<Card> graveyard;

    public Player()
    {
        score = 0;
        mana = 0;
        multiplier = 1;
        dices = new Dice[3];
        deck = new List<Card>();
        hand = new List<Card>();
        graveyard = new List<Card>();
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

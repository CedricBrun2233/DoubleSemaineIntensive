﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Player : MonoBehaviour
{
    private int score;
    private int mana;
    private int multiplier;
    [HideInInspector]
    public Dice[] dices;
    private List<Card> hand;

    public Player()
    {
        score = 0;
        mana = 0;
        multiplier = 1;
        dices = new Dice[3];
        for(int i = 0; i < 3; i++)
        {
            dices[i] = new Dice();
        }
        hand = new List<Card>();
    }

    public void AddMana(int value)
    {
        mana += value;
    }
    public void RollDice()
    {
        foreach (Dice dice in dices)
        {
            //dice.RollDice();
        }
    }

    public int getScore()
    {
        return score;
    }

    public void AddCardInHand(Card card)
    {
        hand.Add(card);
    }

    public void RemoveCardInHand(Card card)
    {
        hand.Remove(card);
    }

    public void EndOfTurn()
    {
        multiplier = 1;
        mana = 0;
    }

    public int getHandSize()
    {
        return hand.Count;
    }

    public List<Card> GetHand()
    {
        return hand;
    }

    public void Cast(Card card, List<GameObject> targets)
    {
        card.Cast(targets);
        hand.Remove(card);
    }
}
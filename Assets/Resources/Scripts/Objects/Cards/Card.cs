using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Card : MonoBehaviour
{
    protected string cardName;
    protected int energy;

    public Card(int energy, string name)
    {
        this.energy = energy;
        cardName = name;
    }

    public string GetName()
    {
        return cardName;
    }

    public int GetEnergy()
    {
        return energy;
    }

    public abstract void Cast(List<GameObject> targets);
}

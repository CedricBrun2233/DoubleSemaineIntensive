using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour
{
    private string cardName;
    private int energy;

    public Card(int energy, string name)
    {
        this.energy = energy;
        cardName = name;
    }

    public string getName()
    {
        return cardName;
    }

    public int getEnergy()
    {
        return energy;
    }
}

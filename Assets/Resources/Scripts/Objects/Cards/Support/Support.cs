using UnityEngine;
using System.Collections;

public class Support : Card
{
    private Dice target;

    public Support(int energy, string name, Dice target) : base(energy, name)
    {
        this.target = target;
    }
}

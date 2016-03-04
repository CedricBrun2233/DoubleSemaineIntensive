using UnityEngine;
using System.Collections;

public abstract class Destruction : Card
{
    protected float force;

    public Destruction(int energy, string name, float force) : base(energy, name)
    {
        this.force = force;
    }
}

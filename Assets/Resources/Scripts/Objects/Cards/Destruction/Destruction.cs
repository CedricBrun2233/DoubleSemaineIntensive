using UnityEngine;
using System.Collections;

public class Destruction : Card
{
    private float force;

    public Destruction(int energy, string name, float force) : base(energy, name)
    {
        this.force = force;
    }
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vortex : Destruction
{
    public float radius;

    public Vortex(float radius, int energy, int force) : base (energy, "Seisme", force)
    {
        this.radius = radius;
    }

    public override void Cast(List<GameObject> targets)
    {

    }
}

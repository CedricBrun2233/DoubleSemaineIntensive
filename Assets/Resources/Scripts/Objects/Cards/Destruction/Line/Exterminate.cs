using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Exterminate : Destruction
{
    public float radius;

    public Exterminate(float radius, int energy, string name, int force) : base (energy, name, force)
    {
        this.radius = radius;
    }

    public override void Cast(List<GameObject> targets)
    {

    }
}

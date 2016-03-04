using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BombeH : Destruction
{
    public float radius;

    public BombeH(float radius, int energy, int force) : base (energy, "BombeH", force)
    {
        this.radius = radius;
    }

    public override void Cast(List<GameObject> targets)
    {

    }
}

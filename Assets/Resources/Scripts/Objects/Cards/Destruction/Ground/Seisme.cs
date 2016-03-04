using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Seisme : Destruction
{

    public Seisme(int energy, int force) : base (energy, "Seisme", force)
    {

    }

    public override void Cast(List<GameObject> targets)
    {

    }
}

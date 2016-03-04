using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FireBall : Destruction
{
    public float radius;
    public float speed;

    public FireBall(float radius, float speed, int energy, string name, int force) : base (energy, name, force)
    {
        this.radius = radius;
        this.speed = speed;
    }

    public override void Cast(List<GameObject> targets)
    {

    }
}

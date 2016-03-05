using UnityEngine;
using System.Collections;

public class FireBall : Destruction
{
    public float radius;
    public float speed;

    public FireBall(float radius, float speed, int energy, string name, int force) : base (energy, name, force)
    {
        this.radius = radius;
        this.speed = speed;
    }

    void OnCollisionEnter(Collision col)
    {
        //Bordel de Valentin
    }


}

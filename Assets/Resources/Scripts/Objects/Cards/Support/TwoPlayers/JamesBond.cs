using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class JamesBond : Support
{
    public JamesBond(int energy) : base(energy, "JamesBond")
    {

    }

    public override void Cast(List<GameObject> targets)
    {
        Player caster = targets[0].GetComponent<Player>();
        Player target = targets[1].GetComponent<Player>();
        
        Card cardPlayer2 = target.GetHand()[UnityEngine.Random.Range(0, target.getHandSize())];
        caster.GetHand().Add(cardPlayer2);
        target.GetHand().Remove(cardPlayer2);
    }

    public override Card Copy()
    {
        return new JamesBond(energy);
    }
}

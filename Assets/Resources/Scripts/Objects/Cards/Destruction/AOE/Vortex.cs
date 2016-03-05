using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vortex : Destruction
{
	public float radius;

	public Vortex (float radius, int energy, float force) : base (energy, "Seisme", force)
	{
		this.radius = radius;
	}

	public override void Cast (List<GameObject> targets)
	{
		GameObject dice = targets [0];

		Collider[] co = Physics.OverlapSphere (dice.transform.position, 15f);
		foreach (Collider currentCo in co) {
			if (currentCo.tag == "needPhysics") {
				currentCo.GetComponent<Building> ().bump ();
				currentCo.GetComponent<Building> ().changeWeight ();
				currentCo.GetComponent<Rigidbody> ().AddExplosionForce (-350f * 400 * force, dice.transform.position, 15f);
			}
		}
		XInput.instance.useVibe (0, 0.5f, 1, 1);
		dice.GetComponent<Rigidbody> ().AddExplosionForce (450f, dice.transform.position, 15f);

	}

	public override Card Copy ()
	{
		return new Vortex (radius, energy, force);
	}
}

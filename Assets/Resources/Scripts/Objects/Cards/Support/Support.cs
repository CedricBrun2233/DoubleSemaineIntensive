using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Support : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
=======
public class Support : Card
{
    private Dice target;

    public Support(int energy, string name, Dice target) : base(energy, name)
    {
        this.target = target;
    }
>>>>>>> Cedric
}

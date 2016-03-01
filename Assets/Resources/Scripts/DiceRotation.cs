using UnityEngine;
using System.Collections;

public class DiceRotation : MonoBehaviour {

    Rigidbody rb;
    Vector3 position;
    public float force = 300f;
    bool canDraw = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		StartCoroutine("checkStill");
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = Vector3.up * force;
            rb.AddForce(direction);
            transform.rotation = Random.rotation;
			StopCoroutine("checkStill");
			StartCoroutine("checkStill");
        }

		
    }

	IEnumerator checkStill()
	{		
		yield return new WaitForSeconds (0.1f);
		while(position != transform.position)
		{
			position = transform.position;
			yield return new WaitForSeconds (0.1f);
		}
		GetDiceCount();
		yield return null;
	}

	void GetDiceCount()
	{
		int diceCount;
		if (Vector3.Dot (transform.forward, Vector3.up)>0.5f)
			diceCount = 4;
		else if (Vector3.Dot (-transform.forward, Vector3.up)>0.5f)
			diceCount = 3;
		else if (Vector3.Dot (transform.up, Vector3.up)>0.5f)
			diceCount = 1;
		else if (Vector3.Dot (-transform.up, Vector3.up)>0.5f)
			diceCount = 6;
		else if (Vector3.Dot (transform.right, Vector3.up)>0.5f)
			diceCount = 2;
		else if (Vector3.Dot (-transform.right, Vector3.up)>0.5f)
			diceCount = 5;
		else diceCount = 0;
		Debug.Log ("diceCount :" + diceCount);
	}
	//- See more at: http://www.theappguruz.com/blog/roll-a-dice-unity-3d#sthash.DRW12vYS.dpuf
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Dice : MonoBehaviour {

    Rigidbody rb;
    Vector3 position;
    public float force = 300f;
    public int nbRebond = 5;
    int result;
    bool canDraw = true;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //StartCoroutine("checkStill");
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Badaboum();
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Tilt();
        }

		
    }

	public IEnumerator checkStill()
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
		if (Vector3.Dot (transform.forward, Vector3.up)>0.5f)
            result = 4;
		else if (Vector3.Dot (-transform.forward, Vector3.up)>0.5f)
            result = 3;
		else if (Vector3.Dot (transform.up, Vector3.up)>0.5f)
            result = 1;
		else if (Vector3.Dot (-transform.up, Vector3.up)>0.5f)
            result = 6;
		else if (Vector3.Dot (transform.right, Vector3.up)>0.5f)
            result = 2;
		else if (Vector3.Dot (-transform.right, Vector3.up)>0.5f)
            result = 5;
		else result = 0;
        TurnManager.instance.addValor(result);
	}

    public int GetResult()
    {
        return result;
    }

    void Badaboum()
    {
        Collider[] co = Physics.OverlapSphere(transform.position, 15f);
        foreach(Collider currentCo in co)
        {
            if (currentCo.tag == "needPhysics")
            {
                /*Transform go = currentCo.transform.parent;

                for(int i = 0; i < go.childCount;i++)
                {
                    go.GetChild(i).GetComponent<Building>().bump();
                    Debug.Log("lol");
                }*/
               
                currentCo.GetComponent<Building>().bump();
                currentCo.GetComponent<Building>().changeWeight();
                currentCo.GetComponent<Rigidbody>().AddExplosionForce(450f, transform.position, 15f);
                
            }
        }
        XInput.instance.useVibe(0, 0.5f, 1, 1);
        rb.AddExplosionForce(450f, transform.position, 15f);
    }

    void Tilt()
    {
        float X = Random.Range(-1f, 1f);
        float Z = Random.Range(-1f, 1f);
        Vector3 displacment = new Vector3(X, 0, Z);
        displacment.Normalize();
        rb.AddForce((displacment+Vector3.up)*200);
        Debug.Log(displacment);
        XInput.instance.useVibe(0, 0.5f, 1, 1);
    }

    void OnCollisionEnter(Collision col)
    {
        if(nbRebond != 0)
        {
            ContactPoint contact = col.contacts[0];
            Vector3 direction =transform.position - contact.point;
            direction.Normalize();
            rb.AddForce(direction * 100 * nbRebond);
            nbRebond--;
        }

        /*if (col.gameObject.tag == "needPhysics")
        {

            GameObject dad = col.transform.parent.gameObject;
            List<GameObject> childs = new List<GameObject>();
            for (int i = 0; i < dad.transform.childCount; i++)
            {
                childs.Add(dad.transform.GetChild(i).gameObject);
            }
            foreach (GameObject go in childs)
            {
                go.AddComponent<BoxCollider>();
                go.AddComponent<Rigidbody>();
                go.tag = "physicsAvailable";
            }
        }*/
    }
}

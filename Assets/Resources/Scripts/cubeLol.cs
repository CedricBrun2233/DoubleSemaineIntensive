using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cubeLol : MonoBehaviour
{
    Rigidbody rb;
    public int force = 10;
    public AudioClip[] boing;
    AudioSource AS;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        AS = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	   /* if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * force*10f);

        }*/
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.right * force);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(-Vector3.right * force);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector3.forward * force);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddForce(-Vector3.forward * force);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "needPhysics")
        {
            GameObject dad = col.transform.parent.gameObject;
            List<GameObject> childs = new List<GameObject>();
            for (int i = 0; i < dad.transform.childCount; i++)
            {
                childs.Add(dad.transform.GetChild(i).gameObject);
                childs[i].AddComponent<BoxCollider>();
                childs[i].AddComponent<Rigidbody>();
                childs[i].tag = "physicsAvailable";
            }
        }
    }
}

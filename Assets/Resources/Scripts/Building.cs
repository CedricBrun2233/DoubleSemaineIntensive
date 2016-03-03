using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour {

    Vector3 position;
    Rigidbody rb;
    Vector3 initialPosition;
	// Use this for initialization
	void Awake () {
        initialPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (name != "Box001")
        {
            if(collision.gameObject.tag == "Ground")
            {
                Destroy(gameObject, 2f);
            }
        }


        if (collision.relativeVelocity.magnitude > 2)
        {
            //bruit de fracas
        }
    }

    public void bump()
    {
        rb.isKinematic = false;
        StartCoroutine("checkStill");
    }

    public void changeWeight()
    {
        Invoke("reallyChangeWeight", 1f);
    }

    void reallyChangeWeight()
    {
        rb.mass -= 0.5f;
    }

    public IEnumerator checkStill()
    {
        yield return new WaitForSeconds(0.1f);
        while (position != transform.position)
        {
            position = transform.position;
            yield return new WaitForSeconds(0.3f);
        }
        if(name == "Box001")
        {
            if(Vector3.Distance(transform.position, initialPosition)>1)
            {
                Destroy(gameObject, 2f);
            }
        }
        rb.isKinematic = true;
        yield return null;
    }
}

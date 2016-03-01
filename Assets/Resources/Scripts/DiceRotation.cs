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
	}
	
	// Update is called once per frame
	void Update () {
	
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direction = Vector3.up * force;
            rb.AddForce(direction);
            transform.rotation = Random.rotation;
            //StartCoroutine("Test");
        }
        Debug.Log("position X : " + (transform.rotation.x * Mathf.Rad2Deg) + ",  position Z : " + (transform.rotation.y* Mathf.Rad2Deg ));
    }

    IEnumerator Test()
    {
        if (transform.position == position)
        {
            Debug.Log("position X : " + (int)(transform.rotation.x) + ",  position Z : " + (int)(transform.rotation.z));
            yield return null;
        }
        else
        {
            position = transform.position;
            yield return new WaitForSeconds(0.1f);
        }
    }

}

using UnityEngine;
using System.Collections;

public class testdodo : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GetComponent<Rigidbody>().Sleep();
    }
}

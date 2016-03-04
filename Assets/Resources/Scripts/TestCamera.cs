using UnityEngine;
using System.Collections;

public class TestCamera : MonoBehaviour {

    public GameObject[] dices;

	// Use this for initialization
	void Start () {
        SelectDices();
	}
	

    void SelectDices()
    {
        GameObject[] farDices = new GameObject[2];
        float[] dists = new float[3];
        dists[0] = Vector3.Distance(dices[0].transform.position, dices[1].transform.position);
        dists[1] = Vector3.Distance(dices[2].transform.position, dices[1].transform.position);
        dists[2] = Vector3.Distance(dices[2].transform.position, dices[0].transform.position);
        if (dists[0] > dists[1] && dists[0] > dists[2])
        {
            farDices[0] = dices[0];
            farDices[1] = dices[1];
        }
        else if (dists[1] > dists[2])
        {
            farDices[0] = dices[1];
            farDices[1] = dices[2];
        }
        else
        {
            farDices[0] = dices[0];
            farDices[1] = dices[2];
        }
        GetPosition(farDices);
    }

    void GetPosition(GameObject[] farDices)
    {
        Vector3 center = (farDices[0].transform.position + farDices[1].transform.position) / 2;
        transform.position = new Vector3(center.x, transform.position.y,center.z);
        transform.LookAt(new Vector3(farDices[0].transform.position.x, transform.position.y, farDices[0].transform.position.z));
        transform.Rotate(0, 90, 0);
        transform.Translate(transform.up * Vector3.Distance(farDices[0].transform.position, farDices[1].transform.position));
        transform.LookAt(getMiddleOfThree());
    }

    Vector3 getMiddleOfThree()
    {
        /*float x = (dice[0].transform.position.x + dice[1].transform.position.x + dice[2].transform.position.x) / 3;
        float y = (dice[0].transform.position.y + dice[1].transform.position.y + dice[2].transform.position.y) / 3;
        float z = (dice[0].transform.position.z + dice[1].transform.position.z + dice[2].transform.position.z) / 3;
        Vector3 look = new Vector3(x, y, z);*/
        Vector3 look = (dices[0].transform.position + dices[1].transform.position + dices[2].transform.position) / 3;
        return look;
    }
}

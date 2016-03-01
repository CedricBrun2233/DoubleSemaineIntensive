using UnityEngine;
using System.Collections;

public class Dice : MonoBehaviour
{
    public void rollDice()
    {
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 0));
    }

    public int GetResult()
    {
        //Calcun de val pour les faces
        return 0;
    }
}

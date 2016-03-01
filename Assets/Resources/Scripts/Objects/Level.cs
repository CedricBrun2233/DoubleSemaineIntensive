using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour
{
    int number;

	// Use this for initialization
	public Level (int numberLevel)
    {
        number = numberLevel;
	}

    public int getNumberLevel()
    {
        return number;
    }
}

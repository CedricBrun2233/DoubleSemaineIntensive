using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    static GameManager instance;

    List<bool> levelsFinished;

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this);
	}

    public static GameManager GetInstance()
    {
        if (instance = null)
        {
            instance = new GameManager();
        }
        return instance;
    }
    
    void Update ()
    {
	
	}

    public void Lose()
    {

    }
    public void Win(int numberLevel)
    {
        levelsFinished[numberLevel] = true;
    }
}

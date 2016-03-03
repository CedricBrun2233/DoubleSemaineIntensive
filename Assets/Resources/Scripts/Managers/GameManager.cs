using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    // Use this for initialization
    void Awake ()
    { 
        DontDestroyOnLoad(this);
        instance = this;
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

    }

}

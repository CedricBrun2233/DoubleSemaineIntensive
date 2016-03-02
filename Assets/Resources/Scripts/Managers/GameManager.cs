using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isTurnPlayer1;

    // Use this for initialization
    void Awake ()
    {
        isTurnPlayer1 = true;
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
	    if(Application.loadedLevel == 2)
        {
            if(isTurnPlayer1)
            {
                PlayerManager.GetInstance().PlayTurn(isTurnPlayer1);
                isTurnPlayer1 = false;
            }
            else
            {
                PlayerManager.GetInstance().PlayTurn(isTurnPlayer1);
                isTurnPlayer1 = true;
            }
        }

	}

    public void Lose()
    {

    }
    public void Win(int numberLevel)
    {

    }

}

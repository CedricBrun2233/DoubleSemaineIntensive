using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [HideInInspector]
    public int currentPlayer;

    public GameObject UIHandPlayer1;
    public GameObject UIHandPlayer2;

    void Awake ()
    {
        instance = this;
	}
    

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            instance = new UIManager();
        }
        return instance;
    }

    public void HideAll()
    {
        UIHandPlayer1.SetActive(false);
        UIHandPlayer2.SetActive(false);
    }
    public void printHandPlayer()
    {
        HideAll();
        if(currentPlayer == 1)
        {
            UIHandPlayer1.SetActive(true);
        }
        else
        {
            UIHandPlayer2.SetActive(true);
        }
    }

    void Update ()
    {
	
	}
}

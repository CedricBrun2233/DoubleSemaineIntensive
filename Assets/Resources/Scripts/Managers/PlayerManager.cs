using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Player player1;
    private Player player2;
    private GameObject GOPlayer1;
    private GameObject GOPlayer2;

    void Awake()
    {
        instance = this;
        GOPlayer1 = Instantiate(Resources.Load("Player")) as GameObject;
        player1 = GOPlayer1.GetComponent<Player>();
        GOPlayer2 = Instantiate(Resources.Load("Player")) as GameObject;
        player2 = GOPlayer2.GetComponent<Player>();

        StartCoroutine("InitializeManager");
    }

    public static PlayerManager GetInstance()
    {
        if (instance = null)
        {
            instance = new PlayerManager();
        }
        return instance;
    }

    IEnumerator InitializeManager()
    {
        yield return new WaitForEndOfFrame();

        TurnManager.GetInstance().player1 = this.player1;
        TurnManager.GetInstance().player2 = this.player2;
    }
}

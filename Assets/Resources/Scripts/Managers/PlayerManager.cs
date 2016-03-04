using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Player player1;
    private Player player2;
    private GameObject GOplayer1;
    private GameObject GOplayer2;

    void Awake()
    {
        instance = this;
        GOplayer1 = Instantiate(Resources.Load("Player")) as GameObject;
        player1 = GOplayer1.GetComponent<Player>();
        GOplayer2 = Instantiate(Resources.Load("Player")) as GameObject;
        player2 = GOplayer2.GetComponent<Player>();

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

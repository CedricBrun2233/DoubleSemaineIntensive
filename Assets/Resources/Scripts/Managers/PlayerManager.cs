using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Player player1;
    private Player player2;

    void Awake()
    {
        instance = this;
        player1 = new Player();
        player2 = new Player();

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

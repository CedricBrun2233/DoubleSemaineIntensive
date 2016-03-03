using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TurnManager : MonoBehaviour
{
    public static TurnManager instance;

    [HideInInspector]
    public Player player1;
    [HideInInspector]
    public Player player2;

    private List<Card> cardsInDraft;
    private List<int> dicesValor;
    
    private bool turnPlayer1Ended;
    private bool turnPlayer2Ended;
    private bool globalTurnEnded;
    private bool globalTurnPlayer1Ended;
    private bool globalTurnPlayer2Ended;
    public bool cardSelected;

    private Player currentPlayer;

    public Camera globalCamera;
    [HideInInspector]
    public GameObject playerGameObject;

    void Awake ()
    {
        cardsInDraft = new List<Card>();
        dicesValor = new List<int>();

        instance = this;
        turnPlayer1Ended = false;
        turnPlayer2Ended = false;
        globalTurnEnded = false;
        globalTurnPlayer1Ended = false;
        globalTurnPlayer2Ended = false;
        cardSelected = false;
       // globalCamera = Camera.main;
        StartCoroutine("StartGame");
    }
	
    public static TurnManager GetInstance()
    {
        if (instance == null)
        {
            instance = new TurnManager();
        }
        return instance;
    }

    public void EndOfTurn()
    {
        if (currentPlayer == player1)
        {
            currentPlayer = player2;
        }
        else
        {
            currentPlayer = player1;
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0.2f);

        currentPlayer = player1;
        StartCoroutine(Game());
    }

    public IEnumerator Game()
    {
        yield return new WaitForEndOfFrame();
        ChangeUI();
        StartCoroutine(Turn());
        while (!turnPlayer1Ended)
            yield return new WaitForEndOfFrame();
        ChangeUI();
        StartCoroutine(Turn());
        while (!turnPlayer2Ended)
            yield return new WaitForEndOfFrame();
        StartCoroutine(GlobalTurn());
        while (!globalTurnEnded)
            yield return new WaitForEndOfFrame();
    }

    void addCameraForPlayer()
    {
        playerGameObject = Instantiate(Resources.Load("GA/Prefabs/MapCenter", typeof(GameObject))) as GameObject;
        playerGameObject.transform.position = Vector3.zero;
        globalCamera.enabled = false;
        
    }

    public void addValor(int valor)
    {
        dicesValor.Add(valor);
    }

    void valorOk()
    {
        int valor = dicesValor[0] + dicesValor[1] + dicesValor[2];
        dicesValor.Clear();
        currentPlayer.AddMana(valor);
        Debug.Log(valor);
        GameObject camera = playerGameObject.transform.GetChild(0).gameObject;
        camera.transform.parent = null;
        camera.GetComponent<TestCamera>().enabled = true;
        camera.GetComponent<TestCamera>().dices = camera.GetComponent<CameraScript>().dices;
        camera.GetComponent<CameraScript>().enabled = false;
    }

    IEnumerator Turn()
    {
        addCameraForPlayer();
        
        while(dicesValor.Count !=3) {
            yield return new WaitForEndOfFrame();
        }
        valorOk();/*
        while (!cardSelected)
        {
            yield return new WaitForEndOfFrame();
        }*/
        //Selection du Spell a lancer
        cardSelected = false;
        if (currentPlayer == player1)
            turnPlayer1Ended = true;
        else
            turnPlayer2Ended = true;

        currentPlayer.EndOfTurn();
        EndOfTurn();
        yield return null;
    }

    public void SelectCard(Card card)
    {
        cardSelected = true;
        //Cast un Spell
        if(!turnPlayer2Ended)
        {
            currentPlayer.Cast(card);
            currentPlayer.RemoveCardInHand(card);
        }
        //En Draft
        else
        {
            currentPlayer.AddCardInHand(card);
            cardsInDraft.Remove(card);
        }
    }

    public void ChangeUI()
    {
        if (currentPlayer == player1)
        {
            UIManager.GetInstance().currentPlayer = 1;
        }
        else
        {
            UIManager.GetInstance().currentPlayer = 2;
        }
    }

    IEnumerator GlobalTurn()
    {
        int nbCard = (5 - player1.getHandSize()) + (5 - player2.getHandSize());
        //SpawnCard a choisir
        if(player2.getScore() < player1.getScore())
        {
            currentPlayer = player2;
        }
        /*
        while(player1.getHandSize() < 5 && player2.getHandSize() < 5)
        {
            while (!cardSelected)
                yield return new WaitForEndOfFrame();

            if (currentPlayer == player1)
                currentPlayer = player2;
            else
                currentPlayer = player1;
            Debug.Log("SizeHandP1 : " + player1.getHandSize());
            Debug.Log("SizeHandP2 : " + player2.getHandSize());
            yield return new WaitForEndOfFrame();
        }*/
        globalTurnEnded = true;
        yield return null;
    }

    void Update()
    {
        if (globalTurnEnded)
        {
            StartCoroutine(Game());
            turnPlayer1Ended = false;
            turnPlayer2Ended = false;
            globalTurnEnded = false;
        }
    }
}
 
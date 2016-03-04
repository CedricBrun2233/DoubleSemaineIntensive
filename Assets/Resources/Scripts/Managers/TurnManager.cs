﻿using UnityEngine;
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
    [HideInInspector]
    public bool cardSelected;

    [HideInInspector]
    public Player currentPlayer;

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

    public List<Card> getHandCurrentPlayer()
    {
        return currentPlayer.GetHand();
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
        Debug.Log("GLobalTurn");
        StartCoroutine(GlobalTurn());
        while (!globalTurnEnded)
            yield return new WaitForEndOfFrame();
        Debug.Log("TUrnP1");
        StartCoroutine(Turn());
        while (!turnPlayer1Ended)
            yield return new WaitForEndOfFrame();
        Debug.Log("TurnP2");

        StartCoroutine(Turn());
        while (!turnPlayer2Ended)
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


        killCamera();
        currentPlayer.EndOfTurn();
        EndOfTurn();
        yield return null;
    }

    void killCamera()
    {
        globalCamera.enabled = true;
        Destroy(playerGameObject);
    }

    public void SelectCard(Card card)
    {
        cardSelected = true;
        //Cast un Spell
        if(!turnPlayer2Ended)
        {
            List<GameObject> targets = new List<GameObject>();
            switch(card.name)
            {
                case "JamesBond":
                    if (currentPlayer == player1)
                    {
                        targets.Add(player1.gameObject);
                        targets.Add(player2.gameObject);
                    }
                    else
                    {
                        targets.Add(player2.gameObject);
                        targets.Add(player1.gameObject);
                    }
                    break;
                case "Seisme":
                    if (currentPlayer == player1)
                    {
                        targets.Add(player1.dices[0].gameObject);
                    }
                    else
                    {
                        targets.Add(player2.dices[0].gameObject);
                    }
                    break;
                case "BombeH":
                    if (currentPlayer == player1)
                    {
                        targets.Add(player1.dices[0].gameObject);
                    }
                    else
                    {
                        targets.Add(player2.dices[0].gameObject);
                    }
                    break;
                case "Vortex":
                    if (currentPlayer == player1)
                    {
                        targets.Add(player1.dices[0].gameObject);
                    }
                    else
                    {
                        targets.Add(player2.dices[0].gameObject);
                    }
                    break;
                case "Tilt":
                    if (currentPlayer == player1)
                    {
                        targets.Add(player1.dices[0].gameObject);
                        targets.Add(player1.dices[1].gameObject);
                        targets.Add(player1.dices[2].gameObject);
                    }
                    else
                    {
                        targets.Add(player2.dices[0].gameObject);
                        targets.Add(player2.dices[1].gameObject);
                        targets.Add(player2.dices[2].gameObject);
                    }
                    break;
            }
            currentPlayer.Cast(card, targets);
            currentPlayer.RemoveCardInHand(card);
        }
        //En Draft
        else
        {
            currentPlayer.AddCardInHand(card);
            cardsInDraft.Remove(card);
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
        if (turnPlayer2Ended)
        {
            StartCoroutine(Game());
            globalTurnEnded = false;
            turnPlayer1Ended = false;
            turnPlayer2Ended = false;
        }
    }
}
 
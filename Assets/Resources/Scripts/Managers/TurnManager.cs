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
    
    private bool turnPlayer1Ended;
    private bool turnPlayer2Ended;
    private bool globalTurnEnded;
    private bool globalTurnPlayer1Ended;
    private bool globalTurnPlayer2Ended;
    public bool cardSelected;

    private Player currentPlayer;

    void Awake ()
    {
        cardsInDraft = new List<Card>();

        instance = this;
        turnPlayer1Ended = false;
        turnPlayer2Ended = false;
        globalTurnEnded = false;
        globalTurnPlayer1Ended = false;
        globalTurnPlayer2Ended = false;
        cardSelected = false;

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

    IEnumerator Turn()
    {
        //RollDice();
        //while(!etape1) { }
        //foreach(Dice dice in dices)
        //AddMana(dice.GetResult());
        while (!cardSelected)
        {
            yield return new WaitForEndOfFrame();
        }
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

        while(player1.getHandSize() < 5 && player2.getHandSize() < 5)
        {
            while (!cardSelected)
                yield return new WaitForEndOfFrame();

            if (currentPlayer == player1)
                currentPlayer = player2;
            else
                currentPlayer = player1;
            Debug.Log(player1.getHandSize());
            Debug.Log(player2.getHandSize());
            yield return new WaitForEndOfFrame();
        }
        globalTurnEnded = true;
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
 
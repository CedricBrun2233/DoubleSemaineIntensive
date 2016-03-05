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
	[HideInInspector]
	public bool cardSelected;

	[HideInInspector]
	public Player currentPlayer;

	public Camera globalCamera;
	[HideInInspector]
	public GameObject playerGameObject;

	void Awake ()
	{
		cardsInDraft = new List<Card> ();
		dicesValor = new List<int> ();

		instance = this;
		turnPlayer1Ended = false;
		turnPlayer2Ended = false;
		globalTurnEnded = false;
		cardSelected = false;
		// globalCamera = Camera.main;
		StartCoroutine ("StartGame");
	}

	public static TurnManager GetInstance ()
	{
		if (instance == null) {
			instance = new TurnManager ();
		}
		return instance;
	}

	public List<Card> getHandCurrentPlayer ()
	{
		return currentPlayer.GetHand ();
	}

	public void EndOfTurn ()
	{
		if (currentPlayer == player1) {
			currentPlayer = player2;
		} else {
			currentPlayer = player1;
		}
	}

	IEnumerator StartGame ()
	{
		yield return new WaitForSeconds (0.2f);

		currentPlayer = player1;
		StartCoroutine (Game ());
	}

	public IEnumerator Game ()
	{
		yield return new WaitForEndOfFrame ();
		Debug.Log ("GLobalTurn");
		StartCoroutine (GlobalTurn ());
		while (!globalTurnEnded)
			yield return new WaitForEndOfFrame ();
		Debug.Log ("TUrnP1");
		StartCoroutine (Turn ());
		while (!turnPlayer1Ended)
			yield return new WaitForEndOfFrame ();
		Debug.Log ("TurnP2");
		StartCoroutine (Turn ());
		while (!turnPlayer2Ended)
			yield return new WaitForEndOfFrame ();
	}

	void addCameraForPlayer ()
	{
		playerGameObject = Instantiate (Resources.Load ("GA/Prefabs/MapCenter", typeof(GameObject))) as GameObject;
		playerGameObject.transform.position = Vector3.zero;
		globalCamera.enabled = false;
	}

	public void addValor (int valor)
	{
		dicesValor.Add (valor);
	}

	void valorOk ()
	{
		int valor = dicesValor [0] + dicesValor [1] + dicesValor [2];
		dicesValor.Clear ();
		currentPlayer.AddMana (valor);
		Debug.Log (valor);
		GameObject camera = playerGameObject.transform.GetChild (0).gameObject;
		camera.GetComponent<TestCamera> ().enabled = true;
		camera.GetComponent<TestCamera> ().dices = camera.GetComponent<CameraScript> ().dices;
		camera.GetComponent<CameraScript> ().enabled = false;

	}

	IEnumerator Turn ()
	{
		addCameraForPlayer ();
		Ui_Manager.Instance.GoToState (UiState.Positioning);
		InputManager.GetInstance ().inStartTurnPlayer = true;

		while (dicesValor.Count != 3) {
			yield return new WaitForEndOfFrame ();
		}
		valorOk ();/*
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
	}

	void killCamera ()
	{
		globalCamera.enabled = true;
		Destroy (playerGameObject);
	}


	public void SelectCard (Card card)
	{
		cardSelected = true;
		//Cast un Spell
		if (!turnPlayer2Ended) {
			List<GameObject> targets = new List<GameObject> ();
			/*switch (card.) {
			case "JamesBond":
				
				break;
			case "Seisme":
				
				break;
			case "BombeH":
				
				break;
			case "Vortex":
				
				break;
			case "Tilt":
				
				break;
			}*/
			if ((card as Vortex) != null) {
				if (currentPlayer == player1) {
					targets.Add (player1.dices [0].gameObject);
				} else {
					targets.Add (player2.dices [0].gameObject);
				}
			} else if ((card as Seisme) != null) {
				StartCoroutine ((card as Seisme).yollohSeisme ());
			} else if ((card as Tilt) != null) {
				if (currentPlayer == player1) {
					targets.Add (player1.dices [0].gameObject);
					targets.Add (player1.dices [1].gameObject);
					targets.Add (player1.dices [2].gameObject);
				} else {
					targets.Add (player2.dices [0].gameObject);
					targets.Add (player2.dices [1].gameObject);
					targets.Add (player2.dices [2].gameObject);
				}
			} else if ((card as JamesBond) != null) {
				if (currentPlayer == player1) {
					targets.Add (player1.gameObject);
					targets.Add (player2.gameObject);
				} else {
					targets.Add (player2.gameObject);
					targets.Add (player1.gameObject);
				}
			} else if ((card as BombeH) != null) {
				if (currentPlayer == player1) {
					targets.Add (player1.dices [0].gameObject);
				} else {
					targets.Add (player2.dices [0].gameObject);
				}
			}

			currentPlayer.Cast (card, targets);
			currentPlayer.RemoveCardInHand (card);
		}
		//En Draft

	}

	IEnumerator GlobalTurn ()
	{
		player1.AddCardInHand (new BombeH (0, 0, 0, CardManager.GetInstance ().image));
		player1.AddCardInHand (new BombeH (0, 0, 0, CardManager.GetInstance ().image));
		player1.AddCardInHand (new BombeH (0, 0, 0, CardManager.GetInstance ().image));

		int nbCard = (5 - player1.getHandSize ()) + (5 - player2.getHandSize ());

		//SpawnCard a choisir
		if (player2.getScore () < player1.getScore ()) {
			currentPlayer = player2;
		}

		for (int i = 0; i < nbCard; i++) {
			cardsInDraft.Add (CardManager.GetInstance ().GetRandomCard ());
		}
		Ui_Manager.Instance.setDraftCard (cardsInDraft);
		Ui_Manager.Instance.GoToState (UiState.Draft);
		while (player1.getHandSize () < 5 || player2.getHandSize () < 5) {
			//we wait for the card to be selected
			yield return new WaitForCardSelected ();

			currentPlayer.AddCardInHand (InputManager.GetInstance ().cardPreSelected);

			if (currentPlayer == player1 && player2.getHandSize () < 5) {
				currentPlayer = player2;
				Ui_Manager.Instance.DraftTogglePlayer (2);
			} else if (player1.getHandSize () < 5) {
				currentPlayer = player1;
				Ui_Manager.Instance.DraftTogglePlayer (1);
			}
			


			Debug.Log ("SizeHandP1 : " + player1.getHandSize ());
			Debug.Log ("SizeHandP2 : " + player2.getHandSize ());
			yield return new WaitForEndOfFrame ();
		}
		globalTurnEnded = true;
		yield return null;
	}

	void Update ()
	{
		if (turnPlayer2Ended) {
			StartCoroutine (Game ());
			globalTurnEnded = false;
			turnPlayer1Ended = false;
			turnPlayer2Ended = false;
		}
	}
}


class WaitForCardSelected : CustomYieldInstruction
{
	static public bool cardSelected = false;

	public override bool keepWaiting {
		get {
			if (cardSelected) {
				cardSelected = false;
				return false;
			}
			return true;
		}
	}

	public WaitForCardSelected ()
	{
		
	}
}

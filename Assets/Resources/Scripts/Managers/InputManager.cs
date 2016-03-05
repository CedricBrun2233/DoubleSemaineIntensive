using UnityEngine;
using System.Collections;
using System;

public enum GameState
{
	
}

public class InputManager : MonoBehaviour
{
	static InputManager instance;

	public Card cardPreSelected;
	public Dice dicePreSelected;

	public bool handActive;
	public bool inStartTurnPlayer;
	public bool inTacticalView;
	public bool inShootView;
	public bool diceSended;
	public bool inSelectSpell;
	public bool inSelectDice;
	public bool inCastSpell;
	public bool inDraft;

	void Awake ()
	{
		DontDestroyOnLoad (this);
		instance = this;

		//To UI
		handActive = false;
		inStartTurnPlayer = false;
		inTacticalView = false;
		inShootView = false;
		diceSended = false;
		inSelectSpell = false;
		inSelectDice = false;
		inCastSpell = false;

		//ToSelectDice&Card
		cardPreSelected = null;
		dicePreSelected = null;
	}

	public static InputManager GetInstance ()
	{
		if (instance == null) {
			instance = new InputManager ();
		}
		return instance;
	}

	public void OnPressButtonA ()
	{


		if (handActive || inTacticalView) {
			return;
		}

		if (inStartTurnPlayer) {
			inStartTurnPlayer = false;
			inShootView = true;
			//ChangeCamera
			Ui_Manager.Instance.GoToState (UiState.Throw);
			return;
		}
		if (inSelectDice) {
			inSelectDice = false;
			inCastSpell = true;
			//CastSpell
			return;
		}
		if (inSelectSpell) {
			inSelectSpell = false;
			inSelectDice = true;
			TurnManager.GetInstance ().SelectCard (cardPreSelected);
			Ui_Manager.Instance.GoToState (UiState.DiceSelect);
		}
	}

	public void OnPressButtonB ()
	{
		if (handActive) {
			handActive = false;
			if (inStartTurnPlayer)
				Ui_Manager.Instance.GoToState (UiState.Positioning);
			else
				Ui_Manager.Instance.GoToState (UiState.Throw);
			return;
		}
		if (inShootView) {
			//ChangeCamera
			inShootView = false;
			inStartTurnPlayer = true;
			Ui_Manager.Instance.GoToState (UiState.Positioning);
			return;
		}
		if (inSelectDice) {
			inSelectDice = false;
			inSelectSpell = true;
			Ui_Manager.Instance.GoToState (UiState.SpellSelect);
		}
	}

	public void OnPressButtonX ()
	{
		if (handActive) {
			return;
		}
		if (inTacticalView) {
			inTacticalView = false;
			//ChangeCamera
			if (inStartTurnPlayer) {
				Ui_Manager.Instance.GoToState (UiState.Positioning);
			} else if (inShootView) {
				Ui_Manager.Instance.GoToState (UiState.Throw);
			} else if (inSelectSpell) {
				Ui_Manager.Instance.GoToState (UiState.SpellSelect);
			} else if (inSelectDice) {
				Ui_Manager.Instance.GoToState (UiState.DiceSelect);
			}
			return;                
		}
		if (inStartTurnPlayer || inShootView || inSelectSpell || inSelectDice) {
			inTacticalView = true;
			//ChangeCamera
			Ui_Manager.Instance.GoToState (UiState.Tactical);
			return;
		}
	}

	public void OnPressButtonY ()
	{
		if (handActive) {
			handActive = false;
			if (inStartTurnPlayer)
				Ui_Manager.Instance.GoToState (UiState.Positioning);
			else
				Ui_Manager.Instance.GoToState (UiState.Throw);
			return;
		}
		if (inStartTurnPlayer || inShootView) {
			handActive = true;
			if (TurnManager.GetInstance ().currentPlayer == TurnManager.GetInstance ().player1)
				Ui_Manager.Instance.GoToState (UiState.HandJ1);
			else
				Ui_Manager.Instance.GoToState (UiState.HandJ2);
		}
	}

	public void OnPressButtonLB ()
	{
		if (handActive) {
			return;
		}
		if (inShootView) {
			//ChangeAngle
		}
	}

	public void OnPressButtonRB ()
	{
		if (handActive) {
			return;
		}
		if (inShootView) {
			//ChangeAngle
		}
	}

	void Update ()
	{/*
        if (Input.GetMouseButtonDown(0))
        {
            if(waitingSelectCard)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, 1000);
                if (hit.collider.gameObject.tag == "Card")
                {
                    selected = hit.collider.gameObject.GetComponent<Card>();
                    TurnManager.GetInstance().SelectCard(selected);
                }
            }
        }*/
		if (Input.GetButtonDown ("ButtonA")) {
			OnPressButtonA ();
		}
		if (Input.GetButtonDown ("ButtonB")) {
			OnPressButtonB ();
		}
		if (Input.GetButtonDown ("ButtonX")) {
			OnPressButtonX ();
		}
		if (Input.GetButtonDown ("ButtonY")) {
			OnPressButtonY ();
		}
		if (Input.GetButtonDown ("ButtonLB")) {
			OnPressButtonLB ();
		}
		if (Input.GetButtonDown ("ButtonRB")) {
			OnPressButtonRB ();
		}
	}
}

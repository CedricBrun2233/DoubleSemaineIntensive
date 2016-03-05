using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;

public enum UiElement
{
	RessourcesPanel = 0x01,
	YShowHand = 0x02,
	YShowDice = 0x03,
	XShowTacticView = 0x04,
	XShowBasicView = 0x05,
	PressBtnPanel = 0x06,
	PhaseTitle = 0x07,
	DraftCardPanel = 0x08,
	HandPlayer1 = 0x09,
	HandPlayer2 = 0x10,
	BToBack = 0x11,
}

public enum UiOptions
{
	Additive,
	Default,
	ForceHide,
}

public enum UiState
{
	Draft = UiElement.YShowHand | UiElement.PressBtnPanel | UiElement.DraftCardPanel,
	HandJ1 = UiElement.HandPlayer1 | UiElement.YShowHand | UiElement.PressBtnPanel,
	HandJ2 = UiElement.HandPlayer2 | UiElement.YShowHand | UiElement.PressBtnPanel,
	Positioning = UiElement.YShowHand | UiElement.XShowTacticView | UiElement.PressBtnPanel | UiElement.PhaseTitle,
	Tactical,
	Throw,
	SpellSelect,
	DiceSelect,
}

public class Ui_Manager : Singleton<Ui_Manager>
{
	private UiState m_state;

	public UiState State {
		get {
			return m_state;
		}
	}

	private EventSystem m_system;
	private TurnManager m_turnManager;
	private InputManager m_inputManager;

	#region Panels

	[SerializeField]
	private GameObject m_mainSlider;
	[SerializeField]
	private GameObject m_ressourcesPanel;
	[SerializeField]
	private GameObject m_yShowHand;
	[SerializeField]
	private GameObject m_yShowDice;
	[SerializeField]
	private GameObject m_xShowTacticView;
	[SerializeField]
	private GameObject m_xShowBasicView;
	[SerializeField]
	private GameObject m_pressBtnPanel;
	[SerializeField]
	private GameObject m_phaseTitle;
	[SerializeField]
	private GameObject m_draftCardPanel;
	[SerializeField]
	private GameObject m_selectCardPanel;
	[SerializeField]
	private GameObject m_handPlayer1;
	[SerializeField]
	private GameObject m_handPlayer2;
	[SerializeField]
	private GameObject m_bToBack;

	#endregion

	protected Ui_Manager ()
	{
		
	}

	// Use this for initialization
	void Start ()
	{
		m_mainSlider.SetActive (true);
		m_system = GameObject.FindObjectOfType<EventSystem> ();
		m_turnManager = TurnManager.GetInstance ();
		m_inputManager = InputManager.GetInstance ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void GoToState (UiState state)
	{
		Debug.Log ("[UI Manager] go to state : " + state);
		m_state = state;
		switch (state) {
		case UiState.Draft:
			OnDraftJ1 ();
			break;
		case UiState.HandJ1:
			OnHandJ1 ();
			break;
		case UiState.HandJ2:
			OnHandJ2 ();
			break;
		case UiState.Positioning:
			OnPositioning ();
			break;
		case UiState.Tactical:
			OnTactical ();
			break;
		case UiState.Throw:
			OnThrow ();
			break;
		case UiState.SpellSelect:
			OnSpellSelect ();
			break;
		case UiState.DiceSelect:
			OnDiceSelect ();
			break;
		default:
			break;
		}
	}

	#region State function

	private void hideAll ()
	{
		m_draftCardPanel.SetActive (false);
		m_handPlayer1.SetActive (false);
		m_handPlayer2.SetActive (false);
		//m_mainSlider.SetActive (false);
		m_phaseTitle.SetActive (false);
		m_pressBtnPanel.SetActive (false);
		m_ressourcesPanel.SetActive (false);
		m_selectCardPanel.SetActive (false);
		m_xShowBasicView.SetActive (false);
		m_xShowTacticView.SetActive (false);
		m_yShowDice.SetActive (false);
		m_yShowHand.SetActive (false);
		m_bToBack.SetActive (false);
	}

	private void OnDraftJ1 ()
	{
		hideAll ();
		//m_mainSlider.SetActive (true);
		m_yShowHand.SetActive (true);
		m_pressBtnPanel.SetActive (true);
		m_draftCardPanel.SetActive (true);

		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = 100;
		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = 100;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = 70;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = 70;
		m_system.SetSelectedGameObject (m_draftCardPanel.transform.GetChild (0).gameObject);

	}

	public void SetDraftCardNumber (int number)
	{
		for (int i = number; i < m_draftCardPanel.transform.childCount; i++) {
			m_draftCardPanel.transform.GetChild (i).gameObject.SetActive (false);
		}
	}

	public void setDraftCard (List<Card> draftCards)
	{
		Debug.Log (draftCards.Count);
		for (int i = 0; i < 10; i++) {
			if (i < draftCards.Count) {
				m_draftCardPanel.transform.GetChild (i).gameObject.SetActive (true);
				m_draftCardPanel.transform.GetChild (i).GetComponent<DraftCardUI> ().ActiveCard = draftCards [i];
			} else {
				m_draftCardPanel.transform.GetChild (i).gameObject.SetActive (false);
			}
		}
	}

	private void OnDraftJ2 ()
	{
		hideAll ();
		//m_mainSlider.SetActive (true);
		m_yShowHand.SetActive (true);
		m_pressBtnPanel.SetActive (true);
		m_draftCardPanel.SetActive (true);

		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = (m_turnManager.currentPlayer == m_turnManager.player2) ? 70 : 100;
		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = (m_turnManager.currentPlayer == m_turnManager.player2) ? 70 : 100;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = (m_turnManager.currentPlayer == m_turnManager.player1) ? 100 : 70;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = (m_turnManager.currentPlayer == m_turnManager.player1) ? 100 : 70;
	}

	private void OnHandJ1 ()
	{
		m_yShowHand.SetActive (false);
		m_pressBtnPanel.SetActive (false);
		m_handPlayer1.SetActive (true);
	}

	private void OnHandJ2 ()
	{
		m_yShowHand.SetActive (false);
		m_pressBtnPanel.SetActive (false);
		m_handPlayer2.SetActive (true);
	}

	private void OnPositioning ()
	{
		hideAll ();
		m_phaseTitle.SetActive (true);
		m_yShowHand.SetActive (true);
		m_xShowTacticView.SetActive (true);
		m_pressBtnPanel.SetActive (true);

		Color alpha = m_phaseTitle.GetComponent<Image> ().color;
		alpha.a = 0;
		m_phaseTitle.GetComponent<Image> ().color = alpha;

		m_phaseTitle.GetComponent<Image> ().DOKill ();
		m_phaseTitle.GetComponent<Image> ().DOFade (1, 2).SetEase (Ease.OutSine).SetLoops (2, LoopType.Yoyo).OnComplete (() => {
			m_phaseTitle.SetActive (false);
		});
	}

	private void OnTactical ()
	{
		hideAll ();
		m_phaseTitle.SetActive (true);
		m_yShowHand.SetActive (true);
		m_xShowBasicView.SetActive (true);
		m_pressBtnPanel.SetActive (true);

		Color alpha = m_phaseTitle.GetComponent<Image> ().color;
		alpha.a = 0;
		m_phaseTitle.GetComponent<Image> ().color = alpha;

		m_phaseTitle.GetComponent<Image> ().DOKill ();
		m_phaseTitle.GetComponent<Image> ().DOFade (1, 2).SetEase (Ease.OutSine).SetLoops (2, LoopType.Yoyo).OnComplete (() => {
			m_phaseTitle.SetActive (false);
		});
	}

	private void OnThrow ()
	{
		hideAll ();
		m_phaseTitle.SetActive (true);
		m_yShowHand.SetActive (true);
		m_xShowTacticView.SetActive (true);
		m_pressBtnPanel.SetActive (true);
		m_bToBack.SetActive (true);

		Color alpha = m_phaseTitle.GetComponent<Image> ().color;
		alpha.a = 0;
		m_phaseTitle.GetComponent<Image> ().color = alpha;

		m_phaseTitle.GetComponent<Image> ().DOKill ();
		m_phaseTitle.GetComponent<Image> ().DOFade (1, 2).SetEase (Ease.OutSine).SetLoops (2, LoopType.Yoyo).OnComplete (() => {
			m_phaseTitle.SetActive (false);
		});
	}

	private void OnSpellSelect ()
	{
		hideAll ();
		m_phaseTitle.SetActive (true);
		m_yShowHand.SetActive (true);
		m_xShowTacticView.SetActive (true);
		m_pressBtnPanel.SetActive (true);
		m_selectCardPanel.SetActive (true);

		Color alpha = m_phaseTitle.GetComponent<Image> ().color;
		alpha.a = 0;
		m_phaseTitle.GetComponent<Image> ().color = alpha;

		m_phaseTitle.GetComponent<Image> ().DOKill ();
		m_phaseTitle.GetComponent<Image> ().DOFade (1, 2).SetEase (Ease.OutSine).SetLoops (2, LoopType.Yoyo).OnComplete (() => {
			m_phaseTitle.SetActive (false);
		});
	}

	private void OnDiceSelect ()
	{
		hideAll ();
		m_phaseTitle.SetActive (true);
		m_yShowHand.SetActive (true);
		m_xShowTacticView.SetActive (true);
		m_pressBtnPanel.SetActive (true);

		Color alpha = m_phaseTitle.GetComponent<Image> ().color;
		alpha.a = 0;
		m_phaseTitle.GetComponent<Image> ().color = alpha;

		m_phaseTitle.GetComponent<Image> ().DOKill ();
		m_phaseTitle.GetComponent<Image> ().DOFade (1, 2).SetEase (Ease.OutSine).SetLoops (2, LoopType.Yoyo).OnComplete (() => {
			m_phaseTitle.SetActive (false);
		});
	}

	#endregion

	public void DraftCardSelect (DraftCardUI cardToAdd)
	{
		m_inputManager.cardPreSelected = cardToAdd.ActiveCard;
		WaitForCardSelected.cardSelected = true;
		cardToAdd.gameObject.SetActive (false);
		cardToAdd.transform.SetAsLastSibling ();
		m_system.SetSelectedGameObject (m_draftCardPanel.transform.GetChild (0).gameObject);
	}

	public void DraftTogglePlayer (int player)
	{
		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = (player == 2) ? 70 : 100;
		m_mainSlider.transform.FindChild ("J1 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = (player == 2) ? 70 : 100;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredWidth = (player == 1) ? 70 : 100;
		m_mainSlider.transform.FindChild ("J2 Panel").FindChild ("Panel").GetComponent<LayoutElement> ().preferredHeight = (player == 1) ? 70 : 100;
	}
}

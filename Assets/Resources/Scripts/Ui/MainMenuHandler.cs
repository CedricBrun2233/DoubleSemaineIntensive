using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenuHandler : MonoBehaviour
{
	[SerializeField]
	private EventSystem system;
	[SerializeField]
	private GameObject firstSelected;

	private CanvasGroup grp;


	// Use this for initialization
	void Start ()
	{
		grp = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Appear ()
	{
		grp.DOFade (1, 1).SetEase (Ease.InOutSine);
		system.SetSelectedGameObject (firstSelected);
	}

	public void ButtonSelect (GameObject button)
	{
		button.transform.DOLocalMoveZ (-0.5f, 0.5f);
	}

	public void ButtonDeselect (GameObject button)
	{
		button.transform.DOLocalMoveZ (0f, 0.5f);
	}
}

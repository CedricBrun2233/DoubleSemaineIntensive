using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class MenuHandler : MonoBehaviour
{

	[SerializeField]
	protected EventSystem system;
	[SerializeField]
	protected GameObject firstSelected;
	[SerializeField]
	protected UnityEvent CancelAction;


	protected CanvasGroup grp;


	// Use this for initialization
	protected void Start ()
	{
		grp = GetComponent<CanvasGroup> ();
	}
	
	// Update is called once per frame
	protected void Update ()
	{
		if (Input.GetButtonDown ("Cancel")) {
			CancelAction.Invoke ();
		}
	}

	public virtual void Appear ()
	{
		grp.DOKill ();
		grp.DOFade (1, 1).SetEase (Ease.InOutSine);
		system.SetSelectedGameObject (firstSelected);
	}

	public virtual void ButtonSelect (GameObject button)
	{
		button.transform.DOLocalMoveZ (-0.5f, 0.5f);
	}

	public virtual void ButtonDeselect (GameObject button)
	{
		button.transform.DOLocalMoveZ (0f, 0.5f);
	}

	public virtual void Disappear ()
	{
		grp.DOFade (0, 1).SetEase (Ease.InOutSine).OnComplete (() => {
			gameObject.SetActive (false);
		});

	}
}

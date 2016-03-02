using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.Events;

public class StartText : MonoBehaviour
{
	[SerializeField]
	private string validationAxisName;
	[SerializeField]
	private UnityEvent validationActions;
	[SerializeField]
	private UnityEvent onTransitionEnd;

	// Use this for initialization
	void Start ()
	{
		transform.DOMoveY (0.05f, 1).SetRelative ().SetEase (Ease.InOutSine).SetLoops (-1, LoopType.Yoyo);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (validationAxisName)) {
			validationActions.Invoke ();
		}
	}

	public void Disappear ()
	{
		transform.parent.parent.DORotate (new Vector3 (0, 180, 0), 0.75f).SetEase (Ease.InOutExpo);
		transform.DOScaleX (0, 1).SetEase (Ease.InOutExpo);
		StartCoroutine (Changeframe ());
	}

	IEnumerator Changeframe ()
	{
		yield return new WaitForSeconds (0.40f);
		onTransitionEnd.Invoke ();
		transform.parent.parent.gameObject.SetActive (false);
	}
}

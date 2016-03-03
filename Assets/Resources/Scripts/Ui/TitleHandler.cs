using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class TitleHandler : MonoBehaviour
{
	private Image canvas;
	// Use this for initialization
	void Start ()
	{
		canvas = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	public void Explode ()
	{
		//tmp fade out (waiting animation)
		canvas.DOFade (0, 0.40f).SetEase (Ease.InOutExpo).OnComplete (() => {
			transform.parent.gameObject.SetActive (false);
		});
	}
}

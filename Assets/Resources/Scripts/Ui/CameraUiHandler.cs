using UnityEngine;
using System.Collections;
using DG.Tweening;

[ExecuteInEditMode]
public class CameraUiHandler : MonoBehaviour
{
	[Header ("PointContainer")]
	[SerializeField]
	private Transform focusPoints;
	[SerializeField]
	private Transform Points;
	[Header ("Debug")]
	[SerializeField]
	private Transform activeFocusPoint;
	[SerializeField]
	private Transform activePoint;




	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (!Application.isPlaying) {
			transform.LookAt (activeFocusPoint, Vector3.up);

			transform.position = activePoint.position;

		}
		Debug.DrawRay (transform.position, transform.forward * 5, Color.red);
	}

	public void goToFrame (string name)
	{

		activeFocusPoint = focusPoints.FindChild (name);
		activePoint = Points.FindChild (name);
		transform.DOLookAt (activeFocusPoint.position, 0.75f, AxisConstraint.None, Vector3.up).SetEase (Ease.InOutSine).OnComplete (() => {
			transform.DOMove (activePoint.position, 0.75f).SetEase (Ease.InOutSine).OnUpdate (() => {
				transform.LookAt (activeFocusPoint, Vector3.up);
			});
		});

	}
}

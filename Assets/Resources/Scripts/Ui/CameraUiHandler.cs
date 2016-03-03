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
	[Header ("Options menu")]
	[SerializeField]
	private Transform bus;
	[Header ("Debug")]
	[SerializeField]
	private Transform activeFocusPoint;
	[SerializeField]
	private Transform activePoint;
	[SerializeField]
	private Transform up;
	[SerializeField]
	private bool useTransformUp;


	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		if (!Application.isPlaying) {
			transform.LookAt (activeFocusPoint, (useTransformUp) ? up.forward : Vector3.up);

			transform.position = activePoint.position;

		}
		Debug.DrawRay (transform.position, transform.forward * 5, Color.red);
	}

	public void goToFrame (string name)
	{
		transform.DOKill ();
		activeFocusPoint = focusPoints.FindChild (name);
		activePoint = Points.FindChild (name);
		Vector3 direction = activeFocusPoint.position - activePoint.position;
		Vector3 targetRotation = Quaternion.LookRotation (direction, Vector3.up).eulerAngles;
		transform.DOMove (activePoint.position, 0.75f).SetEase (Ease.InOutSine);
		transform.DORotate (targetRotation, 0.75f).SetEase (Ease.InOutSine);
	}

	public void goToOption ()
	{
		transform.DOKill ();
		activeFocusPoint = focusPoints.FindChild ("Options");
		activePoint = Points.FindChild ("Options");
		Vector3 direction = activeFocusPoint.position - activePoint.position;
		Vector3 targetRotation = Quaternion.LookRotation (direction, bus.forward).eulerAngles;
		transform.DOMove (activePoint.position, 1.5f).SetEase (Ease.InOutSine);
		transform.DORotate (targetRotation, 1.5f).SetEase (Ease.InOutSine);
	}
}

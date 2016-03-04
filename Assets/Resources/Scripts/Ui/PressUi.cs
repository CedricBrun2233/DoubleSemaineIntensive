using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[ExecuteInEditMode]
public class PressUi : MonoBehaviour
{
	[SerializeField]
	[Multiline]
	private string text;
	[SerializeField]
	private Sprite buttonImage;


	public string Text {
		set {
			text = value;
			transform.FindChild ("Text").GetComponent<Text> ().text = text;
		}
		get {
			return text;
		}
	}

	public Sprite ButtonImage {
		set {
			buttonImage = value;
			transform.FindChild ("Panel").FindChild ("Image").GetComponent<Image> ().sprite = buttonImage;
		}
		get {
			return buttonImage;
		}
	}


	void OnValidate ()
	{
		transform.FindChild ("Text").GetComponent<Text> ().text = text;
		transform.FindChild ("Image").GetComponent<Image> ().sprite = buttonImage;
	}

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

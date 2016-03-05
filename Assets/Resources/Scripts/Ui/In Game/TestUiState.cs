using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TestUiState : MonoBehaviour
{
	
	public UiState state;

	void OnValidate ()
	{
		if (Application.isPlaying)
			Ui_Manager.Instance.GoToState (state);
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

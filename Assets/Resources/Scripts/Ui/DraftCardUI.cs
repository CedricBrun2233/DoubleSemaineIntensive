using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DraftCardUI : MonoBehaviour
{
	public Card ActiveCard {
		get {
			return m_activeCard;
		}
		set {
			m_activeCard = value;
			//m_uiImage.sprite = value.image;
		}
	}

	[SerializeField]
	private Card m_activeCard;

	private Image m_uiImage;
	// Use this for initialization
	void Start ()
	{
		m_uiImage = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
		
}

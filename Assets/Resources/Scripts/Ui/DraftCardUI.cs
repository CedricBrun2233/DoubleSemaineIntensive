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
			if (m_uiImage == null)
				m_uiImage = GetComponent<Image> ();
			if (value.Image != null)
				m_uiImage.sprite = value.Image;
		}
	}

	[SerializeField]
	private Card m_activeCard;

	private Image m_uiImage;

	void Awake ()
	{
		m_uiImage = GetComponent<Image> ();
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

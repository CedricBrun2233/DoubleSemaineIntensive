using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Card //: MonoBehaviour
{
	public string name {
		get {
			return cardName;
		}
	}

	protected string cardName;
	protected int energy;

	public Sprite Image {
		get {
			return m_image;
		}
	}

	protected Sprite m_image;

	public Card (int energy, string name)
	{
		this.energy = energy;
		cardName = name;
	}

	public Card (int energy, string name, Sprite image)
	{
		this.energy = energy;
		this.m_image = image;
		cardName = name;
	}

	public string GetName ()
	{
		return cardName;
	}

	public int GetEnergy ()
	{
		return energy;
	}

	public abstract void Cast (List<GameObject> targets);

	public abstract Card Copy ();
}

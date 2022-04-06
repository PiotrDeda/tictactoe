using UnityEngine;

public class Shape
{
	[SerializeField] Sprite _sprite;

	public Sprite Sprite { get => _sprite; set => _sprite = value; }
}

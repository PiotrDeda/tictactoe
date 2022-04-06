using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeTypes : MonoBehaviour
{
	public static Shape Cross = new Shape();
	public static Shape Circle = new Shape();
	public static Shape Blank = new Shape();

	[SerializeField] Sprite _spriteCross = null;
	[SerializeField] Sprite _spriteCircle = null;
	[SerializeField] Sprite _spriteBlank = null;

	void Awake()
	{
		Cross.Sprite = _spriteCross;
		Circle.Sprite = _spriteCircle;
		Blank.Sprite = _spriteBlank;
	}
}

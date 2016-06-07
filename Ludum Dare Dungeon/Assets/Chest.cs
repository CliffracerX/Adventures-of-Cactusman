using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour
{
	public Sprite blankSprite;
	public RandomWep item;
	public bool opened = false;

	void Start()
	{
		item = new RandomWep("Nothing", 0, blankSprite, blankSprite, 0, 0, 0, 1);
	}
}
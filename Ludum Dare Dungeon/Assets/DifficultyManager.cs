using UnityEngine;
using System.Collections;

public class DifficultyManager : MonoBehaviour
{
	public static float timeRunning = 2;
	public static int difficulty = 10;

	void Update()
	{
		difficulty = (int)timeRunning;
		//difficulty+=4;
	}
}
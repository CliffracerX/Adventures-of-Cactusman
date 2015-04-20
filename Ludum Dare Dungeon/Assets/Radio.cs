using UnityEngine;
using System.Collections;

public class Radio : MonoBehaviour
{
	public AudioClip[] levels;
	public AudioSource adSrc;

	void Start()
	{
		int num = (int)DifficultyManager.timeRunning/2;
		num%=levels.Length;
		adSrc.clip=levels[num];
		adSrc.Play();
	}
}
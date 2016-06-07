using UnityEngine;
using System.Collections;

public class AnimationSequence : MonoBehaviour
{
	public int animIndex = 0;
	public Sprite[] animFrames;
	public bool[] playSound;

	void Update()
	{
		if(Time.frameCount%10==0)
		{
			animIndex+=1;
			animIndex%=animFrames.Length;
			if(playSound[animIndex])
			{
				this.GetComponent<AudioSource>().Play();
			}
		}
		this.GetComponent<SpriteRenderer>().sprite=animFrames[animIndex];
	}
}
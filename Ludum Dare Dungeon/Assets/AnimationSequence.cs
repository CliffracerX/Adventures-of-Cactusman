using UnityEngine;
using System.Collections;

public class AnimationSequence : MonoBehaviour
{
	public int animIndex = 0;
	public Sprite[] animFrames;

	void Update()
	{
		if(Time.frameCount%10==0)
		{
			animIndex+=1;
			animIndex%=animFrames.Length;
		}
		this.GetComponent<SpriteRenderer>().sprite=animFrames[animIndex];
	}
}
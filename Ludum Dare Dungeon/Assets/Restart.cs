using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
	public float ticksUntilReset = 60*4;
	public bool statReset = true;

	void Update()
	{
		ticksUntilReset-=Time.deltaTime*60;
		if(ticksUntilReset<1)
		{
			Application.LoadLevel(1);
			if(statReset)
			{
				PlayerMovement.instance.Reset();
				DifficultyManager.timeRunning=2;
			}
		}
	}
}
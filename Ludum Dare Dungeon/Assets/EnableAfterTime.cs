using UnityEngine;
using System.Collections;

public class EnableAfterTime : MonoBehaviour
{
	public float ticksTillEnable = 480;
	public GameObject objToEnable;

	void Update()
	{
		ticksTillEnable-=Time.deltaTime*60;
		if(ticksTillEnable<1)
		{
			objToEnable.SetActive(true);
			this.gameObject.SetActive(false);
		}
	}
}
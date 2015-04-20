using UnityEngine;
using System.Collections;

public class SelfDestructOnTime : MonoBehaviour
{
	public float timeTillDestruct = 240;

	void Update()
	{
		timeTillDestruct-=Time.deltaTime*60;
		if(timeTillDestruct<1)
		{
			Destroy(this.gameObject);
		}
	}
}
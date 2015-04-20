using UnityEngine;
using System.Collections;

public class WavingLeaves : MonoBehaviour
{
	public int rotGoal = 0;
	public float lerpTicks = 0;

	void Update()
	{
		Quaternion rot = this.transform.rotation;
		Vector3 angs = rot.eulerAngles;
		this.lerpTicks+=0.025f*Time.deltaTime;
		if(angs.z>rotGoal-0.25f && angs.z<rotGoal+0.25f)
		{
			rotGoal = Random.Range(0, 180);
			this.lerpTicks=0;
		}
		angs.z=Mathf.Lerp(angs.z, rotGoal, this.lerpTicks);
		rot.eulerAngles = angs;
		this.transform.rotation = rot;
	}
}

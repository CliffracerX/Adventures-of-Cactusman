using UnityEngine;
using System.Collections;

public class FountainScript : MonoBehaviour
{
	public GameObject objToSpawn;
	public GameObject objToDisable;
	public int healthIncrease;
	public int spIncrease;
	public int atkIncrease;
	public int xpIncrease;
	public bool doOnce = false;

	void OnTriggerEnter(Collider other)
	{
		if(other.tag=="Player" && !doOnce)
		{
			doOnce=true;
			PlayerMovement.health=PlayerMovement.maxhealth=PlayerMovement.maxhealth+healthIncrease;
			PlayerMovement.sp=PlayerMovement.maxsp=PlayerMovement.maxsp+spIncrease;
			PlayerMovement.attack+=atkIncrease;
			PlayerMovement.exp+=xpIncrease;
			objToSpawn.SetActive(true);
			objToDisable.SetActive(false);
		}
	}
}
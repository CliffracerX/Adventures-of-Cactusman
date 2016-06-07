using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public Vector3 target;
	public int damage;
	public GameObject source;
	public int speed;

	void Update()
	{
		transform.LookAt(target);
		GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward*(speed*Time.deltaTime), ForceMode.Force);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.GetComponent<AudioSource>()!=null)
			other.collider.GetComponent<AudioSource>().Play();
		if(other.collider.GetComponent<Mob>()!=null)
		{
			other.collider.GetComponent<Mob>().health-=damage;
			if(source.GetComponent<PlayerMovement>()!=null)
			{
				if(other.collider.GetComponent<Mob>().health<1)
				{
					int expGained = other.collider.gameObject.GetComponent<Mob>().maxhealth*other.collider.gameObject.GetComponent<Mob>().attack;
					float blah = expGained*PlayerMovement.items[PlayerMovement.selectedItem].expBoost;
					PlayerMovement.exp+=(int)blah;
				}
			}
		}
		if(other.collider.GetComponent<PlayerMovement>()!=null)
		{
			PlayerMovement.health-=damage;
		}
		Destroy(this.gameObject);
	}
}
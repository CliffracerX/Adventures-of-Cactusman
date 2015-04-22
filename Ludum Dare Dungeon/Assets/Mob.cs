using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour
{
	public Vector3 lastPos;
	public Sprite[] sprites;
	public Sprite deadSpr;
	public GameObject sr;
	public int health, maxhealth;
	public int attack;
	public GameObject target;
	public int speed = 15;
	public GameObject projectile;
	public int projectileChance;
	public Sprite projectileFireAnim;
	public float atkF = 0;

	void Start()
	{
		target=GameObject.Find("Player");
	}

	void Update()
	{
		atkF-=Time.deltaTime*60;
		if(this.transform.position!=lastPos)
		{
			if(Time.renderedFrameCount%10==0 && atkF<1)
			sr.GetComponent<SpriteRenderer>().sprite=sprites[Random.Range(0, sprites.Length)];
			Quaternion qat = Quaternion.identity;
			if(lastPos.x<transform.position.x)
				qat.eulerAngles = new Vector3(0, 0, 0);
			else if(lastPos.x>transform.position.x)
				qat.eulerAngles = new Vector3(0, 180, 0);
			else
				qat.eulerAngles = new Vector3(0, 180, 0);
			sr.transform.rotation=qat;
		}
		if(target!=null)
		{
			if(Vector3.Distance(transform.position, target.transform.position)>50)
			{
				transform.position+=new Vector3(Random.Range(-0.125f, 0.125f), 0, Random.Range(-0.125f, 0.125f));
			}
			else
			{
				transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed*Time.deltaTime);
				if(Random.Range(0, projectileChance)==0 && projectile!=null)
				{
					GameObject s = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
					Projectile p = s.GetComponent<Projectile>();
					p.damage=attack;
					p.source=this.gameObject;
					p.speed=20000;
					p.target=target.transform.position;
					sr.GetComponent<SpriteRenderer>().sprite=projectileFireAnim;
					atkF=20;
				}
			}
		}
		if(health<1)
		{
			Die();
		}
	}

	void Die()
	{
		sr.GetComponent<AudioSource>().Play();
		sr.GetComponent<SpriteRenderer>().sprite=deadSpr;
		transform.DetachChildren();
		Destroy(this.gameObject);
		this.SendMessage("DeathFunction");
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag=="Player")
		{
			PlayerMovement.health-=attack;
			other.collider.gameObject.GetComponent<AudioSource>().Play();
		}
	}
}
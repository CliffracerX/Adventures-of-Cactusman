using UnityEngine;
using System.Collections;

public class CactusBoss : MonoBehaviour
{
	public Mob mob;
	public RandomWep[] item = new RandomWep[1];
	public SpriteRenderer sprite1;
	public SpriteRenderer sprite2;
	public GameObject chestPrefab;

	void Start()
	{
		item[0] = new RandomWep("Nothing", 0, sprite1.sprite, sprite2.sprite, 0, 0, 0, 1);
		if(Random.Range(0, 2)==0)
			PlayerMovement.instance.GenerateSword(item, 0);
		else
			PlayerMovement.instance.GenerateBroomstick(item, 0);
		sprite1.sprite=item[0].sA;
		sprite2.sprite=item[0].sB;
		mob.maxhealth=(int)((PlayerMovement.maxhealth*2.5f)+(item[0].maxHealthB*2.5f));
		mob.attack=(int)((PlayerMovement.attack*2f)+(item[0].atkB*2f));
		mob.speed=(int)((PlayerMovement.instance.speed*1.5f)+(item[0].speedB*1.5f));
		mob.maxhealth*=2;
		mob.health=mob.maxhealth;
	}

	void DeathFunction()
	{
		{
			Vector3 pos = transform.position;
			pos.z-=5;
			GameObject o = (GameObject)Instantiate(chestPrefab, pos, Quaternion.identity);
			Chest c = o.GetComponent<Chest>();
			c.item=item[0];
		}
	}
}
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
		item[0] = new RandomWep("Nothing", 0, sprite1.sprite, sprite2.sprite, 0, 0, 0);
		if(Random.Range(0, 2)==0)
			PlayerMovement.instance.GenerateSword(item, 0);
		else
			PlayerMovement.instance.GenerateBroomstick(item, 0);
		sprite1.sprite=item[0].sA;
		sprite2.sprite=item[0].sB;
		mob.maxhealth=PlayerMovement.maxhealth+item[0].maxHealthB;
		mob.attack=PlayerMovement.attack+item[0].atkB;
		mob.speed=PlayerMovement.instance.speed+item[0].speedB;
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
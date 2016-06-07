using UnityEngine;
using System.Collections;

public class RespawnMobs : MonoBehaviour
{
	public GameObject mobToSpawn;
	public float timeRunning = 0;
	public int strength = 1;

	void Update()
	{
		if(Random.Range (0, 50000)==0)
		{
			Vector3 pos = transform.position;
			pos.y=3.97f;
			Quaternion rot = Quaternion.identity;
			GameObject obj = (GameObject)Instantiate(mobToSpawn, pos, rot);
			Mob m = obj.GetComponent<Mob>();
			m.maxhealth=((DifficultyManager.difficulty+5))*strength;
			m.health=m.maxhealth;
			m.attack=(((DifficultyManager.difficulty+12)/3)/3)*strength;
		}
	}
}
using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour
{
	public GameObject[] items;
	public float yOffset = 3.97f;
	public int chance = 3;

	void Start()
	{
		if(Random.Range(0, chance)==0 || chance==0)
		{
			Vector3 pos = transform.position;
			pos.y=yOffset;
			GameObject o = items[Random.Range(0, items.Length)];
			if(o.name=="Chest")
				pos.y=1;
			Instantiate(o, pos, Quaternion.identity);
		}
	}
}
using UnityEngine;
using System.Collections;

public class RandomItem : MonoBehaviour
{
	public GameObject[] items;

	void Start()
	{
		if(Random.Range(0, 5)==0)
		{
			Vector3 pos = transform.position;
			pos.y=3.97f;
			Instantiate(items[Random.Range(0, items.Length)], pos, Quaternion.identity);
		}
	}
}
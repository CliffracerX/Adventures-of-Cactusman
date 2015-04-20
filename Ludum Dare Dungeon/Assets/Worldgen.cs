using UnityEngine;
using System.Collections;

public class Worldgen : MonoBehaviour
{
	public GameObject grass;
	public GameObject cobble;
	public GameObject defaultRoom;
	public GameObject rareRoom;
	public GameObject door;
	public GameObject shop;
	public GameObject bossRoom;

	void Start()
	{
		if(DifficultyManager.timeRunning%20!=0)
		{
			Quaternion rot = Quaternion.identity;
			rot.eulerAngles = new Vector3(0, 0, 0);
			int x2 = Random.Range(-4, 4);
			int y2 = Random.Range(-4, 4);
			int x3 = Random.Range(-4, 4);
			int y3 = Random.Range(-4, 4);
			for(int x = -4; x<4; x++)
			{
				for(int y = -4; y<4; y++)
				{
					if(!((x==x3 && y==y3) && DifficultyManager.timeRunning%10==0))
					{
						if(!((x==x2 && y==y2) && true))
						{
							if(Random.Range (0, 10)==0)
								Instantiate(rareRoom, new Vector3(8*x*5, 0, 8*y*5), rot);
							else
								Instantiate(defaultRoom, new Vector3(8*x*5, 0, 8*y*5), rot);
						}
					}
				}
			}
			Instantiate(door, new Vector3(8*x2*5, 0f, 8*y2*5), rot);
			if(DifficultyManager.timeRunning%10==0)
			{
				Instantiate(shop, new Vector3(8*x3*5, 0, 8*y3*5), rot);
			}
		}
		else
		{
			Instantiate(bossRoom, new Vector3(0, 0, 0), Quaternion.identity);
		}
	}
}
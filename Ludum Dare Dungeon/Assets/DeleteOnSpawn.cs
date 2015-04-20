using UnityEngine;
using System.Collections;

public class DeleteOnSpawn : MonoBehaviour
{
	void Start()
	{
		Destroy(this.gameObject);
	}
}
using UnityEngine;
using System.Collections;

public class RemoveOnDeath : MonoBehaviour
{
	public GameObject optionalOther;
	public bool quit = false;
	public GameObject poof;

	void Update()
	{
		if(transform.parent==null)
		{
			if(!this.GetComponent<AudioSource>().isPlaying)
			{
				if(quit)
				{
					Application.LoadLevel(2);
				}
				Destroy(this.gameObject);
				Destroy(this.optionalOther);
				Instantiate(poof, transform.position, transform.rotation);
			}
		}
	}
}
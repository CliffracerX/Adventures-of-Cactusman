using UnityEngine;
using System.Collections;

public class AnimateOnHit : MonoBehaviour
{
	public AudioSource audioToPlay;
	public AnimationSequence anim1;
	public AnimationSequence anim2;
	public Collider colz;

	void OnTriggerEnter(Collider other)
	{
		anim1.enabled=false;
		anim2.enabled=true;
		audioToPlay.Play();
		colz.enabled=false;
		Light l = GameObject.Find("PlayerLightLol").GetComponent<Light>();
		l.color=new Color(0.5f, 0.125f, 0.125f);
		l.range=20f;
		l.intensity=2f;
		AudioReverbZone arz = GameObject.Find("Worldgen").GetComponent<AudioReverbZone>();
		arz.reverb=500;
	}

	void Update()
	{
		if(anim2.animIndex>anim2.animFrames.Length-2)
		{
			this.gameObject.SetActive(false);
		}
	}
}
using UnityEngine;

public class TapePickup : Pickup 
{
	[SerializeField]private AudioClip clip;
	private AudioManager audio;
	private void Start()
	{
		this.audio = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AudioManager>();
	}

	protected override void onPickup ()
	{
		audio.playSound (this.name);
	}
}

using UnityEngine;

[System.Serializable]
public class Audio
{
	[SerializeField]private string name;
	public string Name{get{return name;}}
	[SerializeField]private AudioClip clip;
	[Range(0,1)][SerializeField]private float volume;
	[Range(-3, 3)][SerializeField]private float pitch;
	[Range(-1, 1)][SerializeField]private float panning;
	[SerializeField]private bool loop;
	private AudioSource source;

	public void setSource(AudioSource source)
	{
		this.source = source;
		this.source.playOnAwake = false;
		this.source.clip = this.clip;
		this.source.volume = this.volume;
		this.source.pitch = this.pitch;
		this.source.panStereo = this.panning;
		this.source.loop = this.loop;
	}

	public void play()
	{
		if(!this.source.isPlaying)
			this.source.Play ();
	}

	public void stop()
	{
		this.source.Stop ();
	}
}

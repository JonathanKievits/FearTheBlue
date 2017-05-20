using UnityEngine;

[System.Serializable]
/// <summary>
/// Audio class.
/// </summary>
public class Audio
{
    /// <summary>
    /// The name of the clip.
    /// </summary>
    [SerializeField]private string name;
    public string Name{get{return name;}}
    /// <summary>
    /// The audioclip.
    /// </summary>
    [SerializeField]private AudioClip clip;
    /// <summary>
    /// The volume.
    /// </summary>
    [Range(0, 1)][SerializeField]private float volume;
    /// <summary>
    /// The pitch.
    /// </summary>
    [Range(-3, 3)][SerializeField]private float pitch;
    /// <summary>
    /// The panning.
    /// </summary>
    [Range(-1, 1)][SerializeField]private float panning;
    /// <summary>
    /// Boolean if the clip should be looping.
    /// </summary>
    [SerializeField]private bool loop;
    /// <summary>
    /// Boolen if the clip should play from start
    /// </summary>
    [SerializeField]private bool playFromStart;

    [Range(0,1)][SerializeField]private float spatialBlend;
    [SerializeField]private float minDistance;
    [SerializeField]private float maxDistance;
    [SerializeField]private Transform soundPosition;

    /// <summary>
    /// The AdioSource.
    /// </summary>
	private AudioSource source;
	public AudioSource Source{get{return source;}}

    /// <summary>
    /// Sets the source.
    /// </summary>
    /// <param name="source">Source.</param>
	public void setSource(AudioSource source)
	{
		this.source = source;
		this.source.playOnAwake = false;
		this.source.clip = this.clip;
		this.source.volume = this.volume;
		this.source.pitch = this.pitch;
		this.source.panStereo = this.panning;
		this.source.loop = this.loop;
        this.source.spatialBlend = this.spatialBlend;

        if (this.spatialBlend > 0)
        {
            if (soundPosition == null)
                soundPosition = this.source.transform;
            this.source.minDistance = this.minDistance;
            this.source.maxDistance = this.maxDistance;
            this.source.rolloffMode = AudioRolloffMode.Linear;
            this.source.transform.position = soundPosition.position;
        }

        if (this.playFromStart)
            this.source.Play();
	}

    /// <summary>
    /// Play this audioclip.
    /// </summary>
	public void play()
	{
		if(!this.source.isPlaying)
			this.source.Play ();
	}

    /// <summary>
    /// Stop the clip from playing.
    /// </summary>
	public void stop()
	{
		this.source.Stop ();
	}
}

using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
    [SerializeField]private Audio[] audioClips;

	private void Awake()
	{
        for (var i = 0; i < audioClips.Length; i++)
		{
			GameObject go = new GameObject ("Audio: " + audioClips[i].Name.ToString());
			go.transform.SetParent (this.transform);
			audioClips [i].setSource (go.AddComponent<AudioSource>());
		}
	}

	public void playSound(string name)
	{
		audioLoop (name).play ();
	}

	public void stopSound(string name)
	{
		audioLoop (name).stop ();	
	}

	public bool isPlaying(string name)
	{
		return audioLoop (name).Source.isPlaying;
	}

	private Audio audioLoop(string name)
	{
        for (var i = 0; i < audioClips.Length; i++)
		{
			if (audioClips [i].Name == name)
			{
				return audioClips[i];
			}
		}
		throw new System.Exception ("AudioManager: Could not find: " + name);
	}
}

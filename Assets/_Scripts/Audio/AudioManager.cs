using UnityEngine;

public class AudioManager : MonoBehaviour 
{
	[SerializeField]private Audio[] audio;

	private void Awake()
	{
		for (var i = 0; i < audio.Length; i++)
		{
			GameObject go = new GameObject ("Audio: " + audio[i].Name.ToString());
			go.transform.SetParent (this.transform);
			audio [i].setSource (go.AddComponent<AudioSource>());
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

	private Audio audioLoop(string name)
	{
		for (var i = 0; i < audio.Length; i++)
		{
			if (audio [i].Name == name)
			{
				return audio[i];
			}
		}
		throw new System.Exception ("AudioManager: Could not find: " + name);
	}
}

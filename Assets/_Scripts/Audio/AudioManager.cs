using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Audiomanager.
/// </summary>
public class AudioManager : MonoBehaviour 
{
    /// <summary>
    /// The audio instances.
    /// </summary>
    [SerializeField]private Audio[] audioClips;

    /// <summary>
    /// Awake this instance.
    /// </summary>
    private void Awake()
    {
        for (var i = 0; i < audioClips.Length; i++)
        {
            GameObject go = new GameObject ("Audio: " + audioClips[i].Name.ToString());
            go.transform.SetParent (this.transform);
            audioClips [i].setSource (go.AddComponent<AudioSource>());
        }
    }

    /// <summary>
    /// Play a sound.
    /// </summary>
    /// <param name="name">Name.</param>
    public void playSound(int id)
    {
        audioClips[id].play ();
    }

    /// <summary>
    /// Stop a sound.
    /// </summary>
    /// <param name="name">Name.</param>
    public void stopSound(int id)
    {
        audioClips[id].stop ();   
    }

    /// <summary>
    /// Check if a clip is playing
    /// </summary>
    /// <returns><c>true</c>, if clip is playing, <c>false</c> otherwise.</returns>
    /// <param name="name">Name.</param>
    public bool isPlaying(int id)
    {
        return audioClips[id].Source.isPlaying;
    }

    /*
    /// <summary>
    /// Loops through all audio clips and returns the desired clip
    /// </summary>
    /// <returns>The loop.</returns>
    /// <param name="name">Name.</param>
    private Audio audioLoop(string name)
    {
        for (var i = 0; i < audioClips.Length; i++)
        {
            if (audioClips [i].Name == name)
            {
                return audioClips[i];
            }
        }
        return null;
    }
    */

    public int audioToID(string name)
    {
        for (var i = 0; i < audioClips.Length; i++)
        {
            if (audioClips [i].Name == name)
                return i;
        }
        return 99999999;
    }
}
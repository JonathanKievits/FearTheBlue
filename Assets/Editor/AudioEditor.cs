using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioManager), false)]
public class AudioEditor : Editor 
{
    private AudioManager audioManager;
    private float labelWidth;

    private void OnEnable()
    {
        audioManager = (AudioManager)target;
        labelWidth = 120;
    }

    public override void OnInspectorGUI()
    {
        GUILayout.BeginVertical("box");
        GUILayout.Label("Audio Manager");

        for (var i = 0; i < audioManager.AudioClips.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Clip name: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].Name = GUILayout.TextField(audioManager.AudioClips[i].Name);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Audioclip: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].Clip = EditorGUILayout.ObjectField(audioManager.AudioClips[i].Clip, typeof(AudioClip)) as AudioClip;
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal ();
            GUILayout.Label ("Volume: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].Volume = EditorGUILayout.Slider (audioManager.AudioClips[i].Volume, 0, 1);
            GUILayout.EndHorizontal ();

            GUILayout.BeginHorizontal ();
            GUILayout.Label ("Pitch: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].Pitch = EditorGUILayout.Slider (audioManager.AudioClips[i].Pitch, -3, 3);
            GUILayout.EndHorizontal ();

            GUILayout.BeginHorizontal ();
            GUILayout.Label ("Spatial blend: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].SpatialBlend = EditorGUILayout.Slider (audioManager.AudioClips[i].SpatialBlend, 0, 1);
            GUILayout.EndHorizontal ();

            if (audioManager.AudioClips[i].SpatialBlend > 0)
            {
                GUILayout.BeginHorizontal ();
                GUILayout.Label ("Source position: ", GUILayout.Width(labelWidth));
                audioManager.AudioClips[i].SoundPosition = EditorGUILayout.ObjectField(audioManager.AudioClips[i].SoundPosition, typeof(Transform)) as Transform;
                GUILayout.EndHorizontal ();

                GUILayout.BeginHorizontal ();
                GUILayout.Label ("Min Distance: ", GUILayout.Width(labelWidth));
                audioManager.AudioClips[i].MinDistance = EditorGUILayout.FloatField(audioManager.AudioClips[i].MinDistance);
                GUILayout.EndHorizontal ();

                GUILayout.BeginHorizontal ();
                GUILayout.Label ("Max Distance: ", GUILayout.Width(labelWidth));
                audioManager.AudioClips[i].MaxDistance = EditorGUILayout.FloatField(audioManager.AudioClips[i].MaxDistance);
                GUILayout.EndHorizontal ();
            }

            GUILayout.BeginHorizontal ();
            GUILayout.Label ("Looping: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].Loop = EditorGUILayout.Toggle(audioManager.AudioClips[i].Loop);
            GUILayout.EndHorizontal ();

            GUILayout.BeginHorizontal ();
            GUILayout.Label ("Play from start: ", GUILayout.Width(labelWidth));
            audioManager.AudioClips[i].PlayFromStart = EditorGUILayout.Toggle(audioManager.AudioClips[i].PlayFromStart);
            GUILayout.EndHorizontal ();

            if (GUILayout.Button("delete"))
            {
                audioManager.AudioClips.RemoveAt(i);
                return;
            }
            GUILayout.Space(20);
        }

        if (GUILayout.Button("Add audioclip", GUILayout.Width(labelWidth)))
            addAudioclip();
            
        GUILayout.EndVertical (); 
    }

    private void addAudioclip()
    {
        audioManager.AudioClips.Add(new Audio());
    }
}

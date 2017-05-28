using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Pickup), true)]
public class PickupEditor : Editor 
{
    /*
	private Pickup pickup;
	private int labelWidth;
	private void OnEnable()
	{
		pickup = (Pickup)target;
		labelWidth = 120;
	}

	public override void OnInspectorGUI()
	{
		GUILayout.BeginVertical("box");
		GUILayout.Label ("Pickup information:");

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Item name: ", GUILayout.Width(labelWidth));
		pickup.Name = GUILayout.TextField (pickup.Name);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Item type: ", GUILayout.Width(labelWidth));
		pickup.Type = (ItemType)EditorGUILayout.EnumPopup (pickup.Type);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Outline colour: ", GUILayout.Width(labelWidth));
		pickup.OutlineColour = EditorGUILayout.ColorField (pickup.OutlineColour);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Outline width: ", GUILayout.Width(labelWidth));
		pickup.OutlineWidth = EditorGUILayout.Slider (pickup.OutlineWidth, 0, 1);
		GUILayout.EndHorizontal ();

		GUILayout.BeginHorizontal ();
		GUILayout.Label ("Max pickup distance: ", GUILayout.Width(labelWidth));
		pickup.MaxDistance = EditorGUILayout.Slider (pickup.MaxDistance, 0, 10);
		GUILayout.EndHorizontal ();
		GUILayout.EndVertical ();
	}
 */   
}

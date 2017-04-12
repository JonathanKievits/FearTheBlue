using UnityEngine;

public class ObjectOutlining : MonoBehaviour
{
	[SerializeField]private Material normalMat;
	[SerializeField]private Material outlinedMat;
	[SerializeField]private Shader outlineShader;

	public void outline(Renderer renderer, float outlineWidth)
	{
		//Material newMat = new Material (out);
		renderer.material.shader = outlineShader;
		renderer.material.mainTexture = renderer.material.mainTexture;
		renderer.material.SetFloat ("_Outline", outlineWidth);
		renderer.material.SetColor ("_Color", Color.white);
		renderer.material.SetColor ("_OutlineColor", Color.yellow);
	}

	public void normal(Renderer renderer)
	{
		Material newMat = new Material (normalMat);
		newMat.mainTexture = renderer.material.mainTexture;
		renderer.material = newMat;
	}
}

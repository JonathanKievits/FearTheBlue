using UnityEngine;

public class ObjectOutlining : MonoBehaviour
{
	[SerializeField] private Shader normalShader;
	[SerializeField] private Shader outlineShader;

	public void outline(Renderer renderer, float lineWidth, Color colour)
	{
		renderer.material.shader = outlineShader;
		renderer.material.SetFloat ("_Outline", lineWidth);
		renderer.material.SetColor ("_Color", Color.white);
		renderer.material.SetColor ("_OutlineColor", colour);
	}

	public void normal(Renderer renderer)
	{
		renderer.material.shader = normalShader;
	}
}

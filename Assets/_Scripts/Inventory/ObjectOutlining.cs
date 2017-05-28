﻿using UnityEngine;

/// <summary>
/// Outlines the given renderer.
/// </summary>
public class ObjectOutlining : MonoBehaviour
{
    /// <summary>
    /// The normal shader.
    /// </summary>
	[SerializeField] private Shader normalShader;
    /// <summary>
    /// The outline shader.
    /// </summary>
	[SerializeField] private Shader outlineShader;
    private Values values;
    private int outlineWidth;
    private int normalColour;
    private int outlineColour;

    private void Start()
    {
        values = this.GetComponent<Values>();
        outlineWidth = Shader.PropertyToID("_Outline");
        normalColour = Shader.PropertyToID("_Colour");
        outlineColour = Shader.PropertyToID("_OutlineColour");
    }

    /// <summary>
    /// Outline the specified renderer with the given lineWidth and colour.
    /// </summary>
    /// <param name="renderer">Renderer.</param>
    /// <param name="lineWidth">Line width.</param>
    /// <param name="colour">Colour.</param>
	public void outline(Renderer renderer, float lineWidth, Color colour)
	{
        if (values.CurrentOS == OperationSystem.windows)
            lineWidth = lineWidth * 40;
        
		renderer.material.shader = outlineShader;
        renderer.material.SetFloat (outlineWidth, lineWidth);
        renderer.material.SetColor (normalColour, Color.white);
        renderer.material.SetColor (outlineColour, colour);
	}

    /// <summary>
    /// Swicth specified renderer to normal.
    /// </summary>
    /// <param name="renderer">Renderer.</param>
	public void normal(Renderer renderer)
	{
		renderer.material.shader = normalShader;
	}
}

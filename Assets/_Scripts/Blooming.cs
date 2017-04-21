using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Aubergine/BloomSimple")]
public class Blooming : MonoBehaviour 
{
	[SerializeField]private float strength = 0.5f;
	[SerializeField]private Shader shader;
	private Material m_Material;
	protected Material material 
	{
		get 
		{
			if (m_Material == null) 
			{
				m_Material = new Material(shader);
				m_Material.hideFlags = HideFlags.HideAndDontSave;
			}
			return m_Material;
		}
	}

	protected void Start () 
	{
		if (!SystemInfo.supportsImageEffects) 
		{
			enabled = false;
			return;
		}
		if (!shader || !shader.isSupported)
			enabled = false;
	}
	protected void OnDisable () 
	{
		if( m_Material )
			DestroyImmediate(m_Material);
	}

	void Awake () 
	{
		material.SetFloat("_Strength", strength);
	}
		
	void OnRenderImage (RenderTexture source, RenderTexture destination) 
	{
		material.SetFloat("_Strength", strength);
		Graphics.Blit (source, destination, material);
	}
}

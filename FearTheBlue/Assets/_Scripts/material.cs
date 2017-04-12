using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class material : MonoBehaviour 
{
	[SerializeField] private Material outline;
	[SerializeField] private Material normal;

	private bool isActive;
	private void Start()
	{
		isActive = false;
	}
	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.E))
			go();
	}

	private void go()
	{
		if (isActive)
		{
			disable ();
			return;
		}
		enable();
		return;
	}

	private void enable()
	{
		isActive = true;
		var objects = GameObject.FindGameObjectsWithTag ("Player");
		for (var i = 0; i < objects.Length; i++)
		{
			var mat = new Material (outline);
			var renderer = objects [i].GetComponent<Renderer> ();
			mat.mainTexture = renderer.material.mainTexture;
			renderer.material = mat;
		}
	}

	private void disable()
	{
		isActive = false;
		var objects = GameObject.FindGameObjectsWithTag ("Player");
		for (var i = 0; i < objects.Length; i++)
		{
			var mat = new Material (normal);
			var renderer = objects [i].GetComponent<Renderer> ();
			mat.mainTexture = renderer.material.mainTexture;
			renderer.material = mat;
		}
	}
}

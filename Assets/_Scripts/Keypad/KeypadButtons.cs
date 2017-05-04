using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadButtons : MonoBehaviour 
{
	[SerializeField]private GameObject[] buttons;
	[SerializeField]private Text code;

	private List<Renderer> renderers;
	private ObjectOutlining outline;
	private int currButton;
	private int codeLength;
	private bool start;
	private bool hold;

	private void Start()
	{
		outline = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectOutlining> ();
		start = false;
		codeLength = 4;
		hold = false;
		renderers = new List<Renderer> ();
		for (var i = 0; i < buttons.Length; i++){renderers.Add(buttons [i].GetComponent<Renderer> ());}
	}

	public void selectFirstButtton()
	{
		code.text = "";
		outline.normal (renderers[currButton]);
		currButton = 1;
		selectButton(currButton);
		start = true;
	}

	public void stopButtons()
	{
		start = false;
		outline.normal (renderers[currButton]);
	}

	private void selectButton(int index)
	{
		outline.normal (renderers[currButton]);
		outline.outline (renderers[index], 0.0005f, Color.red);
		return;
	}

	private void Update()
	{
		if (!start)
			return;
		
		if (Input.GetButtonDown (Controller.Square))
			code.text += currButton.ToString ();

		var xAxis = Input.GetAxisRaw (Controller.RightStickY);
		if (xAxis >= 0.5f && currButton != 0 && currButton != 9 && !hold)
		{
			selectButton (currButton+1);
			currButton++;
			hold = true;
		}

		if (xAxis >= 0.5f && currButton == 9 && !hold)
		{
			selectButton (0);
			currButton = 0;
			hold = true;
		}

		if (xAxis <= -0.5f && currButton != 0 && currButton != 1 && !hold)
		{
			selectButton (currButton-1);
			currButton--;
			hold = true;
		}

		if (xAxis <= -0.5f && currButton == 1 && !hold)
		{
			selectButton (0);
			currButton = 0;
			hold = true;
		}

		if (xAxis <= -0.5f && currButton == 0 && !hold)
		{
			selectButton (9);
			currButton = 9;
			hold = true;
		}

		if (xAxis >= 0.5f && currButton == 0 && !hold)
		{
			selectButton (1);
			currButton = 1;
			hold = true;
		}

		if (xAxis < 0.5f && xAxis > -0.5f)
			hold = false;
	}
}

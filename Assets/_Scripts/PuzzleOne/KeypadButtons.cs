using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keypad button logic.
/// </summary>
public class KeypadButtons : MonoBehaviour 
{
    /// <summary>
    /// The buttons.
    /// </summary>
	[SerializeField]private GameObject[] buttons;
    /// <summary>
    /// Reference to Textobject that shows the code.
    /// </summary>
	[SerializeField]private Text code;

    /// <summary>
    /// Reference the renderers of the buttons.
    /// </summary>
	private List<Renderer> renderers;
    /// <summary>
    /// Reference to the ObjectOutlining class.
    /// </summary>
	private ObjectOutlining outline;
    /// <summary>
    /// The current button.
    /// </summary>
	private int currButton;
    /// <summary>
    /// The length of the code.
    /// </summary>
	private int codeLength;
    /// <summary>
    /// Boolean if already started.
    /// </summary>
	private bool start;
    /// <summary>
    /// Boolean if the button is being hold.
    /// </summary>
	private bool hold;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		outline = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectOutlining> ();
		start = false;
		codeLength = 4;
		hold = false;
		renderers = new List<Renderer> ();
		for (var i = 0; i < buttons.Length; i++){renderers.Add(buttons [i].GetComponent<Renderer> ());}
	}

    /// <summary>
    /// Selects the first buttton.
    /// </summary>
	public void selectFirstButtton()
	{
		code.text = "";
		outline.normal (renderers[currButton]);
		currButton = 1;
		selectButton(currButton);
		start = true;
	}

    /// <summary>
    /// Stops the buttons.
    /// </summary>
	public void stopButtons()
	{
		start = false;
		outline.normal (renderers[currButton]);
	}

    /// <summary>
    /// Selects the button.
    /// </summary>
    /// <param name="index">Index.</param>
	private void selectButton(int index)
	{
		outline.normal (renderers[currButton]);
		outline.outline (renderers[index], 0.0005f, Color.red);
		return;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (!start)
			return;
		
		if (Input.GetButtonDown (Controller.Square))
			code.text += currButton.ToString ();

        var yAxis = Input.GetAxisRaw (Controller.RightStickY);
        var xAxis = Input.GetAxisRaw (Controller.RightStickX);
        if (yAxis >= 0.5f && currButton != 0 && currButton != 3 && currButton != 6 && currButton != 9 && !hold)
		{
			selectButton (currButton+1);
			currButton++;
			hold = true;
		}

        if (yAxis <= -0.5f && currButton != 0 && currButton != 4 && currButton != 7 && currButton != 1 && !hold)
        {
            selectButton(currButton - 1);
            currButton--;
            hold = true;
        }

        if (xAxis >= 0.5f && currButton != 7 && currButton != 8 && currButton != 9 && currButton != 0 && !hold)
        {
            selectButton(currButton + 3);
            currButton += 3;
            hold = true;
        }

        if (xAxis >= 0.5f && currButton == 8 && !hold)
        {
            selectButton(0);
            currButton = 0;
            hold = true;
        }

        if (xAxis <= -0.5f && currButton != 1 && currButton != 2 && currButton != 3 && currButton != 0 && !hold)
        {
            selectButton(currButton - 3);
            currButton -= 3;
            hold = true;
        }

        if (xAxis <= -0.5f && currButton == 0 && !hold)
        {
            selectButton(8);
            currButton = 8;
            hold = true;
        }

        if (yAxis < 0.5f && yAxis > -0.5f && xAxis < 0.5f && xAxis > -0.5f)
			hold = false;
	}
}

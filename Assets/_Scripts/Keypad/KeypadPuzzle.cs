using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzle : PuzzleBase
{
	[SerializeField]private string correctCode;
	[SerializeField]private Transform door;
	[SerializeField]private Text code;


	private KeypadButtons buttons;
	private Movement movement;
	private LookScript look;

	protected override void Start ()
	{
		base.Start ();
		movement = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<Movement> ();
		look = GameObject.FindGameObjectWithTag (Tags.player).GetComponentInChildren<LookScript> ();
		buttons = GameObject.FindGameObjectWithTag (Tags.keypad).GetComponent<KeypadButtons> ();
	}

	public override void startPuzzle ()
	{
		enableScripts (false);
		buttons.selectFirstButtton ();
	}

	public override void check ()
	{
		if (code.text == correctCode)
			onSolve ();

		if (code.text.Length == 4)
			cancel ();
	}

	protected override void onSolve ()
	{
		buttons.stopButtons ();
		enableScripts (true);
		StartCoroutine ("moveDoor");
		manager.exitState ();
	}

	public override void cancel ()
	{
		enableScripts (true);
		buttons.stopButtons ();
	}

	private void enableScripts(bool value)
	{
		movement.enabled = value;
		look.enabled = value;
	}

	private IEnumerator moveDoor()
	{
		var originalPos = door.localPosition;
		while (door.localPosition.y < 6)
		{
			door.localPosition += new Vector3 (0, 0.1f, 0);
			yield return new WaitForSeconds (0.01f);
		}

		yield return new WaitForSeconds (5f);

		while (door.localPosition.y > originalPos.y)
		{
			door.localPosition -= new Vector3 (0, 0.1f, 0);
			yield return new WaitForSeconds (0.01f);
		}
	}
}

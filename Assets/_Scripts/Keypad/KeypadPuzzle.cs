using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzle : PuzzleBase
{
	[SerializeField]private string correctCode;
	[SerializeField]private Text code;


	private KeypadButtons buttons;
	private EnableKeypad keypad;
	private Inventory inventory;
	private Movement movement;
	private LookScript look;
	private Item key;

	protected override void Start ()
	{
		base.Start ();
		this.key = new Item ("padKey", ItemType.key);
		this.movement = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<Movement> ();
		this.keypad = GameObject.FindGameObjectWithTag (Tags.keypad).GetComponent<EnableKeypad> ();
		this.buttons = GameObject.FindGameObjectWithTag (Tags.keypad).GetComponent<KeypadButtons> ();
		this.look = GameObject.FindGameObjectWithTag (Tags.player).GetComponentInChildren<LookScript> ();
		this.inventory = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Inventory> ();
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

		if (code.text.Length == correctCode.Length)
			cancel ();
	}

	protected override void onSolve ()
	{
		buttons.stopButtons ();
		enableScripts (true);
		inventory.AddItem (key);
		keypad.enabled = false;
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
}

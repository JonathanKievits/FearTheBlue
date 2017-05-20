using System.Collections;

using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Keypad puzzle logic.
/// </summary>
public class KeypadPuzzle : PuzzleBase
{
    /// <summary>
    /// The correct code.
    /// </summary>
	[SerializeField]private string correctCode;
    /// <summary>
    /// Reference to Text object.
    /// </summary>
	[SerializeField]private Text code;

    /// <summary>
    /// Reference to AudioManager class.
    /// </summary>
    private AudioManager audioManager;
    /// <summary>
    /// Reference to KeypadButtons class.
    /// </summary>
	private KeypadButtons buttons;
    /// <summary>
    /// Reference to EnableKeypad script.
    /// </summary>
	private EnableKeypad keypad;
    /// <summary>
    /// Reference to Inventory class.
    /// </summary>
	private Inventory inventory;
    /// <summary>
    /// Reference to Movement class.
    /// </summary>
	private Movement movement;
    /// <summary>
    /// Reference to Lookscript.
    /// </summary>
	private LookScript look;
    /// <summary>
    /// The key.
    /// </summary>
	private Item key;

    /// <summary>
    /// Start this instance.
    /// </summary>
	protected override void Start ()
	{
		base.Start ();
		this.key = new Item ("padKey", ItemType.key);
		this.movement = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<Movement> ();
		this.keypad = GameObject.FindGameObjectWithTag (Tags.keypad).GetComponent<EnableKeypad> ();
		this.buttons = GameObject.FindGameObjectWithTag (Tags.keypad).GetComponent<KeypadButtons> ();
		this.look = GameObject.FindGameObjectWithTag (Tags.player).GetComponentInChildren<LookScript> ();
		this.inventory = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Inventory> ();
        this.audioManager = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<AudioManager>();
	}

    /// <summary>
    /// Starts the puzzle.
    /// </summary>
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

    /// <summary>
    /// Called when the puzzle is solved.
    /// </summary>
	protected override void onSolve ()
	{
		buttons.stopButtons ();
		enableScripts (true);
        audioManager.playSound("KeypadSolve");
		inventory.AddItem (key);
        keypad.enabled = false;
		manager.exitState ();
	}

    /// <summary>
    /// Cancels the puzzle.
    /// </summary>
	public override void cancel ()
	{
		buttons.stopButtons ();
        keypad.disableKeypad();
        enableScripts (true);
	}

    /// <summary>
    /// Enables or disables the scripts.
    /// </summary>
    /// <param name="value">If set to <c>true</c> value.</param>
	private void enableScripts(bool value)
	{
		movement.enabled = value;
		look.enabled = value;
	}
}

using UnityEngine;

/// <summary>
/// Enables the keypad.
/// </summary>
public class EnableKeypad : MonoBehaviour 
{
    /// <summary>
    /// The max distance to the player.
    /// </summary>
	[SerializeField]private float maxDistance;
    /// <summary>
    /// Reference to CheckDistance2Player class
    /// </summary>
	private CheckDistance2Player range;
    /// <summary>
    /// Reference to PuzzleManager class
    /// </summary>
	private PuzzleManager manager;
    /// <summary>
    /// Reference to KeypadButtons class.
    /// </summary>
	private KeypadButtons buttons;
    /// <summary>
    /// Reference to player transform
    /// </summary>
	private Transform player;
    /// <summary>
    /// Boolean if the keypad is selected.
    /// </summary>
	private bool isSelected;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		buttons = this.GetComponent<KeypadButtons> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		manager = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<PuzzleManager> ();
		range = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CheckDistance2Player> ();
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
			selectKeypad ();
	}

    /// <summary>
    /// Selects the keypad.
    /// </summary>
	private void selectKeypad()
	{
		if (!isSelected)
		{
			if (!range.inRange(this.transform.position, maxDistance))
				return;

			manager.setState (puzzleID.keypad);
			isSelected = true;
			return;
		}
			
		manager.exitState ();
		isSelected = false;
		return;
	}
}

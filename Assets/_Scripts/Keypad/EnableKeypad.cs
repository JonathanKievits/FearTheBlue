using UnityEngine;

public class EnableKeypad : MonoBehaviour 
{

	[SerializeField]private float maxDistance;
	private CheckDistance2Player range;
	private PuzzleManager manager;
	private KeypadButtons buttons;
	private Transform player;
	private bool isSelected;

	private void Start()
	{
		buttons = this.GetComponent<KeypadButtons> ();
		player = GameObject.FindGameObjectWithTag (Tags.player).transform;
		manager = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<PuzzleManager> ();
		range = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CheckDistance2Player> ();
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
			selectKeypad ();
	}

	private void selectKeypad()
	{
		if (!isSelected)
		{
			if (!range.inRange(this.transform.position, maxDistance))
				return;

			manager.setState (puzzleID.keypad);
			isSelected = !isSelected;
			return;
		}
			
		manager.exitState ();
		isSelected = !isSelected;
		return;
	}
}

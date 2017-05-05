using UnityEngine;

public class PillarLogic : MonoBehaviour 
{
	[Range(1,20)][SerializeField]private float maxDistance;
	private bool isEnabled;
	private bool hasObject;

	private LookScript lookScript;
	private Movement movementScript;
	private CheckDistance2Player range;
	private RotateObject objectToRotate;
	private Inventory inventory;
	private PuzzleManager manager;

	private void Start()
	{
		objectToRotate = this.transform.GetChild (0).gameObject.GetComponent<RotateObject>();
		lookScript = GameObject.FindGameObjectWithTag (Tags.player).GetComponentInChildren<LookScript> ();
		movementScript = GameObject.FindGameObjectWithTag (Tags.player).GetComponent<Movement> ();
		range = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CheckDistance2Player> ();
		inventory = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Inventory> ();
		manager = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<PuzzleManager>();
		isEnabled = false;
		hasObject = false;
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
		{
			if (!range.inRange(this.transform.position, maxDistance))
				return;
			
			if (!hasObject)
				setCube ();

			if (!isEnabled)
			{
				enableCube ();
				return;
			}
			disableCube ();
		}
	}

	private void enableCube()
	{
		if (!hasObject)
			return;

		manager.setState (puzzleID.rotate);
		objectToRotate.gameObject.SetActive (true);
		objectToRotate.enabled = true;
		lookScript.enabled = false;
		movementScript.enabled = false;
		isEnabled = true;
	}

	private void setCube()
	{
		if (inventory.getItem (ItemType.puzzleItem, "ToyCar") == null)
			return;

		objectToRotate.gameObject.SetActive (true);
		inventory.removeItem (ItemType.puzzleItem, "ToyCar");
		hasObject = true;
	}

	public void disableCube()
	{
		objectToRotate.enabled = false;
		lookScript.enabled = true;
		movementScript.enabled = true;
		isEnabled = false;
		manager.exitState ();
	}
}
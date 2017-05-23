using UnityEngine;

/// <summary>
/// Pillar logic.
/// </summary>
public class PillarLogic : MonoBehaviour 
{
    /// <summary>
    /// The max distance to player.
    /// </summary>
	[Range(1,20)][SerializeField]private float maxDistance;
    /// <summary>
    /// Is enabled.
    /// </summary>
	private bool isEnabled;
    /// <summary>
    /// Boolean if pillar has object.
    /// </summary>
	private bool hasObject;

    /// <summary>
    /// reference to LookScript.
    /// </summary>
	private LookScript lookScript;
    /// <summary>
    /// Reference to Movement class.
    /// </summary>
	private Movement movementScript;
    /// <summary>
    /// Reference to CheckDistance2Player class.
    /// </summary>
	private CheckDistance2Player range;
    /// <summary>
    /// Reference to RotateObject class.
    /// </summary>
	private RotateObject objectToRotate;
    /// <summary>
    /// Reference to Inventory class.
    /// </summary>
	private Inventory inventory;
    /// <summary>
    /// Reference to PuzzleManager.
    /// </summary>
	private PuzzleManager manager;

    /// <summary>
    /// Start this instance.
    /// </summary>
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

    /// <summary>
    /// Update this instance.
    /// </summary>
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

    /// <summary>
    /// Enables the cube.
    /// </summary>
	private void enableCube()
	{
		if (!hasObject)
			return;

		manager.setState (puzzleID.rotate);
		lookScript.enabled = false;
		movementScript.enabled = false;
        objectToRotate.gameObject.SetActive (true);
        objectToRotate.enabled = true;
		isEnabled = true;
	}

    /// <summary>
    /// Sets the cube.
    /// </summary>
	private void setCube()
	{
		if (inventory.getItem (ItemType.puzzleItem, "ToyCar") == null)
			return;

		objectToRotate.gameObject.SetActive (true);
		inventory.removeItem (ItemType.puzzleItem, "ToyCar");
		hasObject = true;
	}

    /// <summary>
    /// Disables the cube.
    /// </summary>
	public void disableCube()
	{
		objectToRotate.enabled = false;
		lookScript.enabled = true;
		movementScript.enabled = true;
		isEnabled = false;
		manager.exitState ();
	}
}
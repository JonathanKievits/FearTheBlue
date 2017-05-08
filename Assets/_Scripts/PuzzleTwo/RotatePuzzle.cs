using UnityEngine;
using System.Collections;

/// <summary>
/// Rotate puzzle logic.
/// </summary>
public class RotatePuzzle : PuzzleBase 
{
    /// <summary>
    /// Reference to the transform of the object to rotate
    /// </summary>
	[SerializeField]private Transform objectToRotate;
    /// <summary>
    /// Reference to the transform of the door.
    /// </summary>
	[SerializeField]private Transform safeDoor;
    /// <summary>
    /// Reference to the key.
    /// </summary>
	[SerializeField]private GameObject key;
    /// <summary>
    /// The max offset.
    /// </summary>
	[SerializeField]private float maxOffset;
    /// <summary>
    /// The correct y rotation.
    /// </summary>
	[SerializeField]private float correctY;
    /// <summary>
    /// The corrext z rotation.
    /// </summary>
	[SerializeField]private float corrextZ;

    /// <summary>
    /// Reference to PillarLogic class.
    /// </summary>
	private PillarLogic pillarLogic;
    /// <summary>
    /// Reference to RotateObject class.
    /// </summary>
	private RotateObject rotateObject;
    /// <summary>
    /// Boolean if y rotation is correct.
    /// </summary>
	private bool yOkay;
    /// <summary>
    /// Boolean if z rotation is correct.
    /// </summary>
	private bool zOkay;

    /// <summary>
    /// Start this instance.
    /// </summary>
	protected override void Start()
	{
		base.Start ();
		key.SetActive (false);
		pillarLogic = FindObjectOfType<PillarLogic> ();
		if (!(rotateObject = objectToRotate.gameObject.GetComponent<RotateObject> ()))
			rotateObject = objectToRotate.gameObject.AddComponent<RotateObject> ();
	}

    /// <summary>
    /// Called when puzzle is started.
    /// </summary>
	public override void startPuzzle ()
	{
		yOkay = false;
		zOkay = false;
	}

    /// <summary>
    /// Called when the puzzle is solved.
    /// </summary>
	protected override void onSolve()
	{
		StartCoroutine ("openDoor");
		pillarLogic.disableCube ();
		pillarLogic.enabled = false;
		rotateObject.enabled = false;
		key.SetActive (true);
		manager.exitState ();
	}

    /// <summary>
    /// Opens the safe.
    /// </summary>
    /// <returns>The door.</returns>
	private IEnumerator openDoor()
	{
		while (safeDoor.transform.eulerAngles.y > 50)
		{
			safeDoor.transform.localEulerAngles -= new Vector3 (0,1,0);
			yield return new WaitForSeconds (0.01f);
		}
	}

    /// <summary>
    /// Check if the puzzle has been solved.
    /// </summary>
	public override void check()
	{
		yOkay = false;
		zOkay = false;

        var angle = objectToRotate.localEulerAngles.y;
        angle = (angle > 180) ? angle - 360 : angle;

        if(System.Math.Abs(angle - correctY) <= maxOffset)
			yOkay = true;

        angle = objectToRotate.localEulerAngles.z;
        angle = (angle > 180) ? angle - 360 : angle;
		if (System.Math.Abs (angle - corrextZ) <= maxOffset)
			zOkay = true;

		if (yOkay && zOkay)
			onSolve ();
	}
}

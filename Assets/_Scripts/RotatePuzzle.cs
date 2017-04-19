using UnityEngine;
using System.Collections;

public class RotatePuzzle : PuzzleBase 
{
	[SerializeField]private Transform objectToRotate;
	[SerializeField]private Transform safeDoor;
	[SerializeField]private float maxOffset;
	[SerializeField]private float correctY;
	[SerializeField]private float correctX;
	private PillarLogic pillarLogic;
	private RotateObject rotateObject;
	private bool yOkay;
	private bool zOkay;

	protected override void Start()
	{
		base.Start ();
		pillarLogic = FindObjectOfType<PillarLogic> ();
		rotateObject = objectToRotate.gameObject.GetComponent<RotateObject> ();
	}

	public override void startPuzzle ()
	{
		yOkay = false;
	}

	protected override void onSolve()
	{
		StartCoroutine ("openDoor");
		pillarLogic.disableCube ();
		pillarLogic.enabled = false;
		rotateObject.enabled = false;
		manager.exitState ();
	}

	private IEnumerator openDoor()
	{
		while (safeDoor.transform.eulerAngles.y > 50)
		{
			safeDoor.transform.localEulerAngles -= new Vector3 (0,1,0);
			yield return new WaitForSeconds (0.01f);
		}
	}

	public override void check()
	{
		yOkay = false;
		zOkay = false;
		if(System.Math.Abs(objectToRotate.localEulerAngles.y - correctY) <= maxOffset)
			yOkay = true;

		if (System.Math.Abs (objectToRotate.localEulerAngles.z - correctX) <= maxOffset)
			zOkay = true;

		if (yOkay && zOkay)
			onSolve ();
	}
}

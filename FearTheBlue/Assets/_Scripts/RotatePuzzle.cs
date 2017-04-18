using UnityEngine;
using System.Collections;

public class RotatePuzzle : PuzzleBase 
{
	[SerializeField]private float maxOffset;
	[SerializeField]private Transform cube;
	[SerializeField]private Transform safeDoor;
	private float yRotation;
	private float zRotation;
	private bool yOkay;
	private bool zOkay;

	public override void startPuzzle ()
	{
		yRotation = 80;
		zRotation = 50;
	}

	protected override void onSolve()
	{
		print ("CORRECT!");
		StartCoroutine ("openDoor");
		manager.exitState ();
	}

	private IEnumerator openDoor()
	{
		while (safeDoor.transform.eulerAngles.y > 50)
		{
			safeDoor.transform.localEulerAngles -= new Vector3 (0,1,0);
			yield return new WaitForSeconds (0.01f);
			//print (safeDoor.transform.eulerAngles.y);
		}
	}

	public override void check()
	{
		yOkay = false;
		zOkay = false;
		if(System.Math.Abs(cube.localEulerAngles.y - yRotation) <= maxOffset)
			yOkay = true;

		if (System.Math.Abs (cube.localEulerAngles.z - zRotation) <= maxOffset)
			zOkay = true;

		if (yOkay && zOkay)
			onSolve ();
	}
}

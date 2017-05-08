using UnityEngine;
using System.Collections;

public class RotatePuzzle : PuzzleBase 
{
	[SerializeField]private Transform objectToRotate;
	[SerializeField]private Transform safeDoor;
	[SerializeField]private GameObject key;
	[SerializeField]private float maxOffset;
	[SerializeField]private float correctY;
	[SerializeField]private float corrextZ;

	private PillarLogic pillarLogic;
	private RotateObject rotateObject;
	private bool yOkay;
	private bool zOkay;

	protected override void Start()
	{
		base.Start ();
		key.SetActive (false);
		pillarLogic = FindObjectOfType<PillarLogic> ();
		if (!(rotateObject = objectToRotate.gameObject.GetComponent<RotateObject> ()))
			rotateObject = objectToRotate.gameObject.AddComponent<RotateObject> ();
	}

	public override void startPuzzle ()
	{
		yOkay = false;
		zOkay = false;
	}

	protected override void onSolve()
	{
		StartCoroutine ("openDoor");
		pillarLogic.disableCube ();
		pillarLogic.enabled = false;
		rotateObject.enabled = false;
		key.SetActive (true);
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

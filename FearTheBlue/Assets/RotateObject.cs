using UnityEngine;

public class RotateObject : MonoBehaviour 
{
	private float angleX, angleY;
	private void Start()
	{
		angleX = 0;
		angleY = 0;
	}
	private void Update()
	{
		angleX += Input.GetAxisRaw (Controller.RightStickX);
		angleY += Input.GetAxisRaw (Controller.RightStickY);
		var direction = new Vector3 (this.transform.localEulerAngles.x, angleX, angleY);

		this.transform.localEulerAngles = direction;
		/*
		if (Input.GetButton (Controller.R1))
		{
			angle++;
			this.transform.localEulerAngles = new Vector3 (this.transform.eulerAngles.x, angle, this.transform.eulerAngles.z);
		}

		if (Input.GetButton (Controller.L1))
		{
			angle--;
			this.transform.localEulerAngles = new Vector3 (this.transform.eulerAngles.x, angle, this.transform.eulerAngles.z);
		}
		*/
	}
}

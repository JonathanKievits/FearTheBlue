using UnityEngine;

public class RotateObject : MonoBehaviour 
{
	private float angleX, angleY;
	[SerializeField]private float speed;
	private void Start()
	{
		angleX = 0;
		angleY = 0;
	}

	private void Update()
	{
		angleX += Input.GetAxisRaw (Controller.RightStickX) * Time.deltaTime;
		angleY += -Input.GetAxisRaw (Controller.RightStickY) * Time.deltaTime;
		var direction = new Vector3 (this.transform.localEulerAngles.x, angleY*speed, angleX*speed);
		this.transform.localEulerAngles = direction;
	}
}

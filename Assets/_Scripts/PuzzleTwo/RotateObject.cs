using UnityEngine;

public class RotateObject : MonoBehaviour 
{
    private float angleZ, angleY;
	[SerializeField]private float speed;
	private void Start()
	{
        angleZ = this.transform.localEulerAngles.z;
        angleY = this.transform.localEulerAngles.y;
	}

	private void Update()
	{
		angleZ += Input.GetAxisRaw (Controller.RightStickX) * Time.deltaTime;
		angleY += -Input.GetAxisRaw (Controller.RightStickY) * Time.deltaTime;
		var direction = new Vector3 (this.transform.localEulerAngles.x, angleY*speed, angleZ*speed);
		this.transform.localEulerAngles = direction;
	}
}

using UnityEngine;

/// <summary>
/// Rotates an object.
/// </summary>
public class RotateObject : MonoBehaviour 
{
    /// <summary>
    /// The z angle.
    /// </summary>
    private float angleZ;
    /// <summary>
    /// The y angle;
    /// </summary>
    private float angleY;
    /// <summary>
    /// The rotation speed multiplier.
    /// </summary>
	[SerializeField]private float speed;
    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
        angleZ = this.transform.localEulerAngles.z;
        angleY = this.transform.localEulerAngles.y;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		angleZ += Input.GetAxisRaw (Controller.RightStickX) * Time.deltaTime;
		angleY += -Input.GetAxisRaw (Controller.RightStickY) * Time.deltaTime;
		var direction = new Vector3 (this.transform.localEulerAngles.x, angleY*speed, angleZ*speed);
		this.transform.localEulerAngles = direction;
	}
}

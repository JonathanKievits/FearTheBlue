using UnityEngine;
using UnityEngine.VR;

/// <summary>
/// Looking behaviour.
/// </summary>
public class LookScript : MonoBehaviour 
{
    /// <summary>
    /// Reference to the player object.
    /// </summary>
	private GameObject player;
    /// <summary>
    /// Muliplier for lookspeed
    /// </summary>
	[SerializeField]private float lookSpeed;
	[SerializeField]private float maxRotate;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		player = this.transform.parent.gameObject;
        if (VRDevice.isPresent)
            this.enabled = false;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		var x = Input.GetAxisRaw (Controller.RightStickX);
		var y = Input.GetAxisRaw (Controller.RightStickY);
        this.transform.eulerAngles += new Vector3 (x, 0, 0).normalized * lookSpeed * Time.deltaTime;
        this.transform.localPosition = new Vector3(this.transform.localPosition.x, 0.739f, this.transform.localPosition.z);
        
		var angle = this.transform.eulerAngles.x;
		angle = (angle > 180) ? angle - 360 : angle;
		if (angle > maxRotate)
			this.transform.eulerAngles = new Vector3 (maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		if (angle < -maxRotate)
			this.transform.eulerAngles = new Vector3 (-maxRotate, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
		player.transform.localEulerAngles += new Vector3 (0, y, 0).normalized*lookSpeed*1.2f*Time.deltaTime;
	}
}

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.VR;

[RequireComponent(typeof(Rigidbody))]
/// <summary>
/// Players movement behaviour.
/// </summary>
public class Movement : MonoBehaviour
{
    /// <summary>
    /// The speed multiplier of the player.
    /// </summary>
	[Range(1, 5)][SerializeField]private float speed;

    /// <summary>
    /// Reference to the Rigidbody.
    /// </summary>
	private Rigidbody rigid;
    /// <summary>
    /// Vector3 of the movement.
    /// </summary>
	private Vector3 movement;
    /// <summary>
    /// Reference to the Audiomanager.
    /// </summary>
	private AudioManager audioManager;

    private float startY;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		rigid = GetComponent<Rigidbody> ();
		audioManager = FindObjectOfType<AudioManager> ();
        startY = this.transform.position.y;
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		var x = Input.GetAxis (Controller.LeftStickX);
		var z = Input.GetAxis (Controller.LeftStickY);
		movement = new Vector3 (x, 0, z);
	}

    /// <summary>
    /// FixedUpdate of the function.
    /// </summary>
	private void FixedUpdate()
	{
        if (VRDevice.isPresent)
            vrMovement();
        else
            normalMovement();
	}

    private void normalMovement()
    {
        Vector3 velocity = transform.TransformDirection(movement.normalized) * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.transform.localPosition + velocity);
        var mag = Mathf.Abs(velocity.z*10);
        if (mag >= 0.01)
            audioManager.playSound ("Footstep1");
    }

    private void vrMovement()
    {
        Vector3 velocity = Camera.main.transform.TransformDirection(movement.normalized) * speed * Time.fixedDeltaTime;
        velocity.y = 0;
        rigid.MovePosition(rigid.transform.localPosition + velocity);
        var mag = Mathf.Abs(velocity.z*10);
        if (mag >= 0.01)
            audioManager.playSound ("Footstep1");
    }
}

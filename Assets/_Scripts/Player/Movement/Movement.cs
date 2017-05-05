using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
	[Range(1, 5)][SerializeField]private float speed;

	private Rigidbody rigid;
	private Vector3 movement;
	private AudioManager audioManager;

	private void Start()
	{
		rigid = GetComponent<Rigidbody> ();
		audioManager = FindObjectOfType<AudioManager> ();
	}

	private void Update()
	{
		var x = Input.GetAxis (Controller.LeftStickX);
		var z = Input.GetAxis (Controller.LeftStickY);
		movement = new Vector3 (x, 0, z);
	}

	private void FixedUpdate()
	{
		Vector3 velocity = transform.TransformDirection(movement.normalized) *  speed * Time.fixedDeltaTime;
		rigid.MovePosition(rigid.transform.localPosition + velocity);
		var mag = Mathf.Abs(velocity.z*10);
		if (mag >= 0.01)
			audioManager.playSound ("step1");
	}
}

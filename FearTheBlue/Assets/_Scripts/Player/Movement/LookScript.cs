using UnityEngine;

public class LookScript : MonoBehaviour 
{
	private GameObject player;
	private float multiplier;

	private void Start()
	{
		if (!(player = this.transform.parent.gameObject))
			throw new System.Exception ("LookScript: Cannot find player as parent");
		multiplier = 2f;
	}

	private void Update()
	{
		var x = Input.GetAxisRaw (Controller.RightStickX);
		var y = Input.GetAxisRaw (Controller.RightStickY);
		var tjoep = new Vector3 (x, 0, 0);
		this.transform.eulerAngles += tjoep.normalized*multiplier;
		player.transform.localEulerAngles += new Vector3 (0, y, 0).normalized*multiplier;
	}
}

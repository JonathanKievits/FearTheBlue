using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportThroughDoor : MonoBehaviour 
{
	private GameObject player;
	private SpriteRenderer darkView;

	private void Start()
	{
		this.player = GameObject.FindGameObjectWithTag (Tags.player);
		this.darkView = player.GetComponentInChildren<SpriteRenderer> ();
	}

	public void teleport(Transform newPosition)
	{
		StartCoroutine (fade(newPosition.position));
	}

	private IEnumerator fade(Vector3 position)
	{
		while (darkView.color.a < 1) 
		{
			var alpha = darkView.color.a + 0.1f;
			darkView.color = new Color (0, 0, 0, alpha);
			yield return new WaitForSeconds (0.05f);
		}
		player.transform.position = position;
		while (darkView.color.a > 0) 
		{
			var alpha = darkView.color.a - 0.1f;
			darkView.color = new Color (0, 0, 0, alpha);
			yield return new WaitForSeconds (0.05f);
		}
	}
}

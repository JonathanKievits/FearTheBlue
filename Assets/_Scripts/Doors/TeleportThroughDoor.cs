using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeleportThroughDoor : MonoBehaviour 
{
	private GameObject player;
	//private SpriteRenderer darkView;
    [SerializeField]private Image darkView;

	private void Start()
	{
		this.player = GameObject.FindGameObjectWithTag (Tags.player);
        darkView.color = new Color (0, 0, 0, 0);
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
            Canvas.ForceUpdateCanvases();
			yield return new WaitForSeconds (0.05f);
		}
		player.transform.position = position;
		while (darkView.color.a > 0) 
		{
			var alpha = darkView.color.a - 0.1f;
			darkView.color = new Color (0, 0, 0, alpha);
            Canvas.ForceUpdateCanvases();
			yield return new WaitForSeconds (0.05f);
		}
	}
}

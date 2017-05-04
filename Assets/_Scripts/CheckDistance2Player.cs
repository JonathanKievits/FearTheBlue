using UnityEngine;

public class CheckDistance2Player : MonoBehaviour 
{
	private Transform player;
	private void Start(){player = GameObject.FindGameObjectWithTag (Tags.player).transform;}

	/// <summary>
	/// Check if player is in range of an object
	/// </summary>
	/// <returns><c>true</c>, if player is within range, <c>false</c> otherwise.</returns>
	/// <param name="objectToCheck">Object to check.</param>
	/// <param name="maxDistance">Max distance.</param>
	public bool inRange(Vector3 objectToCheck, float maxDistance)
	{
		var distance = (player.position - objectToCheck).sqrMagnitude;
		if (distance <= maxDistance)
			return true;
		return false;
	}
}

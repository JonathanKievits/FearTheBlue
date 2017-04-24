using UnityEngine;

public class PillarLogic : MonoBehaviour 
{
	private GameObject player;
	private RotateObject objectToRotate;
	[SerializeField]private LookScript lookScript;
	[SerializeField]private Movement movementScript;
	private Inventory inventory;
	private bool isEnabled;
	private bool hasObject;
	[Range(1,20)][SerializeField]private float maxDistance;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		objectToRotate = this.transform.GetChild (0).gameObject.GetComponent<RotateObject>();
		inventory = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Inventory> ();
		isEnabled = false;
		hasObject = false;
	}

	private void Update()
	{
		if (Input.GetButtonDown (Controller.Cross))
		{
			var distance = (this.transform.position - player.transform.position).sqrMagnitude;
			if (distance > maxDistance)
				return;
			
			if (!hasObject)
				setCube ();

			if (!isEnabled)
			{
				enableCube ();
				return;
			}

			disableCube ();
		}
	}

	private void enableCube()
	{
		if (!hasObject)
			return;
		
		var distance = (this.transform.position - player.transform.position).sqrMagnitude;
		if (distance <= maxDistance)
		{
			objectToRotate.gameObject.SetActive (true);
			objectToRotate.enabled = true;
			lookScript.enabled = false;
			movementScript.enabled = false;
			isEnabled = true;
		}
	}

	private void setCube()
	{
		if(inventory.getItem(ItemType.puzzleItem, "ToyCar") != null)
		{
			objectToRotate.gameObject.SetActive (true);
			inventory.removeItem (ItemType.puzzleItem, "ToyCar");
			hasObject = true;
		}
	}

	public void disableCube()
	{
		objectToRotate.enabled = false;
		lookScript.enabled = true;
		movementScript.enabled = true;
		isEnabled = false;
	}
}

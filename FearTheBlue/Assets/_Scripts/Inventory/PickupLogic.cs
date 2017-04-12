using System.Collections;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
	
	[SerializeField]private ItemType type;
	[SerializeField]private string name;
	public string GetName{get{return name;}}
	[SerializeField]private GameObject canvas;
	private GameObject player;
	private Item item;
	private Inventory inventory;
	[Range(5,20)]
	[SerializeField]private float maxDistance;

	private void Awake()
	{
		if (type == null || name == "")
		{
			throw new System.Exception ("Name or type is null");
		} 

		item = new Item (name, type);
		player = GameObject.FindGameObjectWithTag ("Player");
		inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
		canvas.SetActive (false);
	}

	private void Update()
	{
		var distance = (player.transform.position - this.transform.position).sqrMagnitude;
		if (distance > maxDistance)
		{
			canvas.SetActive (false);
			return;
		} 

		canvas.SetActive (true);
		if (Input.GetKeyDown (KeyCode.E))
		{
			inventory.AddItem (item);
			Destroy (this.gameObject);
		}
	}
}

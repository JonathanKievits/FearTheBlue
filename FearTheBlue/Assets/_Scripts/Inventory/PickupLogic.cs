using System.Collections;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
	[SerializeField]private ItemType type;
	[SerializeField]private string name;
	[Range(0,0.1f)][SerializeField]private float outlineWidth;
	public string Name{get{return name;}}
	[Range(10,500)][SerializeField]private float maxDistance;	
	private GameObject player;
	private Item item;
	private Inventory inventory;
	private ObjectOutlining outlining;
	private Renderer renderer;

	private void Awake()
	{
		if (this.name == "")
			throw new System.Exception ("Name is null");

		this.item = new Item (this.name, this.type);
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.renderer = this.GetComponent<Renderer> ();
		this.inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectOutlining>();
	}

	private void Update()
	{
		var distance = (player.transform.position - this.transform.position).sqrMagnitude;
		if (distance > maxDistance)
		{
			this.outlining.normal(this.renderer);
			return;
		} 

		this.outlining.outline (this.renderer, outlineWidth);
		if (Input.GetKeyDown (KeyCode.E))
		{
			inventory.AddItem (item);
			Destroy (this.gameObject);
		}
	}
}

using System.Collections;
using UnityEngine;

public class PickupLogic : MonoBehaviour
{
	[SerializeField]private ItemType type;
	[SerializeField]private string name;
	[Range(0,0.5f)][SerializeField]private float outlineWidth;
	public string Name{get{return name;}}
	[Range(1,5)][SerializeField]private float maxDistance;	
	private GameObject player;
	private Item item;
	private Inventory inventory;
	private ObjectOutlining outlining;
	private Renderer renderer;
	private bool isOutlined;

	private void Awake()
	{
		if (this.name == "")
			throw new System.Exception ("Name is null");
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.renderer = this.GetComponent<Renderer> ();
		if (this.renderer == null)
			this.renderer = this.GetComponentInChildren<Renderer> ();
		this.inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectOutlining>();
		this.item = new Item (this.name, this.type);
		this.isOutlined = false;

	}

	private void Update()
	{
		var distance = (player.transform.position - this.transform.position).sqrMagnitude;
		if (distance > maxDistance && this.isOutlined)
		{
			this.outlining.normal(this.renderer);
			this.isOutlined = !this.isOutlined;
			return;
		} 

		if (distance <= maxDistance && !this.isOutlined)
		{
			this.outlining.outline (this.renderer, this.outlineWidth);	
			this.isOutlined = !this.isOutlined;
		}

		if (distance <= maxDistance && Input.GetButtonDown(Controller.Cross))
		{
			inventory.AddItem (item);
			Destroy (this.gameObject);
		}
	}
}

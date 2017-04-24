using UnityEngine;

public abstract class Pickup : MonoBehaviour
{
	[SerializeField]protected string name;
	public string Name{get{return name;}}
	[SerializeField]protected ItemType type;
	[SerializeField]protected Color outlineColour;
	[Range(0,0.5f)][SerializeField]protected float outlineWidth;
	[Range(1,5)][SerializeField]protected float maxDistance;	

	protected GameObject player;
	protected Item item;
	protected Inventory inventory;
	protected ObjectOutlining outlining;
	protected Renderer renderer;
	protected bool isOutlined;

	protected void Awake()
	{
		if (this.name == "")
			throw new System.Exception ("PickupLogic on "+this.gameObject.name+": Name is null");
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.renderer = this.GetComponent<Renderer> ();
		if (this.renderer == null)
			this.renderer = this.GetComponentInChildren<Renderer> ();
		this.inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectOutlining>();
		this.item = new Item (this.name, this.type);
		this.isOutlined = false;
	}

	protected void Update()
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
			this.outlining.outline (this.renderer, this.outlineWidth, outlineColour);	
			this.isOutlined = !this.isOutlined;
		}

		if (this.isOutlined && Input.GetButtonDown(Controller.Cross))
		{
			inventory.AddItem (item);
			onPickup ();
			this.gameObject.SetActive(false);
		}
	}

	protected virtual void onPickup(){}
}

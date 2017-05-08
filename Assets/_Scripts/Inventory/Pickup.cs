using UnityEngine;

public class Pickup : MonoBehaviour
{
	[SerializeField]private string name;
	public string Name{get{return name;} set{name = value;}}
	[SerializeField]private ItemType type;
	public ItemType Type{get{return type;}set{type = value;}}
	[SerializeField]private Color outlineColour;
	public Color OutlineColour{get{return outlineColour;}set{outlineColour = value;}}
	[Range(0,0.5f)][SerializeField]private float outlineWidth;
	public float OutlineWidth{get{return outlineWidth;}set{outlineWidth = value;}}
	[Range(1,5)][SerializeField]private float maxDistance;
	public float MaxDistance{get{return maxDistance;}set{maxDistance = value;}}

	private CheckDistance2Player range;
	private Item item;
	private Inventory inventory;
	private ObjectOutlining outlining;
	private Renderer renderer;
	private bool isOutlined;

	private void Awake()
	{
		if (this.name == "")
			throw new System.Exception ("PickupLogic on "+this.gameObject.name+": Name is null");

		this.range = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CheckDistance2Player>();
		this.renderer = this.GetComponent<Renderer> ();
		if (this.renderer == null)
			this.renderer = this.GetComponentInChildren<Renderer> ();
		this.inventory = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectOutlining>();
		this.item = new Item (this.name, this.type);
		this.isOutlined = false;
	}

	private void Update()
	{
		if (!range.inRange(this.transform.position, maxDistance) && this.isOutlined)
		{
			this.outlining.normal(this.renderer);
			this.isOutlined = !this.isOutlined;
			return;
		}

		if (range.inRange(this.transform.position, maxDistance) && !this.isOutlined)
		{
			this.outlining.outline (this.renderer, this.outlineWidth, outlineColour);
			this.isOutlined = !this.isOutlined;
		}

		if (this.isOutlined && Input.GetButtonDown(Controller.Cross))
		{
			inventory.AddItem (item);
			this.gameObject.SetActive(false);
		}
	}
}

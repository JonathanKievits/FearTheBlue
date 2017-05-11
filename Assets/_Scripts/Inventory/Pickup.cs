using UnityEngine;

/// <summary>
/// Pickup logic.
/// </summary>
public class Pickup : MonoBehaviour
{
    /// <summary>
    /// Name of the item.
    /// </summary>
	[SerializeField]private string name;
	public string Name{get{return name;} set{name = value;}}
    /// <summary>
    /// Type of the item.
    /// </summary>
	[SerializeField]private ItemType type;
	public ItemType Type{get{return type;}set{type = value;}}
    /// <summary>
    /// The outline colour.
    /// </summary>
	[SerializeField]private Color outlineColour;
	public Color OutlineColour{get{return outlineColour;}set{outlineColour = value;}}
    /// <summary>
    /// The width of the outline.
    /// </summary>
	[Range(0,0.5f)][SerializeField]private float outlineWidth;
	public float OutlineWidth{get{return outlineWidth;}set{outlineWidth = value;}}
    /// <summary>
    /// The max distance to the player.
    /// </summary>
	[Range(1,5)][SerializeField]private float maxDistance;
	public float MaxDistance{get{return maxDistance;}set{maxDistance = value;}}

    /// <summary>
    /// Reference to CheckDistance2Player. 
    /// </summary>
	private CheckDistance2Player range;
    /// <summary>
    /// Reference to the Item class.
    /// </summary>
	private Item item;
    /// <summary>
    /// Reference to the Inventory class.
    /// </summary>
	private Inventory inventory;
    /// <summary>
    /// Reference to ObjectOutlining class.
    /// </summary>
	private ObjectOutlining outlining;
    /// <summary>
    /// Reference to the Renderer.
    /// </summary>
	private Renderer renderer;
    /// <summary>
    /// Boolean if the object is outlined.
    /// </summary>
	private bool isOutlined;

    /// <summary>
    /// Awake this instance.
    /// </summary>
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

    /// <summary>
    /// Update this instance.
    /// </summary>
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

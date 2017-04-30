using UnityEngine;

public abstract class Interaction : MonoBehaviour 
{
	[SerializeField]private float maxDistance;
	[Range(0, 0.5f)][SerializeField]private float outlineWidth;
	[SerializeField]private Color outlineColour = Color.yellow;

	private CheckDistance2Player range;
	private ObjectOutlining outlining;
	private Renderer renderer;
	private bool isOutlined;

	protected virtual void Start()
	{
		this.range = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CheckDistance2Player>();
		this.outlining = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectOutlining>();
		this.renderer = this.GetComponent<Renderer> ();
		this.isOutlined = false;
	}

	protected virtual void Update()
	{
		if (!range.inRange(this.transform.position, this.maxDistance) && this.isOutlined)
		{
			this.outlining.normal(this.renderer);
			this.isOutlined = !this.isOutlined;
			return;
		} 

		if (range.inRange(this.transform.position, this.maxDistance) && !this.isOutlined)
		{
			this.outlining.outline (this.renderer, this.outlineWidth, this.outlineColour);	
			this.isOutlined = !this.isOutlined;
		}

		if (Input.GetButtonDown (Controller.Cross))
			onInteraction ();
	}

	protected abstract void onInteraction();
}

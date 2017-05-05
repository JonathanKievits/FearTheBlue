using UnityEngine;
public class PlayCassette : MonoBehaviour 
{
	[SerializeField]protected Color outlineColour; 
	[Range(0,0.5f)][SerializeField]protected float outlineWidth; 
	[Range(1,5)][SerializeField]protected float maxDistance; 	

	private AudioManager audio; 
	private Inventory inventory; 
	protected Renderer renderer;
	private ObjectOutlining outlining; 
	private CheckDistance2Player range;
	private bool isOutlined; 

	private void Start() 
	{
		this.range = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CheckDistance2Player>();
		this.inventory = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<ObjectOutlining>();
		this.audio = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<AudioManager>();
		this.renderer = this.GetComponent<Renderer> ();
		if (this.renderer == null)
			this.renderer = this.GetComponentInChildren<Renderer> ();
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

		if (!this.isOutlined)
			return;

		if (Input.GetButtonDown (Controller.Cross))
		{
			var tapes = inventory.getAllItemsOfType (ItemType.cassette);
			if (tapes == null)
				return;

			if (this.audio.isPlaying (tapes [0].Name))
				return;
			
			this.audio.playSound (tapes[0].Name);
		}
	}
}

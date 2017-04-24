using UnityEngine;
public class PlayCassette : MonoBehaviour 
{
	[SerializeField]protected Color outlineColour; 
	[Range(0,0.5f)][SerializeField]protected float outlineWidth; 
	[Range(1,5)][SerializeField]protected float maxDistance; 	

	private Transform player; 
	private AudioManager audio; 
	private Inventory inventory; 
	protected Renderer renderer;
	private ObjectOutlining outlining; 
	private bool isOutlined; 

	private void Start() 
	{
		this.player = GameObject.FindGameObjectWithTag ("Player").transform; 
		this.inventory = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Inventory>();
		this.outlining = GameObject.FindGameObjectWithTag ("GameController").GetComponent<ObjectOutlining>();
		this.audio = GameObject.FindGameObjectWithTag ("GameController").GetComponent<AudioManager>();
		this.renderer = this.GetComponent<Renderer> ();
		if (this.renderer == null)
			this.renderer = this.GetComponentInChildren<Renderer> ();
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
			/*
			foreach (Item tape in tapes)
			{
				if (this.audio.isPlaying (tape.Name))
					return;	
			}*/

			if (this.audio.isPlaying (tapes [0].Name))
				return;
			
			this.audio.playSound (tapes[0].Name);
		}
	}
}

using System.Collections;

using UnityEngine;
public class PlayCassette : MonoBehaviour
{
	[SerializeField]private Color outlineColour;
    [SerializeField]private AudioClip insertSound;
    [Range(0,0.5f)][SerializeField]private float outlineWidth;
    [Range(1,5)][SerializeField]private float maxDistance;

	private AudioManager audio;
	private Inventory inventory;
	private Renderer renderer;
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
            StartCoroutine("playTape");

	}

    private IEnumerator playTape()
    {
        var tapes = inventory.getAllItemsOfType (ItemType.cassette);
        if (tapes == null)
            yield break;

        if (this.audio.isPlaying(tapes[0].Name))
            yield break;

        this.audio.playSound("InsertTape");
        yield return new WaitForSeconds(insertSound.length);
        this.audio.playSound (tapes[0].Name);
    }
}

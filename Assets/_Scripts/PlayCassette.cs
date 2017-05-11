using System.Collections;

using UnityEngine;
/// <summary>
/// Play cassette.
/// </summary>
public class PlayCassette : MonoBehaviour
{
    /// <summary>
    /// The outline colour.
    /// </summary>
	[SerializeField]private Color outlineColour;
    /// <summary>
    /// The insert soundclip.
    /// </summary>
    [SerializeField]private AudioClip insertSound;
    /// <summary>
    /// The width of the outline.
    /// </summary>
    [Range(0,0.5f)][SerializeField]private float outlineWidth;
    /// <summary>
    /// The max distance to the player.
    /// </summary>
    [Range(1,5)][SerializeField]private float maxDistance;

    /// <summary>
    /// Reference to audiomanager.
    /// </summary>
	private AudioManager audio;
    /// <summary>
    /// Reference to inventory.
    /// </summary>
	private Inventory inventory;
    /// <summary>
    /// Reference to the Renderer.
    /// </summary>
	private Renderer renderer;
    /// <summary>
    /// Reference to ObjectOulining
    /// </summary>
	private ObjectOutlining outlining;
    /// <summary>
    /// Reference to CheckDistance2Player
    /// </summary>
	private CheckDistance2Player range;
    /// <summary>
    /// Boolean if the object is outlined
    /// </summary>
	private bool isOutlined;

    /// <summary>
    /// Start this instance.
    /// </summary>
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

		if (!this.isOutlined)
			return;

		if (Input.GetButtonDown (Controller.Cross))
            StartCoroutine("playTape");

	}

    /// <summary>
    /// Playes the tape.
    /// </summary>
    /// <returns>The tape.</returns>
    private IEnumerator playTape()
    {
        var tape = inventory.getItem(ItemType.cassette, "Tape2");
        if (tape == null)
            yield break;

        if (this.audio.isPlaying(tape.Name))
            yield break;

        this.audio.playSound("InsertTape");
        yield return new WaitForSeconds(insertSound.length);
        this.audio.playSound (tape.Name);
    }
}

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HingeJoint))]
/// <summary>
/// Door logic.
/// </summary>
public class DoorLogic : MonoBehaviour 
{
	private enum HingePosition{left, right};

    /// <summary>
    /// Does the door need a key.
    /// </summary>
	[SerializeField]private bool needsKey;
    /// <summary>
    /// The name of the key.
    /// </summary>
	[SerializeField]private string keyName;
    /// <summary>
    /// The position the player should have after opening the door.
    /// </summary>
	[SerializeField]private Transform newPosition;
    /// <summary>
    /// The hinge position.
    /// </summary>
	[SerializeField]private HingePosition hingePosition;

    [SerializeField]private GameObject roomToTeleportTo;
    [SerializeField]private GameObject originalRoom;

    /// <summary>
    /// If player is in range of the door.
    /// </summary>
	private bool inRange;
    /// <summary>
    /// If the door is busy opening.
    /// </summary>
    private bool isOpening;
    /// <summary>
    /// The max rotation of the door.
    /// </summary>
	private float maxRotate;
    /// <summary>
    /// Reference to the lookscript.
    /// </summary>
    private LookScript look;
    /// <summary>
    /// Reference to the Movement script.
    /// </summary>
    private Movement movement;
    /// <summary>
    /// Reference to the player.
    /// </summary>
	private GameObject player;
    /// <summary>
    /// Reference to the Inventory script.
    /// </summary>
	private Inventory inventory;
    /// <summary>
    /// The original rotation of the door.
    /// </summary>
	private Vector3 originalRotation;
    /// <summary>
    /// The original position of the door.
    /// </summary>
	private Vector3 originalPosition;
    /// <summary>
    /// Reference to the Audiomanager.
    /// </summary>
	private AudioManager audioManager;
    /// <summary>
    /// Reference to TeleportThroughDoor script.
    /// </summary>
    private int _doorNeedsKey; 
    private int _doorOpens;
    private int _doorCloses;
	private TeleportThroughDoor teleport;

    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		this.inRange = false;
        this.isOpening = false;
		this.originalRotation = this.transform.localEulerAngles;
		this.originalPosition = this.transform.localPosition;
		if(this.hingePosition == HingePosition.right)
			this.maxRotate = Mathf.Abs (this.transform.localEulerAngles.y - 10);
		else
			this.maxRotate = Mathf.Abs (this.transform.localEulerAngles.y + 10);

		this.player = GameObject.FindGameObjectWithTag (Tags.player);
        this.movement = player.GetComponent<Movement>();
        this.look = player.GetComponentInChildren<LookScript>();
		this.inventory = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<Inventory> ();
		this.audioManager = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<AudioManager> ();
        _doorNeedsKey = audioManager.audioToID("DoorNeedsKey");
        _doorOpens = audioManager.audioToID("DoorOpens");
        _doorCloses = audioManager.audioToID("DoorCloses");

		this.teleport = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<TeleportThroughDoor> ();
	}

    /// <summary>
    /// Raises the trigger enter event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != this.player)
			return;

		inRange = true;
	}

    /// <summary>
    /// Raises the trigger exit event.
    /// </summary>
    /// <param name="other">Other.</param>
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != this.player)
			return;

		inRange = false;
	}
	
    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (!inRange)
			return;

		if (Input.GetButtonDown (Controller.Cross)) 
		{
			if (this.needsKey && inventory.getItem (ItemType.key, keyName) == null) 
			{
                audioManager.playSound (_doorNeedsKey);
				return;
			}
			
            if (this.isOpening)
                return;
            
			StartCoroutine ("openDoor");
		}
	}

    /// <summary>
    /// Opens the door.
    /// </summary>
    /// <returns>The door.</returns>
	private IEnumerator openDoor()
	{
        this.isOpening = true;
        roomToTeleportTo.SetActive(true);
        movement.enabled = look.enabled = false;
        audioManager.playSound (_doorOpens);
		if (this.hingePosition == HingePosition.right) 
		{
			while (Mathf.Abs (this.transform.localEulerAngles.y) > maxRotate) 
			{
				var newY = this.transform.localEulerAngles.y - 1f;
				this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x, newY, this.transform.localEulerAngles.z);
				yield return new WaitForSeconds (0.005f);
			}
		} 
		else 
		{
			while (Mathf.Abs (this.transform.localEulerAngles.y) < maxRotate) 
			{
				var newY = this.transform.localEulerAngles.y + 1f;
				this.transform.localEulerAngles = new Vector3 (this.transform.localEulerAngles.x, newY, this.transform.localEulerAngles.z);
				yield return new WaitForSeconds (0.005f);
			}
		}

		teleport.teleport (newPosition);
		yield return new WaitForSeconds (1f);
        audioManager.playSound (_doorCloses);
		this.transform.localPosition = this.originalPosition;
		this.transform.localEulerAngles = this.originalRotation;
        this.isOpening = false;
        movement.enabled = look.enabled = true;
        originalRoom.SetActive(false);
	}
}

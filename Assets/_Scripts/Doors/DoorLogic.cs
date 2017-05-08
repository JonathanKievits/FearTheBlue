using UnityEngine;
using System.Collections;

[RequireComponent(typeof(HingeJoint))]
public class DoorLogic : MonoBehaviour 
{
	private enum HingePosition{left, right};

	[SerializeField]private bool needsKey;
	[SerializeField]private string keyName;
	[SerializeField]private Transform newPosition;
	[SerializeField]private HingePosition hingePosition;

	private bool inRange;
    private bool isOpening;
	private float maxRotate;
    private LookScript look;
    private Movement movement;
	private GameObject player;
	private Inventory inventory;
	private Vector3 originalRotation;
	private Vector3 originalPosition;
	private AudioManager audioManager;
	private TeleportThroughDoor teleport;

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
		this.teleport = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<TeleportThroughDoor> ();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject != this.player)
			return;

		inRange = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject != this.player)
			return;

		inRange = false;
	}
	
	private void Update()
	{
		if (!inRange)
			return;

		if (Input.GetButtonDown (Controller.Cross)) 
		{
			if (this.needsKey && inventory.getItem (ItemType.key, keyName) == null) 
			{
				audioManager.playSound ("DoorNeedsKey");
				return;
			}
			
            if (this.isOpening)
                return;
            
			StartCoroutine ("openDoor");
		}
	}

	private IEnumerator openDoor()
	{
        this.isOpening = true;
        movement.enabled = look.enabled = false;
		audioManager.playSound ("DoorOpens");
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
        audioManager.playSound ("DoorCloses");
		this.transform.localPosition = this.originalPosition;
		this.transform.localEulerAngles = this.originalRotation;
        this.isOpening = false;
        movement.enabled = look.enabled = true;
	}
}

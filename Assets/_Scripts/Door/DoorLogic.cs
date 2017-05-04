using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLogic : MonoBehaviour {
    private GameObject player;
    private Inventory inventory;
    private DoorTransition doorTransition;
    [Range(1, 10)][SerializeField]private float maxDistance;

    private void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("GameController").GetComponent<Inventory>();
        doorTransition = GameObject.FindGameObjectWithTag("Door").GetComponent<DoorTransition>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(Controller.Cross))
        {
            var distance = (this.transform.position - player.transform.position).sqrMagnitude;
            if (distance > maxDistance)
                return;
            hasAKey();
        }
    }

    private void hasAKey()
    {
        if (inventory.getItem(ItemType.key, "MainKey") != null)
        {
            doorTransition.keyIsUsed();
            inventory.removeItem(ItemType.key, "MainKey");
        }
    }
}

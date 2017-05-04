using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransition : MonoBehaviour {
    private GameObject player;
    [SerializeField]private Transform door;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void keyIsUsed()
    {
        StartCoroutine("fadeOut");
    }

    private IEnumerator fadeOut()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.localPosition = new Vector3(player.transform.position.x + 3, player.transform.position.y, player.transform.position.z);
        StopCoroutine("fadeOut");
    }

}

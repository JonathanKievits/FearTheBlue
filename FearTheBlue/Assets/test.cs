using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class test : MonoBehaviour {

	void Start () {
		print(VRDevice.isPresent);
	}
}

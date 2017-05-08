using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoom : MonoBehaviour
{
	private void OnTriggerStay()
	{
		if (Input.GetButtonDown (Controller.Cross))
			SceneManager.LoadSceneAsync (0);
	}
}

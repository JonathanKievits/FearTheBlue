using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Endroom logic.
/// </summary>
public class EndRoom : MonoBehaviour
{
    /// <summary>
    /// Raises the trigger stay event.
    /// </summary>
	private void OnTriggerStay()
	{
		if (Input.GetButtonDown (Controller.Cross))
			SceneManager.LoadSceneAsync (0);
	}
}

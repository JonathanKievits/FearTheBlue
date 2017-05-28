using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(LoadUIHandler))]
/// <summary>
/// Load scene.
/// </summary>
public class LoadScene : MonoBehaviour 
{
    /// <summary>
    /// Reference to LoadUIHandler class.
    /// </summary>
    private LoadUIHandler uiHandler;

    /// <summary>
    /// Start this instance.
    /// </summary>
    private void Start()
    {
        uiHandler = this.GetComponent<LoadUIHandler>();
    }

    /// <summary>
    /// Loads the scene.
    /// </summary>
    /// <param name="sceneIndex">Scene index.</param>
    public void loadScene(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }

    /// <summary>
    /// Load the specified sceneIndex.
    /// </summary>
    /// <param name="sceneIndex">Scene index.</param>
    private IEnumerator load(int sceneIndex)
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
        while (!loading.isDone)
        {
            //var percentage = Mathf.Floor((loading.progress * 100) / 0.9f);
            uiHandler.updateUI(loading.progress);
            yield return null;
        }
    }
}

using System;
using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour 
{
    //Delegate that is called while loading
    public Action<float> OnProgress;

    //Call this function with the scene index to load
    public void loadScene(int sceneIndex)
    {
        StartCoroutine(load(sceneIndex));
    }
        
    private IEnumerator load(int sceneIndex)
    {
        //Loads the scene
        AsyncOperation loading = SceneManager.LoadSceneAsync(sceneIndex);
        //Calls any connected functions while loading
        while (!loading.isDone)
        {
            if (OnProgress != null)
                OnProgress(loading.progress);
            yield return null;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class LoadUIHandler : MonoBehaviour 
{
    //Text object that shows the percentage
    [SerializeField]private Text loadingText;
    //reference to the LoadScene script
    private LoadScene loadScene;

    private void Start()
    {
        loadScene = this.GetComponent<LoadScene>();
        //Let's the load script know we want to know when it's loading
        loadScene.OnProgress += updateUI;
    }
        
    private void updateUI(float percentage)
    {
        //make sure it will be a number from 0 to a 100
        var edited = Mathf.Floor((percentage * 100) / 0.9f);
        //Set the text value
        loadingText.text = "Loading: " + edited + "%";
    }
}

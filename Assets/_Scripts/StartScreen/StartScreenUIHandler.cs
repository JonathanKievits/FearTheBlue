using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartScreenUIHandler : MonoBehaviour 
{
    [SerializeField]private Button[] buttons;
    [SerializeField]private EventSystem eventSystem;

    private LoadScene loadScene;
    private StartScreenPanelHandler panelHandler;
   
    private void Start()
    {
        loadScene = this.GetComponent<LoadScene>();
        panelHandler = this.GetComponent<StartScreenPanelHandler>();
        setListeners();

    }

    private void Update()
    {
        if (eventSystem.currentSelectedGameObject != null)
            return;

        eventSystem.SetSelectedGameObject(buttons[0].gameObject);
    }

    private void setListeners()
    {
        buttons[0].onClick.AddListener(delegate() {panelHandler.showPanel(2, true); loadScene.loadScene(1);});
        buttons[1].onClick.AddListener(delegate() {panelHandler.showPanel(1, true);});
        buttons[2].onClick.AddListener(delegate() {CloseGame.Quit();});
    }
}

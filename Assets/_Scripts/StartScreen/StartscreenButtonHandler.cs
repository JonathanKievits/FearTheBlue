using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartscreenButtonHandler : MonoBehaviour 
{
    [SerializeField]private Selectable[] firstButtons;
    private StartScreenPanelHandler panelHandler;

    private void Awake()
    {
        panelHandler = this.GetComponent<StartScreenPanelHandler>();
        panelHandler.onPanelChange += selectFirstButton;
    }

    private void selectFirstButton(int panelIndex)
    {
        if (panelIndex > firstButtons.Length -1)
            return;

        firstButtons[panelIndex].Select();
    }
}

using UnityEngine;

public class StartScreenPanelHandler : MonoBehaviour 
{
    [SerializeField]private GameObject[] panels;
    private StartScreenUIHandler uiHandler;

    public delegate void OnPanelChange(int panelIndex);
    public OnPanelChange onPanelChange;

    private void Start()
    {
        uiHandler = this.GetComponent<StartScreenUIHandler>();
        showPanel(0, true);
    }

    public void showPanel(int index, bool value)
    {
        if (index > panels.Length - 1)
            return;
        
        for(var i = 0; i < panels.Length; i++){panels[i].SetActive(false);}
        panels[index].SetActive(value);

        if (onPanelChange != null)
            onPanelChange(index);
    }
}

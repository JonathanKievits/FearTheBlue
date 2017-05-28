using UnityEngine;
using UnityEngine.UI;

public class QualityUI : MonoBehaviour 
{
    /*Rendering*/
    [SerializeField]private Dropdown textureQuality;
    [SerializeField]private Dropdown antiAliasing;

    /*Shadows*/
    [SerializeField]private Dropdown shadows;
    [SerializeField]private Dropdown shadowCascades;
    [SerializeField]private Dropdown shadowResolution;
    //[SerializeField]private InputField maxShadowDistance;

    /*Other*/
    [SerializeField]private Dropdown vSyncCount;
    [SerializeField]private Dropdown profiles;

    [SerializeField]private Button back;

    private QualityLogic logic;
    private StartScreenPanelHandler panelHandler;

    private void Start()
    {
        logic = this.GetComponent<QualityLogic>();
        panelHandler = this.GetComponent<StartScreenPanelHandler>();

        setListeners();
        updateValues();
    }

    private void setListeners()
    {
        this.textureQuality.onValueChanged.AddListener(delegate{logic.setTextureQuality(this.textureQuality.value);});
        this.antiAliasing.onValueChanged.AddListener(delegate{logic.setAliasingLevel(this.antiAliasing.value);});


        this.shadowResolution.onValueChanged.AddListener(delegate{logic.setShadowResolution(this.shadowResolution.value);});
        this.shadowCascades.onValueChanged.AddListener(delegate {logic.setShadowCascades(this.shadowCascades.value);});
        this.shadows.onValueChanged.AddListener(delegate{logic.setShadow(this.shadows.value);});
       /*
        this.maxShadowDistance.onValueChanged.AddListener(delegate{
            var text = this.maxShadowDistance.text;
            if(text == "" || text == " ")
                return;
            var value = float.Parse(text);
            logic.setMaxShadowDistance(value);
        });
        */
        this.profiles.onValueChanged.AddListener(delegate{logic.setProfile(this.profiles.value); updateValues();});
        this.vSyncCount.onValueChanged.AddListener(delegate{logic.setVSyncCount(this.vSyncCount.value);});
        this.back.onClick.AddListener(delegate() {panelHandler.showPanel(0, true);});
    }

    public void selectFirst()
    {
        profiles.Select();
    }

    public void updateValues()
    {
        this.textureQuality.value = QualitySettings.masterTextureLimit;
        var aaValue = QualitySettings.antiAliasing;
        if (aaValue == 0)
            aaValue = 0;
        if (aaValue == 2)
            aaValue = 1;
        if (aaValue == 4)
            aaValue = 2;
        if (aaValue == 8)
            aaValue = 3;
        this.antiAliasing.value = aaValue;

        this.shadows.value = (int)QualitySettings.shadows;
        var cascades = QualitySettings.shadowCascades;
        if (cascades == 0)
            cascades = 0;
        if (cascades == 2)
            cascades = 1;
        if (cascades == 4)
            cascades = 2;
        this.shadowCascades.value = cascades;
        this.shadowResolution.value = (int)QualitySettings.shadowResolution;
        //this.maxShadowDistance.text = QualitySettings.shadowDistance.ToString();
        this.vSyncCount.value = QualitySettings.vSyncCount;
        this.profiles.value = QualitySettings.GetQualityLevel();
    }
}

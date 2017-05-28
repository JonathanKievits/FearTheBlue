using UnityEngine;

public class QualityLogic : MonoBehaviour 
{
    public void setAliasingLevel(int value)
    {
        if (value == 3)
            value = 8;

        if (value == 2)
            value = 4;

        if (value == 1)
            value = 2;
        QualitySettings.antiAliasing = value;
    }

    public void setShadow(int value)
    {
        QualitySettings.shadows = (ShadowQuality)value;
    }

    public void setShadowResolution(int value)
    {
        QualitySettings.shadowResolution = (ShadowResolution)value;
    }

    public void setVSyncCount(int value)
    {
        QualitySettings.vSyncCount = value;
    }

    public void setTextureQuality(int value)
    {
        QualitySettings.masterTextureLimit = value;
    }

    public void setMaxShadowDistance(float value)
    {
        QualitySettings.shadowDistance = value;
    }

    public void setProfile(int value)
    {
        QualitySettings.SetQualityLevel(value);
    }

    public void setShadowCascades(int value)
    {
        if (value == 0)
            value = 1;
        else
            value *= 2;
        QualitySettings.shadowCascades = value;
    }
}

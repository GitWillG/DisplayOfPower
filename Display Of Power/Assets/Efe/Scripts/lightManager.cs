﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using efe;

public class lightManager : MonoBehaviour
{

    public lightSO[] listLightPresets;
    public lightSO curLightPreset;

    Light curLight;
    // Start is called before the first frame update

    void Update()
    {

    }

    [ContextMenu("Apply Snow City Preset")]
    public void applySnowCity()
    {

    }

    [ContextMenu("Apply Pahro City Preset")]
    public void applyPahro()
    {

    }

    [ContextMenu("Apply Water City Preset")]
    public void applyWaterCity()
    {

    }

    public void changeLightSettings(lightSO targetLight)
    {

    }
}

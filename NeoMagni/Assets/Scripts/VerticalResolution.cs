﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalResolution : MonoBehaviour {

    private void Awake()
    {
        //Set screen size for Standalone
#if UNITY_STANDALONE
        Screen.SetResolution(576, 1024, false);
        Screen.fullScreen = false;
#endif
    }
}
